

namespace proInstute.Persistence.Models.Course
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public DateTime CreationDate { get; set; }


    }
}
