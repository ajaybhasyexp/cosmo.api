using COSMO.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace COSMO.Business.Abstractions
{
    public interface IStudentAssignmentService
    {
        StudentAssignment Save(StudentAssignment studentAssignment);

        List<StudentAssignment> GetAllVM(int branchId);
    }
}
