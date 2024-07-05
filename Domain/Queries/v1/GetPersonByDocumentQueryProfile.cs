using AutoMapper;
using Domain.Entities.v1;

namespace Domain.Queries.v1;

public class GetPersonByDocumentQueryProfile : Profile
{
    public GetPersonByDocumentQueryProfile()
    {
        CreateMap<Person, GetPersonByDocumentQueryResponse>();
    }
}