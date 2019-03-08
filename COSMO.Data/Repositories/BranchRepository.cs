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
    public class BranchRepository : IBranchRepository
    {
        #region Private Members

        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly IConfiguration _config;

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

        /// <summary>
        /// THe constuctor that also contains the injected dependencies.
        /// </summary>
        /// <param name="config"></param>
        public BranchRepository(IConfiguration config)
        {
            _config = config;
        }
        

        #region Public Methods

        /// <summary>
        /// Gets the branch entity based on id.
        /// </summary>
        /// <param name="id">The id to get the branch entity.</param>
        /// <returns>A single branch entity.</returns>
        public Branch Get(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                return conn.Get<Branch>(id);
            }
        }

        /// <summary>
        /// Gets all the branch entities.
        /// </summary>
        /// <returns>A list of branch entity.</returns>
        public List<Branch> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                return conn.GetAll<Branch>().ToList();
            }
        }

        /// <summary>
        /// Saves the branch entity.
        /// </summary>
        /// <param name="branch">Entity to save.</param>
        /// <returns>The saved entity.</returns>
        public Branch Save(Branch branch)
        {
            using (var conn = Connection)
            {
                conn.Open();
                if (branch.Id == 0)
                {
                    conn.Insert(branch);
                }
                else
                    conn.Update(branch);
                return branch;
            }
        }        

        #endregion
    }
}
