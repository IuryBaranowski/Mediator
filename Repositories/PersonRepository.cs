namespace MediatRSample.Repositories;

using MediatRSample.Application.Models;
using MediatRSample.Repositories.Interfaces;

public class PersonRepository : IRepository<Person>
{
    private static Dictionary<int, Person> Persons = new Dictionary<int, Person>();

    public async Task<IEnumerable<Person>> GetAll()
    {
        return await Task.Run(() => Persons.Values.ToList());
    }

    public async Task<Person> Get(int id)
    {
        return await Task.Run(() => Persons.GetValueOrDefault(id));
    }

    public async Task Add(Person person)
    {
        await Task.Run(() => Persons.Add(person.Id, person));
    }

    public async Task Edit(Person person)
    {
        await Task.Run(() =>
        {
            Persons.Remove(person.Id);
            Persons.Add(person.Id, person);
        });
    }

    public async Task Delete(int id)
    {
        await Task.Run(() => Persons.Remove(id));
    }
}
