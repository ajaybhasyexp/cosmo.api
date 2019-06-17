using COSMO.Business.Abstractions;
using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using System.Collections.Generic;

namespace COSMO.Business
{
    public class StudentAssignmentService : IStudentAssignmentService
    {
        #region Private Members

        /// <summary>
        /// The repository for branch entity.
        /// </summary>
        public IStudentAssignmentRepository _studentAssignmentRepository { get; set; }

        #endregion

        public StudentAssignmentService(IStudentAssignmentRepository studentAssignmentRepository)
        {
            _studentAssignmentRepository = studentAssignmentRepository;

        }

        /// <summary>
        /// Gets a list of students whose fees are not paid.
        /// </summary>
        /// <returns>A list of students.</returns>
        public List<Student> GetUnpaidStudents()
        {
            return _studentAssignmentRepository.GetUnpaidStudents();
        }

        public List<StudentAssignment> GetAllVM(int branchId)
        {
            return _studentAssignmentRepository.GetAllVM(branchId);
        }

        public StudentAssignment Save(StudentAssignment studentAssignment)
        {
            return _studentAssignmentRepository.Save(studentAssignment);
        }

        public void Delete(StudentAssignment assign)
        {
            _studentAssignmentRepository.Delete(assign);
        }
    }
}
