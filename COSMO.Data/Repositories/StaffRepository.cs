using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace COSMO.Data.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        #region Private Members

        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly IConfiguration _config;

        /// <summary>
        /// THe constuctor that also contains the injected dependencies.
        /// </summary>
        /// <param name="config"></param>
        public StaffRepository(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// The common property to get connection.
        /// </summary>
        private IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(_config.GetConnectionString("COSMODev"));
            }
        }

        #endregion

        #region Public Methods        

        public List<Staff> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                return conn.GetAll<Staff>().ToList();
            }
        }

        public List<StaffRole> GetAllRoles()
        {
            using (var conn = Connection)
            {
                conn.Open();
                return conn.GetAll<StaffRole>().ToList();
            }
        }

        public Staff Get(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                return conn.Get<Staff>(id);
            }
        }

        public StaffRole GetRole(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                return conn.Get<StaffRole>(id);
            }
        }

        /// <summary>
        /// Creates or updates a staff entity.
        /// </summary>
        /// <param name="staff">A staff object to be saved or updated</param>
        /// <returns>A saved or updated staff entity.</returns>
        public Staff Save(Staff staff)
        {
            using (var conn = Connection)
            {
                conn.Open();
                if (staff.Id == 0)
                    conn.Insert(staff);
                else
                    conn.Update(staff);
                return staff;
            }
        }

        /// <summary>
        /// Inserts or updates a staff role.
        /// </summary>
        /// <param name="staffRole">The staff role entity to update or save</param>
        /// <returns>The saved or updated staff role entity.</returns>
        public StaffRole SaveRole(StaffRole staffRole)
        {
            using (var conn = Connection)
            {
                conn.Open();
                if (staffRole.Id == 0)
                    conn.Insert(staffRole);
                else
                    conn.Update(staffRole);
                return staffRole;
            }
        }

        #endregion
    }
}
