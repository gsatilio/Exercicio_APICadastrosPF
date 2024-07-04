using Domain.Commands.v1.CreatePerson;
using Domain.Contracts.v1;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers.v1;

[Route("api/v1/persons")]
[ApiController]
public sealed class PersonController(IMediator bus, IDomainNotificationService domainNotification) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreatePersonCommand model, CancellationToken token)
    {
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
        var customer = await bus.Send(new GetPersonByIdQuery(id));

        if (customer is null) return NotFound();

        return Ok(new
        {
            Content = customer
        });
    }
}