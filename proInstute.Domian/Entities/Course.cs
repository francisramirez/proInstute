
using proInstute.Domian.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace proInstute.Domian.Entities
{
    [Table("Courses", Schema = "dbo")]
    public sealed class Course : AuditEntity<int>
    {
        [Key]
        [Column("CourseID")]
        public override int Id { get; set; }
        public string? Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
    }
}
