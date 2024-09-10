
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
        /// Get Courses by department
        /// </summary>
        /// <param name="departmentId">departmentId</param>
        /// <returns>CourseModel</returns>
        Task<DataResult<List<CourseModel>>> GetCourseByDepartment(int departmentId);
    }

}
