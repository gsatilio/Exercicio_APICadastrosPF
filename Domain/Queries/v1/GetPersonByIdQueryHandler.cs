using AutoMapper;
using Domain.Contracts.v1;
using Domain.Entities.v1;
using MediatR;
using System.Linq.Expressions;

namespace Domain.Queries.v1;

public class GetPersonByIdQueryHandler(
    IMapper mapper,
    IPersonRepository repository
    ) : IRequestHandler<GetPersonByIdQuery, GetPersonByIdQueryResponse>
{
    public async Task<GetPersonByIdQueryResponse> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {

        Expression<Func<Person, bool>> predicate = x => x.Id == request.Id;

        var Person = await repository.GetSingleOrDefaultAsync(predicate, cancellationToken);

        return mapper.Map<GetPersonByIdQueryResponse>(Person);
    }
}