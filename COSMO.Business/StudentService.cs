using System.Collections.Generic;
using COSMO.Business.Abstractions;
using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;

namespace COSMO.Business
{
    public class StudentService : IStudentService
    {
        #region Private Members

        /// <summary>
        /// The course repository for data operations.
        /// </summary>
        public IStudentRespository _studentRespository { get; set; }

        #endregion

        /// <summary>
        /// The construfctor for course service.
        /// </summary>
        /// <param name="courseRepository">The course repository to inject.</param>
        public StudentService(IStudentRespository studentRespository)
        {
            _studentRespository = studentRespository;
        }

        public Student Save(Student student)
        {
            return _studentRespository.Save(student);
        }

        public List<Student> GetAll()
        {
            return _studentRespository.GetAll();
        }

        public List<Source> GetSources()
        {
            return _studentRespository.GetSources();
        }

        public List<Qualification> GetQualifications()
        {
            return _studentRespository.GetQualifications();
        }

        public List<Profession> GetProfessions()
        {
            return _studentRespository.GetProfessions();
        }
    }
}
