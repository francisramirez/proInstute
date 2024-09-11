namespace proInstute.Api.Models.Department
{
    public record DepartmentSaveDto
    {
        public string? Name { get; set; }

        public decimal Budget { get; set; }

        public DateTime? StartDate { get; set; }

        public int? Administrator { get; set; }

        public DateTime CreeateDate { get; set; }
        public int CreationUser { get; set; }

    }
}
