using COSMO.Models.Models;
using System.Collections.Generic;

namespace COSMO.Business.Abstractions
{
    /// <summary>
    /// Abstraction for course interfaces.
    /// </summary>
    public interface ICourseService
    {
        /// <summary>
        /// Saves or updates the course
        /// </summary>
        /// <param name="course">The course entity to be saved.</param>
        /// <returns>The saved or updated course.</returns>
        Course Save(Course course);

        /// <summary>
        /// Gets all the courses.
        /// </summary>
        /// <returns>A list of courses.</returns>
        List<Course> GetAll();

        /// <summary>
        /// Gets the course based on the identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Course Get(int id);

        /// <summary>
        /// Deletes the course entity.
        /// </summary>
        /// <param name="course"></param>
        void Delete(Course course);

        /// <summary>
        /// Gets the courses assigned to branch.
        /// </summary>
        /// <param name="baranchId">The branch identfier.</param>
        /// <returns>A list of courses.</returns>
        List<Course> GetAssignedCourse(int branchId);
    }
}
