namespace Generics;

public static class EnumerableExtensions
{
  
    public static IEnumerable<T> Page<T>(this IEnumerable<T> source, int pageNumber, int pageSize)
    {
        ArgumentNullException.ThrowIfNull(source);

        if (pageNumber < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number must be at least 1.");
        }

        if (pageSize < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be at least 1.");
        }

        return PageIterator(source, pageNumber, pageSize);
    }

    private static IEnumerable<T> PageIterator<T>(IEnumerable<T> source, int pageNumber, int pageSize)
    {
        int skipCount = (pageNumber - 1) * pageSize;
        int currentIndex = 0;
        int yieldedCount = 0;

        foreach (var item in source)
        {
            if (currentIndex >= skipCount)
            {
                yield return item;
                yieldedCount++;
                if (yieldedCount >= pageSize)
                {
                    yield break;
                }
            }
            currentIndex++;
        }
    }

    public static T? FindById<T>(this IEnumerable<T> source, int id) where T : IHasId
    {
        ArgumentNullException.ThrowIfNull(source);

        foreach (var item in source)
        {
            if (item != null && item.Id == id)
            {
                return item;
            }
        }

        return default;
    }

    public static IReadOnlyDictionary<int, T> ToIdDictionary<T>(this IEnumerable<T> source) where T : IHasId
    {
        ArgumentNullException.ThrowIfNull(source);

        var dict = new Dictionary<int, T>();

        foreach (var item in source)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(source), "Sequence cannot contain null items.");
            }

            if (dict.ContainsKey(item.Id))
            {
                throw new ArgumentException($"An item with Id {item.Id} already exists in the dictionary.", nameof(source));
            }

            dict.Add(item.Id, item);
        }

        return dict;
    }
}
