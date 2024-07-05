namespace Domain.Commands.v1.DeletePerson;

public class DeletePersonCommandResponse
{
    public string Name { get; set; } = string.Empty;
    public Guid Id { get; set; }
}