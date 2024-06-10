namespace MediatRSample.Application.Commands;

using MediatR;

public class AlterPersonCommand : IRequest<string>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public char Gender { get; set; }
}
