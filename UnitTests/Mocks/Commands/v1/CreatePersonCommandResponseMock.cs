using Domain.Commands.v1.CreatePerson;

namespace UnitTests.Mocks.Commands.v1;

public static class CreatePersonCommandResponseMock
{
    public static CreatePersonCommandResponse GetSuccessMock() =>
        new() { Id = new Guid(), Name = "Guilherme" };
}
