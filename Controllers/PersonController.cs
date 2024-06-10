namespace MediatRSample.Controllers;

using MediatR;
using MediatRSample.Application.Commands;
using MediatRSample.Application.Models;
using MediatRSample.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IRepository<Person> _repository;

    public PersonController(IMediator mediator, IRepository<Person> repository)
    {
        _mediator = mediator ?? throw new Exception();
        _repository = repository ?? throw new Exception();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _repository.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _repository.Get(id));
    }

    [HttpPost]
    public async Task<IActionResult> Post(RegisterPersonCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Put(AlterPersonCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var personCommand = new RemovePersonCommand 
        { 
            Id = id 
        };

        var result = await _mediator.Send(personCommand);

        return Ok(result);
    }
}
