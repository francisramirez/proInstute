namespace proInstute.Web.Models.Department
{
    public class DepartmentUpdateDto : DepartmentBaseDto
    {
        public int DepartmentId { get; set; }
        public string? Name { get; set; }

        public decimal Budget { get; set; }

        public DateTime? StartDate { get; set; }

        public int? Administrator { get; set; }
       
    }
}
