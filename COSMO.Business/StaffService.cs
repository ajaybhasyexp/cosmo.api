using COSMO.Business.Abstractions;
using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace COSMO.Business
{
    public class StaffService : IStaffService
    {
        #region Private Members

        /// <summary>
        /// The repository for branch entity.
        /// </summary>
        public IStaffRepository _staffRepository { get; set; }

        #endregion

        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;

        }

        public Staff Get(int id)
        {
            return _staffRepository.Get(id);
        }

        public List<Staff> GetAll()
        {
            return _staffRepository.GetAll();
        }

        public List<StaffRole> GetAllRoles()
        {
            return _staffRepository.GetAllRoles();
        }

        public StaffRole GetRole(int id)
        {
            return _staffRepository.GetRole(id);
        }

        public Staff Save(Staff course)
        {
            throw new NotImplementedException();
        }

        public StaffRole SaveRole(StaffRole course)
        {
            throw new NotImplementedException();
        }
    }
}
