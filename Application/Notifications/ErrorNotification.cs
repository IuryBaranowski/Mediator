namespace MediatRSample.Application.Notifications;

using MediatR;

public class ErrorNotification : INotification
{
    public string Exception { get; set; }
    public string Error { get; set; }
}