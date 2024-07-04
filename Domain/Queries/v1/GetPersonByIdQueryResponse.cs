using Domain.ValueObjects.v1;

namespace Domain.Queries.v1;

public class GetPersonByIdQueryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Document { get; set; }
    public DateTime Birthday { get; set; }
    public Address? Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}