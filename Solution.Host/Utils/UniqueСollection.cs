using System.Collections;

namespace Solution.Host.Utils;

public class UniqueСollection<T> : IEnumerable<T>
{
    private HashSet<T> _unique;

    public UniqueСollection()
    {
        _unique = new HashSet<T>();
    }

    public UniqueСollection(IEnumerable<T> values)
    {
        _unique = new HashSet<T>(values);
    }

    public int Count => _unique.Count;

    public bool Add(T item)
    {
        return _unique.Add(item);
    }

    public void Clear()
    {
        _unique.Clear();
    }

    public bool Contains(T item)
    {
        return _unique.Contains(item);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _unique.GetEnumerator();
    }

    public bool Remove(T item)
    {
        return _unique.Remove(item);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _unique.GetEnumerator();
    }
}