namespace Domain.Commands.v1.CreatePerson;

public class CreatePersonCommandResponse
{
    public string Name { get; set; } = string.Empty;
    public Guid Id { get; set; }
}