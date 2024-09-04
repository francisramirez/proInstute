
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using proInstute.Domian.Entities;
using proInstute.Domian.Models;
using proInstute.Persistence.Context;
using proInstute.Persistence.Exceptions;
using proInstute.Persistence.Interfaces;
using proInstute.Persistence.Models.Department;
using proInstute.Persistence.Repository;

namespace proInstute.Persistence.Repositories
{
    public sealed class DepartmentRepository : BaseRepository<Department, int>, IDepartmentRepository
    {
        private readonly InstituteDb instituteDb;
        private readonly ILogger<DepartmentRepository> logger;
        private readonly IConfiguration configuration;

        public DepartmentRepository(InstituteDb instituteDb,
                                    ILogger<DepartmentRepository> logger,
                                    IConfiguration configuration) : base(instituteDb)
        {
            this.instituteDb = instituteDb;
            this.logger = logger;
            this.configuration = configuration;
        }

        public async Task<DataResult<List<DepartmentModel>>> GetDepartments()
        {
            DataResult<List<DepartmentModel>> result = new DataResult<List<DepartmentModel>>();
            try
            {
                var departments = await (from depto in this.instituteDb.Departments
                                   where depto.Deleted == false
                                   select new DepartmentModel
                                   {
                                       DepartmentId = depto.Id,
                                       Budget = depto.Budget,
                                       StartDate = depto.StartDate.Value,
                                       Name = depto.Name
                                   }).ToListAsync();

                
                result.Result = departments;

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this.configuration["deparment:error_get_departments"];
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public async Task<DataResult<DepartmentModel>> GetDepartments(string name)
        {
            DataResult<DepartmentModel> result = new DataResult<DepartmentModel>();
            try
            {
                var department = await this.instituteDb.Departments
                                                       .SingleOrDefaultAsync(depto => depto.Name == name
                                                                             && depto.Deleted == false);

                result.Result = new DepartmentModel()
                {
                    DepartmentId = department.Id,
                    Budget = department.Budget,
                    Name = name, 
                    StartDate = department.StartDate.Value,    
                };
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = this.configuration["deparment:error_get_department_name"];
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public override async Task<bool> Save(Department entity)
        {
            bool result = false;

            try
            {
                if (entity == null)
                    throw new ArgumentNullException(this.configuration["department:entity"]);

                if (await base.Exists(depto => depto.Name == entity.Name))
                    throw new DepartmentDataException(this.configuration["department:name_exists"]);


                if (string.IsNullOrEmpty(entity.Name))
                    throw new DepartmentDataException(this.configuration["department:name_is_null"]);

                if (entity.Name.Length > 50)
                    throw new DepartmentDataException(this.configuration["department:name_length"]);

                if (!entity.StartDate.HasValue)
                    throw new DepartmentDataException(this.configuration["department:start_date_is_null"]);


                result = await base.Save(entity);
            }
            catch (Exception ex)
            {
                result = false;
                this.logger.LogError(this.configuration["deparment:error_save"], ex.ToString());
            }
            return result;
        }
        public override async Task<bool> Update(Department entity)
        {
            bool result = false;
            try
            {

                if (entity == null)
                    throw new ArgumentNullException(this.configuration["department:entity"]);

                if (string.IsNullOrEmpty(entity.Name))
                    throw new DepartmentDataException(this.configuration["department:name_is_null"]);

                if (entity.Name.Length > 50)
                    throw new DepartmentDataException(this.configuration["department:name_length"]);

                if (!entity.StartDate.HasValue)
                    throw new DepartmentDataException(this.configuration["department:start_date_is_null"]);


                result = await base.Update(entity);

            }
            catch (Exception ex)
            {

                result = false;
                this.logger.LogError(this.configuration["deparment:error_update"], ex.ToString());
            }
            return result;
        }
    }
}
