using AutoMapper;
using Domain.Contracts.v1;
using Domain.Entities.v1;
using MediatR;
using System.Linq.Expressions;

namespace Domain.Queries.v1;

public class GetPersonByDocumentQueryHandler(
    IMapper mapper,
    IPersonRepository repository
    ) : IRequestHandler<GetPersonByDocumentQuery, GetPersonByDocumentQueryResponse>
{
    public async Task<GetPersonByDocumentQueryResponse> Handle(GetPersonByDocumentQuery request, CancellationToken cancellationToken)
    {

        Expression<Func<Person, bool>> predicate = x => x.Document == request.Document;

        var Person = await repository.GetSingleOrDefaultAsync(predicate, cancellationToken);

        return mapper.Map<GetPersonByDocumentQueryResponse>(Person);
    }
}