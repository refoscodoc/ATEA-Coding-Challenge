using System.Diagnostics;
using ATEA_coding_challenge.Models;
using Persistence.Repositories.Interfaces;

namespace ATEA_coding_challenge.Services;

public class BusinessLayer
{
    private readonly IAteaChallengeRepository _repository;
    public BusinessLayer(IAteaChallengeRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> SaveEntries(string[] args)
    {
        await _repository.SaveAll(args);
        return true;
    }

    public async Task<List<DatabaseEntry>> ReadDbEntries()
    {
        var elements = await _repository.Get();
        Console.WriteLine("===========================");
        Console.WriteLine("Latest 5 entries added: " + elements.Count);
        foreach (var element in elements.Select((value, i) => new { i, value}))
        {
            Console.WriteLine(
                (element.i + 1) + "\t" + element.value.Entry 
                + "\t" + element.value.Timestamp 
                + "\t" + element.value.Id);
        }
        Console.WriteLine("===========================");
        return elements;
    }

    public async Task FindEntryById()
    {
        var elements = await ReadDbEntries();
        Console.WriteLine("Select an entry by index (1~5)");
        var index = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("===========================");
        Console.WriteLine("Fetching data for element: " + elements.ElementAt(index - 1).Id);
        Console.WriteLine("===========================");
        var selection = await _repository.GetById(elements.ElementAt(index - 1).Id);
        Console.WriteLine("===========================");
        Console.WriteLine($"The selected item is: \n{selection.Entry}, created on {selection.Timestamp}");
        Console.WriteLine("===========================");
    }
}