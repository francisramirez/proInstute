

using proInstute.Domian.Entities;
using proInstute.Domian.Interfaces;
using proInstute.Domian.Models;
using proInstute.Persistence.Models.Department;

namespace proInstute.Persistence.Interfaces
{
    public interface IDepartmentRepository : IRepository<Department, int>
    {
        Task<DataResult<List<DepartmentModel>>> GetDepartments();
        Task<DataResult<DepartmentModel>> GetDepartments(string name);
    }
}
