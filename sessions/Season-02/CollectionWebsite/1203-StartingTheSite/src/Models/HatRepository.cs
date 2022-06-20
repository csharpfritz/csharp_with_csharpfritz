using System.Text.Json;

namespace MyCollectionSite.Models;

public class HatRepository 
{

    public IEnumerable<CollectionItem> Get()
    {

        using var jsonFile = System.IO.
            File.OpenRead("Data/collection.json");
        
        return JsonSerializer
            .Deserialize<CollectionItem[]>(jsonFile);

    }


}