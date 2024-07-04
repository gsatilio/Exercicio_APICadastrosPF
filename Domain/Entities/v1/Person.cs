using Domain.Contracts.v1;
using Domain.ValueObjects.v1;

namespace Domain.Entities.v1;

public sealed class Person : IEntity<Guid>
{
    public Person()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Document { get; set; }
    public DateTime Birthday { get; set; }
    public Address? Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

}