using COSMO.Models.Models;
using System.Collections.Generic;

namespace COSMO.Data.Abstractions.Repositories
{
    public interface IStudentAssignmentRepository : IGenericRepository<StudentAssignment>
    {
        List<StudentAssignment> GetAllVM(int branchId);

        /// <summary>
        /// Gets the list of students whose fees hasnt been paid.
        /// </summary>
        /// <returns>A list of Student objects that has the fees yet to pay.</returns>
        List<Student> GetUnpaidStudents();
    }
}
