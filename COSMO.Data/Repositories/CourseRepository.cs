using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using Microsoft.Extensions.Configuration;

namespace COSMO.Data.Repositories
{
    /// <summary>
    /// The repository and methods for course entity.
    /// </summary>
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        /// <summary>
        /// THe constuctor that also contains the injected dependencies.
        /// </summary>
        /// <param name="config"></param>
        public CourseRepository(IConfiguration config)
            : base(config)
        {

        }

    }
}
