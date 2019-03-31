using COSMO.Models.Models;
using System.Collections.Generic;

namespace COSMO.Business.Abstractions
{
    public interface ICourseFeeService
    {
        CourseFee Get(int id);

        List<CourseFee> GetAll(int branchId);

        CourseFee Save(CourseFee courseFee);

        void Delete(CourseFee courseFee);
    }
}
