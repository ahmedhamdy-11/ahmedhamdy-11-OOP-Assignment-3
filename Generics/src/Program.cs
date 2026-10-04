using Generics;

Console.WriteLine("==================================================");
Console.WriteLine("          Part 03: Generics - Demonstration       ");
Console.WriteLine("==================================================\n");

var studentStore = new Store<Student>();
studentStore.Add(new Student(1, "Ahmed"));
studentStore.Add(new Student(2, "Sara"));
studentStore.Add(new Student(3, "Omar"));
studentStore.Add(new Student(4, "Mona"));
studentStore.Add(new Student(5, "Youssef"));

var courseStore = new Store<Course>();
courseStore.Add(new Course(101, "C# Deep Dive", 150m));
courseStore.Add(new Course(102, "ASP.NET Core Web API", 250m));
courseStore.Add(new Course(103, "Clean Architecture & Design Patterns", 300m));

Console.WriteLine("[1] Getting one student and one course by ID:");
var student = studentStore.GetById(3);
Console.WriteLine($"Found Student: ID = {student?.Id}, Name = {student?.Name}");

var course = courseStore.GetById(102);
Console.WriteLine($"Found Course: ID = {course?.Id}, Title = '{course?.Title}', Price = ${course?.Price}\n");

Console.WriteLine("[2] Attempting to add a student with duplicate ID (ID = 1):");
try
{
    studentStore.Add(new Student(1, "Duplicate Ahmed"));
}
catch (Exception ex)
{
    Console.WriteLine($"Successfully caught exception: {ex.Message}\n");
}

Console.WriteLine("[3] Printing Page 2 (Size 2) of Students:");
var page2Students = studentStore.GetAll().Page(pageNumber: 2, pageSize: 2);
foreach (var s in page2Students)
{
    Console.WriteLine($" - Student ID: {s.Id}, Name: {s.Name}");
}

Console.WriteLine("\n[4] Calling FindById on a plain List<Course>:");
var courseList = new List<Course>
{
    new Course(201, "Data Structures & Algorithms", 180m),
    new Course(202, "Entity Framework Core In-Depth", 220m),
    new Course(203, "Microservices & Docker", 350m)
};

var foundCourse = courseList.FindById(202);
if (foundCourse != null)
{
    Console.WriteLine($"Found Course in List: ID = {foundCourse.Id}, Title = '{foundCourse.Title}', Price = ${foundCourse.Price}");
}
else
{
    Console.WriteLine("Course not found.");
}

Console.WriteLine("\n[5] Converting List<Course> to IReadOnlyDictionary via ToIdDictionary():");
var courseDict = courseList.ToIdDictionary();
Console.WriteLine($"Dictionary contains {courseDict.Count} courses. Lookup ID 201: {courseDict[201].Title}\n");


Console.WriteLine("==================================================");
Console.WriteLine("      All Step 7 requirements executed cleanly!   ");
Console.WriteLine("==================================================");
