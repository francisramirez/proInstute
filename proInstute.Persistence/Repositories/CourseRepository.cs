

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using proInstute.Domian.Entities;
using proInstute.Domian.Models;
using proInstute.Persistence.Context;
using proInstute.Persistence.Interfaces;
using proInstute.Persistence.Models.Course;
using proInstute.Persistence.Repository;

namespace proInstute.Persistence.Repositories
{
    public class CourseRepository : BaseRepository<Course, int>, ICourseRepository
    {
        private readonly InstituteDb instituteDb;
        private readonly ILogger<CourseRepository> logger;
        private readonly IConfiguration configuration;

        public CourseRepository(InstituteDb instituteDb,
                                ILogger<CourseRepository> logger,
                                IConfiguration configuration) : base(instituteDb)
        {
            this.instituteDb = instituteDb;
            this.logger = logger;
            this.configuration = configuration;
        }

        public async Task<DataResult<List<CourseModel>>> GetCourseByDepartment(int departmentId)
        {
            DataResult<List<CourseModel>> result = new DataResult<List<CourseModel>>();

            try
            {
                var query = await (from course in this.instituteDb.Courses
                                           join depto in this.instituteDb.Departments on course.DepartmentID equals depto.Id
                                           where course.Deleted == false
                                            && course.Id == departmentId
                                           select new CourseModel()
                                           {
                                               CreationDate = course.CreationDate,
                                               Title = course.Title,
                                               Credits = course.Credits,
                                               DepartmentId = depto.Id,
                                               DepartmentName = depto.Name,
                                               Id = depto.Id
                                           }).ToListAsync();


                result.Result = query;
            }
            catch (Exception ex)
            {

                result.Message = this.configuration["course:get_course_department_id"];
                result.Success = false;
                this.logger.LogError(this.configuration["course:get_course_department_id"], ex.ToString());
            }
            return result;
        }

        public async Task<DataResult<CourseModel>> GetCourseByTitle(string title)
        {
            DataResult<CourseModel> result = new DataResult<CourseModel>();
            try
            {
                CourseModel? dato = await(from course in this.instituteDb.Courses
                                          join depto in this.instituteDb.Departments on course.DepartmentID equals depto.Id
                                          where course.Deleted == false
                                           && course.Title == title
                                          select new CourseModel()
                                          {
                                              CreationDate = course.CreationDate,
                                              Title = course.Title,
                                              Credits = course.Credits,
                                              DepartmentId = depto.Id,
                                              DepartmentName = depto.Name,
                                              Id = depto.Id
                                          }).FirstOrDefaultAsync();


                result.Result = dato;
            }
            catch (Exception ex)
            {

                result.Message = this.configuration["course:get_course_name"];
                result.Success = false;
                this.logger.LogError(this.configuration["course:get_course_name"], ex.ToString());

            }

            return result;
        }

        public async Task<DataResult<List<CourseModel>>> GetCourses()
        {
            DataResult<List<CourseModel>> result = new DataResult<List<CourseModel>>();

            try
            {
                var query = await(from course in this.instituteDb.Courses
                                  join depto in this.instituteDb.Departments on course.DepartmentID equals depto.Id
                                  where course.Deleted == false
                                  select new CourseModel()
                                  {
                                      CreationDate = course.CreationDate,
                                      Title = course.Title,
                                      Credits = course.Credits,
                                      DepartmentId = depto.Id,
                                      DepartmentName = depto.Name,
                                      Id = depto.Id
                                  }).ToListAsync();


                result.Result = query;
            }
            catch (Exception ex)
            {

                result.Message = this.configuration["course:get_courses"];
                result.Success = false;
                this.logger.LogError(this.configuration["course:get_courses"], ex.ToString());
            }
            return result;
        }
        public override Task<bool> Save(Course entity)
        {
            return base.Save(entity);
        }
        public override Task<bool> Update(Course entity)
        {
            return base.Update(entity);
        }
    }
}
