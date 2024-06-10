namespace MediatRSample.Application.Handlers.Person;

using MediatR;
using MediatRSample.Application.Commands;
using MediatRSample.Application.Models;
using MediatRSample.Application.Notifications;
using MediatRSample.Application.Notifications.Person;
using MediatRSample.Repositories.Interfaces;

public class AlterPersonCommandHandler : IRequestHandler<AlterPersonCommand, string>
{
    private readonly IMediator _mediator;
    private readonly IRepository<Person> _repository;
    public AlterPersonCommandHandler(IMediator mediator, IRepository<Person> repository)
    {
        _mediator = mediator ?? throw new Exception();
        _repository = repository ?? throw new Exception();
    }

    public async Task<string> Handle(AlterPersonCommand request, CancellationToken cancellationToken)
    {
        var pessoa = new Person { Id = request.Id, Name = request.Name, Age = request.Age, Gender = request.Gender };

        try
        {
            await _repository.Edit(pessoa);

            await _mediator.Publish(new ChangedPersonNotification
            { 
                Id = pessoa.Id,
                Name = pessoa.Name,
                Age = pessoa.Age,
                Gender = pessoa.Gender, 
                IsEfective = true 
            });

            return await Task.FromResult("Updated person succesfully!");
        }
        catch (Exception ex)
        {
            await _mediator.Publish(new ChangedPersonNotification
            { 
                Id = pessoa.Id,
                Name = pessoa.Name,
                Age = pessoa.Age,
                Gender = pessoa.Gender,
                IsEfective = false 
            });

            await _mediator.Publish(new ErrorNotification 
            { 
                Exception = ex.Message, 
                Error = ex.StackTrace 
            });

            return await Task.FromResult("There was an error while attempting to alter person!");
        }
    }
}