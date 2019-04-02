﻿using COSMO.Models.Models;
using System.Collections.Generic;

namespace COSMO.Data.Abstractions.Repositories
{
    public interface IStudentRespository : IGenericRepository<Student>
    {
        List<Student> GetAllVM(int branchId);
    }
}
