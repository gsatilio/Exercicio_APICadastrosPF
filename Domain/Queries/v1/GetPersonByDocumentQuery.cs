using MediatR;

namespace Domain.Queries.v1;

public class GetPersonByDocumentQuery(string Document) : IRequest<GetPersonByDocumentQueryResponse>
{
    public Guid Id { get; set; }
    public string Document { get; set; } = Document;
}
