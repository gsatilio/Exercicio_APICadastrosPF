using Domain.Contracts.v1;
using Domain.Entities.v1;
using AutoMapper;
using MediatR;

namespace Domain.Commands.v1.CreatePerson;

public class CreatePersonCommandHandler(IPersonRepository repository, IMapper mapper, IDomainNotificationService domainNotification)
    : IRequestHandler<CreatePersonCommand, CreatePersonCommandResponse>
{
    public async Task<CreatePersonCommandResponse> Handle(
        CreatePersonCommand request,
        CancellationToken cancellationToken)
    {
        var Person = mapper.Map<CreatePersonCommand, Person>(request);
        await repository.AddAsync(Person, cancellationToken);

        return mapper.Map<CreatePersonCommandResponse>(Person);
    }
}