
using proInstute.Domian.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace proInstute.Domian.Entities
{
    [Table("Departments", Schema = "dbo")]
    public sealed class Department : AuditEntity<int>
    {
        [Key]
        [Column("DepartmentID")]
        public override int Id { get; set; }

        public string? Name { get; set; }

        public decimal Budget { get; set; }

        public DateTime? StartDate { get; set; }

        public int? Administrator { get; set; }
    }
}
