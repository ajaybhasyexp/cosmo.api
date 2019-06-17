using COSMO.Models.Models;
using System.Collections.Generic;

namespace COSMO.Business.Abstractions
{
    public interface IStudentAssignmentService
    {
        StudentAssignment Save(StudentAssignment studentAssignment);

        /// <summary>
        /// Gets a list of students whose fees are not paid.
        /// </summary>
        /// <returns>A list of students.</returns>
        List<Student> GetUnpaidStudents();

        List<StudentAssignment> GetAllVM(int branchId);

        void Delete(StudentAssignment assign);
    }
}
