using Domain.Entities.v1;

namespace Domain.Contracts.v1;

public interface IPersonRepository : IRepository<Person, Guid>
{
}