namespace MyCollectionSite.Models;

public interface ICollectionRepository
{
    CollectionItem FindById(int id);
    IEnumerable<CollectionItem> Get();
    int Vote(int id, bool direction);
}
