namespace Generics;

public class Student : IHasId
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public Student(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
