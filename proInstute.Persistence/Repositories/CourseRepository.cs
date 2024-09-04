

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

        public Task<DataResult<CourseModel>> GetCourseByName(string departmentName)
        {
            throw new NotImplementedException();
        }

        public Task<DataResult<CourseModel>> GetCourseByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public Task<DataResult<List<CourseModel>>> GetCourses()
        {
            throw new NotImplementedException();
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
