using COSMO.Models.Models;
using System.Collections.Generic;

namespace COSMO.Data.Abstractions.Repositories
{
    public interface IStudentAssignmentRepository : IGenericRepository<StudentAssignment>
    {
        List<StudentAssignment> GetAllVM(int branchId);
    }
}
