namespace MediatRSample.Application.Notifications.Person;

using MediatR;

public class RemovedPersonNotification : INotification
{
    public int Id { get; set; }
    public bool IsEfective { get; set; }
}