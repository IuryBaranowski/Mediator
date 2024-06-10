namespace MediatRSample.Application.Commands;

using MediatR;

public class RegisterPersonCommand : IRequest<string>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public char Gender { get; set; }
}
