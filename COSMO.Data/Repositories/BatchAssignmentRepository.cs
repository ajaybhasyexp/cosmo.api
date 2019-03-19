using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using COSMO.Models.ViewModel;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace COSMO.Data.Repositories
{
    public class BatchAssignmentRepository : GenericRepository<BatchAssignment>, IBatchAssignmentRepository
    {
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

        public BatchAssignmentRepository(IConfiguration config)
            : base(config)
        {
            _config = config;
        }

        public List<BatchAssignVM> GetAssignVMs(int? branchId)
        {
            var sqlQuery = string.Empty;
            if (branchId.HasValue || branchId.Value != 0)
                sqlQuery = string.Format(Queries.BatchAssignment_get_filtered, branchId.Value);
            else
                sqlQuery = Queries.BatchAssignment_get;

            using (IDbConnection conn = Connection)
            {
                conn.Open();
                var result = conn.Query<BatchAssignVM>(sqlQuery);
                return result.ToList();
            }
        }
    }
}
