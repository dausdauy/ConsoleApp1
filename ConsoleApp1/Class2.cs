namespace ConsoleApp1
{
    public class Student
    {
        public int StudentId { get; set; }
        public int GradeId { get; set; }
        public Grade? Grade { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public TimeSpan CreatedOn { get; set; }
    }

    public class Course
    {
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public TimeSpan CreatedOn { get; set; }
    }

    public class Grade
    {
        public int GradeId { get; set; }
        public int GradeName { get; set; }
        public TimeSpan CreatedOn { get; set; }

        public IList<Student> Students { get; set; } = new List<Student>();
    }
}