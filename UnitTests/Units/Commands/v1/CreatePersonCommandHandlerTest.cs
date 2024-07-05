using AutoMapper;
using Domain.Commands.v1.CreatePerson;
using Domain.Contracts.v1;
using Domain.Entities.v1;
using Moq;
using UnitTests.Mocks.Commands.v1;
using UnitTests.Mocks.Entities.v1;

namespace UnitTests.Units.Commands.v1;

public sealed class CreatePersonCommandHandlerTest
{
    private readonly Mock<IPersonRepository> _personRepository = new();
    private readonly Mock<IMapper> _mapper = new();
    private readonly Mock<IDomainNotificationService> _domainNotificationService = new();

    private CreatePersonCommandHandler EstablishContext()
    {
        return new CreatePersonCommandHandler(
            _personRepository.Object,
            _mapper.Object,
            _domainNotificationService.Object);
    }

    [Fact(DisplayName = "Deve retornar sucesso quando inserção concluída com êxito")]
    public async Task ShouldSuccessReturnWhenInputIsValid()
    {
        var handler = EstablishContext();
        var command = CreatePersonCommandMock.GetSuccessMock();

        _personRepository.Setup(rep => rep.AddAsync(It.IsAny<Person>(), CancellationToken.None)).Returns(Task.CompletedTask);
        _mapper.Setup(map => map.Map<CreatePersonCommand, Person>(It.IsAny<CreatePersonCommand>())).Returns(PersonMock.GetSuccessMock());
        _mapper.Setup(map => map.Map<CreatePersonCommandResponse>(It.IsAny<Person>())).Returns(CreatePersonCommandResponseMock.GetSuccessMock());

        var response = await handler.Handle(command, CancellationToken.None);

        Assert.NotNull(response?.Id);
    }
}