using AutoMapper;
using Domain.Entities.v1;

namespace Domain.Commands.v1.CreatePerson;

public class CreatePersonCommandProfile : Profile
{
    public CreatePersonCommandProfile()
    {
        CreateMap<CreatePersonCommand, Person>()
            .ForMember(fieldOutput => fieldOutput.Document, option => option
                .MapFrom(input => GetOnlyNumbers(input.Document)));

        CreateMap<Person, CreatePersonCommandResponse>();
    }

    public static string GetOnlyNumbers(string text)
    {
        var stringNumber = new String((text ?? string.Empty).Where(Char.IsDigit).ToArray());
        return stringNumber;
    }
}