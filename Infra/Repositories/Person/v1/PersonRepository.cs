using Domain.Contracts.v1;
using MongoDB.Driver;

namespace Infra.Repositories.Person.v1;

public class PersonRepository(IMongoClient client) : BaseDbRepository<Domain.Entities.v1.Person, Guid>(client), IPersonRepository;