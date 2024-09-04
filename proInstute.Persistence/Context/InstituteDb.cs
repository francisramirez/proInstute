

using Microsoft.EntityFrameworkCore;
using proInstute.Domian.Entities;

namespace proInstute.Persistence.Context
{
    public class InstituteDb : DbContext
    {
        public InstituteDb(DbContextOptions<InstituteDb> options):base(options)
        {
            
        }

        public DbSet<Department> Departments { get; set; }  
        public DbSet<Course> Courses { get; set; }
    }
}
