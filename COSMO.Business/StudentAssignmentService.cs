using COSMO.Business.Abstractions;
using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
