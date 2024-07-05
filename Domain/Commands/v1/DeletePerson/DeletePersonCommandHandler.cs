using AutoMapper;
using Domain.Contracts.v1;
using Domain.Entities.v1;
using MediatR;

namespace Domain.Commands.v1.DeletePerson;

public class DeletePersonCommandHandler(IPersonRepository repository, IMapper mapper, IDomainNotificationService domainNotification)
    : IRequestHandler<DeletePersonCommand, DeletePersonCommandResponse>
{
    public async Task<DeletePersonCommandResponse> Handle(
        DeletePersonCommand request,
        CancellationToken cancellationToken)
    {
        var person = mapper.Map<DeletePersonCommand, Person>(request);
        await repository.DeleteAsync(person, cancellationToken);

        return mapper.Map<DeletePersonCommandResponse>(person);
    }
}