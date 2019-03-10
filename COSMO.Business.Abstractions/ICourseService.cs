using COSMO.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

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

        Course Get(int id);

        void Delete(Course course);
    }
}
