using System.Text.Json;

namespace MyCollectionSite.Models;

public class CollectionRepository 
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


}
