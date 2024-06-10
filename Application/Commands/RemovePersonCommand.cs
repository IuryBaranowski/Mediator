namespace MediatRSample.Application.Commands;

using MediatR;

public class RemovePersonCommand : IRequest<string>
{
    public int Id { get; set; }
}
