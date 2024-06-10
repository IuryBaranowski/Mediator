namespace MediatRSample.Application.Notifications.Person;

using MediatR;

public class CreatedPersonNotification : INotification
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public char Gender { get; set; }
}
