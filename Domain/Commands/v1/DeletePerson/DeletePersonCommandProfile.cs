using AutoMapper;
using Domain.Entities.v1;

namespace Domain.Commands.v1.DeletePerson;

public class DeletePersonCommandProfile : Profile
{
    public DeletePersonCommandProfile()
    {
        CreateMap<DeletePersonCommand, Person>()
            .ForMember(fieldOutput => fieldOutput.Document, option => option
                .MapFrom(input => GetOnlyNumbers(input.Document)));

        CreateMap<Person, DeletePersonCommandResponse>();
    }

    public static string GetOnlyNumbers(string text)
    {
        var stringNumber = new String((text ?? string.Empty).Where(Char.IsDigit).ToArray());
        return stringNumber;
    }
}