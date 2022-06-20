using System.Text.Json;

namespace MyCollectionSite.Models;

public class CollectionItemRepository 
{
    private readonly CollectionContext _Context;

    public CollectionItemRepository(CollectionContext ctx)
    {
        _Context = ctx;
    }

    public IEnumerable<CollectionItem> Get()
    {
        return _Context.CollectionItems;
    }


}





