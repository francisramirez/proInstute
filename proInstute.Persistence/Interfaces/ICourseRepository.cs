
using System.Linq.Expressions;
using proInstute.Domian.Entities;
using proInstute.Domian.Interfaces;
using proInstute.Domian.Models;
using proInstute.Persistence.Models.Course;


namespace proInstute.Persistence.Interfaces
{
    public interface ICourseRepository : IRepository<Course, int>
    {
        /// <summary>
        /// Get all Courses.
        /// </summary>
        /// <returns></returns>
        Task<DataResult<List<CourseModel>>> GetCourses();
        /// <summary>
        /// Get department by title
        /// </summary>
        /// <param title="title">Title of course</param>
        /// <returns></returns>
        Task<DataResult<CourseModel>> GetCourseByTitle(string title);

        /// <summary>
        /// Get all courses by department name
        /// </summary>
        /// <param name="departmentName">Department of course</param>
        /// <returns></returns>
        Task<DataResult<CourseModel>> GetCourseByName(string departmentName);
    }

}
