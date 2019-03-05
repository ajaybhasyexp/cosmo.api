using COSMO.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace COSMO.Data.Abstractions.Repositories
{
    public interface ICourseRepository
    {
        Course Save(Course course);

        List<Course> GetAll();

        Course Get(int id);
    }
}
