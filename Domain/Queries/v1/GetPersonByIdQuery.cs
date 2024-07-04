using MediatR;

namespace Domain.Queries.v1;

public class GetPersonByIdQuery(Guid Id) : IRequest<GetPersonByIdQueryResponse>
{
    public Guid Id { get; set; } = Id;
}