using Domain.Commands.v1.CreatePerson;
using Domain.Commands.v1.DeletePerson;
using Domain.Contracts.v1;
using Domain.Queries.v1;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers.v1;

[Route("api/pessoas")]
[ApiController]
public sealed class PersonController(IMediator bus, IDomainNotificationService domainNotification) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreatePersonCommand model, CancellationToken token)
    {
        var person = await bus.Send(new GetPersonByDocumentQuery(model.Document));

        if (person != null)
            return StatusCode((int)HttpStatusCode.Conflict, new
            {
                Notification = "Esse CPF já existe na base de dados"
            });

        var response = await bus.Send(model, token);

        return StatusCode((int)HttpStatusCode.Created, new
        {
            Content = response,
            Notification = "Cliente cadastrado com sucesso!!!"
        });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken token)
    {
        var person = await bus.Send(new GetPersonByIdQuery(id));

        if (person is null) return NotFound();

        return Ok(new
        {
            Content = person
        });
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken token)
    {
        var person = await bus.Send(new GetPersonByIdQuery(id));

        if (person is null) return NotFound();

        DeletePersonCommand model = new DeletePersonCommand(person.Id)
        {
            Document = person.Document,
            Name = person.Name,
            Id = person.Id
        };
        var response = await bus.Send(model, token);

        return StatusCode((int)HttpStatusCode.OK, new
        {
            Content = response,
            Notification = "Cliente excluido com sucesso!!!"
        });
    }
}