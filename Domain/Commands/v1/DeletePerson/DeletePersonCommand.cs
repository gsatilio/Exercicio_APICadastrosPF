using Domain.ValueObjects.v1;
using MediatR;

namespace Domain.Commands.v1.DeletePerson;

public class DeletePersonCommand(Guid Id) : IRequest<DeletePersonCommandResponse>
{
    public Guid Id { get; set; } = Id;
    public string Document { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

}