using System.Collections.Concurrent;
using System.Text.Json;

namespace MyCollectionSite.Models;

public class CollectionRepository : ICollectionRepository
{
    private readonly CollectionContext _context;

    public CollectionRepository(CollectionContext context)
    {
        _context = context;
    }

    public IEnumerable<CollectionItem> Get()
    {

        return _context.CollectionItems.ToArray();

    }

    public CollectionItem FindById(int id)
    {

        var outputValue = _context.CollectionItems
            .FirstOrDefault(i => i.Id == id);

        if (outputValue == null) return CollectionItem.NotFound;

        return outputValue;

    }

    public int Vote(int id, bool direction)
    {

        var item = FindById(id);
        if (item == CollectionItem.NotFound) return 0;

        System.Console.WriteLine($"Voting for {item.Name}");

        if (direction) item.Votes++;
        else item.Votes--;

        _context.CollectionItems.Update(item);
        _context.SaveChanges();

        return item.Votes;

    }

}
