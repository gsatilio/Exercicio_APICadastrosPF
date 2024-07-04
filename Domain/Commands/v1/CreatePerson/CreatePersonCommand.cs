using Domain.ValueObjects.v1;
using MediatR;

namespace Domain.Commands.v1.CreatePerson;

public class CreatePersonCommand : IRequest<CreatePersonCommandResponse>
{
    public string Name { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public DateTime Birthday { get; set; }
    public Address? Address { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

}