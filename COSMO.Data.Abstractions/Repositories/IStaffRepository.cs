using COSMO.Models.Models;
using System.Collections.Generic;

namespace COSMO.Data.Abstractions.Repositories
{
    public interface IStaffRepository
    {
        List<StaffRole> GetAllRoles();        

        List<Staff> GetAll();

        StaffRole GetRole(int id);

        Staff Get(int id);

        StaffRole SaveRole(StaffRole course);

        Staff Save(Staff course);
    }
}
