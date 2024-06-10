namespace MediatRSample.Application.Handlers.Person;

using MediatR;
using MediatRSample.Application.Commands;
using MediatRSample.Application.Models;
using MediatRSample.Application.Notifications;
using MediatRSample.Application.Notifications.Person;
using MediatRSample.Repositories.Interfaces;

public class RemovePersonCommandHandler : IRequestHandler<RemovePersonCommand, string>
{
    private readonly IMediator _mediator;
    private readonly IRepository<Person> _repository;
    public RemovePersonCommandHandler(IMediator mediator, IRepository<Person> repository)
    {
        _mediator = mediator ?? throw new Exception();
        _repository = repository ?? throw new Exception();
    }

    public async Task<string> Handle(RemovePersonCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.Delete(request.Id);

            await _mediator.Publish(new RemovedPersonNotification 
            { 
                Id = request.Id,
                IsEfective = true 
            });

            return await Task.FromResult("Removed person successfully!");
        }
        catch (Exception ex)
        {
            await _mediator.Publish(new RemovedPersonNotification 
            {
                Id = request.Id,
                IsEfective = false 
            });

            await _mediator.Publish(new ErrorNotification 
            { 
                Exception = ex.Message, Error = 
                ex.StackTrace 
            });

            return await Task.FromResult("There was an error while attempt to remove person!");
        }
    }
}