namespace MediatRSample.Application.Notifications.Person;

using MediatR;

public class ChangedPersonNotification : INotification
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public char Gender { get; set; }
    public bool IsEfective { get; set; }
}
