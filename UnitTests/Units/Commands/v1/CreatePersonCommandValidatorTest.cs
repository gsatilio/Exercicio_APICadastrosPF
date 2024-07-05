using Domain.Commands.v1.CreatePerson;
using FluentValidation.Results;
using UnitTests.Mocks.Commands.v1;

namespace UnitTests.Units.Commands.v1;

public sealed class CreatePersonCommandValidatorTest
{
    private static ValidationResult EstablishContext(CreatePersonCommand command) =>
        new CreatePersonCommandValidator().Validate(command);

    [Fact(DisplayName = "Deve retornar válido quando request estiver correto")]
    public void ShoulSuccessWhenRequestIsValid()
    {
        var command = CreatePersonCommandMock.GetSuccessMock();
        var result = EstablishContext(command);

        Assert.True(result.IsValid);
    }

    [Fact(DisplayName = "Deve retornar inválido quando nome não for preenchido")]
    public void ShoulNameNotificationWhenNameIsInvalid()
    {
        var command = CreatePersonCommandMock.GetNameFailMock();
        var result = EstablishContext(command);

        Assert.False(result.IsValid); 
    }
}