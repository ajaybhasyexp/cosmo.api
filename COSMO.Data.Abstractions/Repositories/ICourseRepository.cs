using COSMO.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace COSMO.Data.Abstractions.Repositories
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        List<Course> GetAssignedCourses(int branchId);
    }
}
