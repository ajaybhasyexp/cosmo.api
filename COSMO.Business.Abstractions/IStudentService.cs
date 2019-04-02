using COSMO.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace COSMO.Business.Abstractions
{
    public interface IStudentService
    {
        Student Save(Student student);

        List<Student> GetAll();

        List<Source> GetSources();

        List<Qualification> GetQualifications();

        List<Profession> GetProfessions();

    }
}
