namespace proInstute.Api.Models.Department
{
    public class DepartmentUpdateDto
    {
        public int DepartmentId { get; set; }
        public string? Name { get; set; }

        public decimal Budget { get; set; }

        public DateTime? StartDate { get; set; }

        public int? Administrator { get; set; }
        public DateTime ModifyDate { get; set; }
        public int ModifyUser { get; set; }
    }
}
