using AutoMapper;
using Domain.Entities.v1;

namespace Domain.Queries.v1;

public class GetPersonByIdQueryProfile : Profile
{
    public GetPersonByIdQueryProfile()
    {
        CreateMap<Person, GetPersonByIdQueryResponse>();
    }
}