using COSMO.Models.Models;
using System.Collections.Generic;

namespace COSMO.Data.Abstractions.Repositories
{
    public interface ICourseFeeRepository : IGenericRepository<CourseFee>
    {
        List<CourseFee> GetCourseFeeVM(int barnchId);
    }
}
