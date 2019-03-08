using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace COSMO.Data.Repositories
{
    /// <summary>
    /// The repository and methods for course entity.
    /// </summary>
    public class CourseRepository : ICourseRepository
    {
        #region Private Members

        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly IConfiguration _config;

        /// <summary>
        /// THe constuctor that also contains the injected dependencies.
        /// </summary>
        /// <param name="config"></param>
        public CourseRepository(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// The common property to get connection.
        /// </summary>
        private IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(_config.GetConnectionString("COSMODev"));
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets all the course entries in db.
        /// </summary>
        /// <returns></returns>
        public List<Course> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                return conn.GetAll<Course>().ToList();
            }
        }


        public Course Get(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                return conn.Get<Course>(id);
            }
        }

        /// <summary>
        /// Saves the course entity or updates it.
        /// </summary>
        /// <param name="course">The course entity to update.</param>
        /// <returns>The saved or updated entity.</returns>
        public Course Save(Course course)
        {
            using (var conn = Connection)
            {
                conn.Open();
                if (course.Id == 0)
                    conn.Insert(course);
                else
                    conn.Update(course);
                return course;
            }
        }

        #endregion
    }
}
