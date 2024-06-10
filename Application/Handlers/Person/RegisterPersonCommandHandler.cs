namespace MediatRSample.Application.Handlers.Person;

using MediatR;
using MediatRSample.Application.Commands;
using MediatRSample.Application.Models;
using MediatRSample.Application.Notifications;
using MediatRSample.Application.Notifications.Person;
using MediatRSample.Repositories.Interfaces;

public class RegisterPersonCommandHandler : IRequestHandler<RegisterPersonCommand, string>
{
    private readonly IMediator _mediator;
    private readonly IRepository<Person> _repository;
    public RegisterPersonCommandHandler(IMediator mediator, IRepository<Person> repository)
    {
        _mediator = mediator ?? throw new Exception();
        _repository = repository ?? throw new Exception();
    }

    public async Task<string> Handle(RegisterPersonCommand request, CancellationToken cancellationToken)
    {
        var person = new Person 
        { 
            Name = request.Name, 
            Age = request.Age,
            Gender = request.Gender 
        };

        try
        {
            await _repository.Add(person);

            await _mediator.Publish(new CreatedPersonNotification 
            { 
                Id = person.Id,
                Name = person.Name, 
                Age = person.Age, 
                Gender = person.Gender 
            });

            return await Task.FromResult("New person created!");
        }
        catch (Exception ex)
        {
            await _mediator.Publish(new CreatedPersonNotification 
            { 
                Id = person.Id,
                Name = person.Name,
                Age = person.Age,
                Gender = person.Gender 
            
            });

            await _mediator.Publish(new ErrorNotification 
            { 
                Exception = ex.Message, 
                Error = ex.StackTrace 
            });

            return await Task.FromResult("There was an error while attempt to create new person.");
        }
    }
}