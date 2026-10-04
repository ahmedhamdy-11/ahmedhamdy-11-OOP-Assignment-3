namespace Generics;

public class Course : IHasId
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public Course(int id, string title, decimal price)
    {
        Id = id;
        Title = title;
        Price = price;
    }
}
