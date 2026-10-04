namespace Generics;

public class Store<T> where T : IHasId
{
    private readonly Dictionary<int, T> _items = new();

    public void Add(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "Item cannot be null.");
        }

        if (_items.ContainsKey(item.Id))
        {
            throw new InvalidOperationException($"An item with Id {item.Id} already exists in the store.");
        }

        _items.Add(item.Id, item);
    }

    public T? GetById(int id)
    {
        return _items.TryGetValue(id, out var item) ? item : default;
    }

    public IReadOnlyCollection<T> GetAll()
    {
        return _items.Values;
    }

    public bool Remove(int id)
    {
        return _items.Remove(id);
    }
}
