namespace MediatRSample.Application.EventHandlers;

using MediatR;
using MediatRSample.Application.Notifications;
using MediatRSample.Application.Notifications.Person;

public class LogEventHandler :
                        INotificationHandler<CreatedPersonNotification>,
                        INotificationHandler<ChangedPersonNotification>,
                        INotificationHandler<RemovedPersonNotification>,
                        INotificationHandler<ErrorNotification>
{
    public Task Handle(CreatedPersonNotification notification, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            Console.WriteLine($"Created: '{notification.Id} - {notification.Name} - {notification.Age} - {notification.Gender}'");
        });
    }

    public Task Handle(ChangedPersonNotification notification, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            Console.WriteLine($"Changed: '{notification.Id} - {notification.Name} - {notification.Age} - {notification.Gender} - {notification.IsEfective}'");
        });
    }

    public Task Handle(RemovedPersonNotification notification, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            Console.WriteLine($"Removed: '{notification.Id} - {notification.IsEfective}'");
        });
    }

    public Task Handle(ErrorNotification notification, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            Console.WriteLine($"ERRO: '{notification.Exception} \n {notification.Error}'");
        });
    }
}