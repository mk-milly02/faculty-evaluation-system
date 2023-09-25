namespace FacultyEvaluationSystem.Domain;

public class PagedList<T> where T : class
{
    public PagedList(IEnumerable<T> source, int size, int page)
    {
        Items = source.Skip((page - 1) * size).Take(size).ToList();
    }

    public List<T>? Items { get; }
}
