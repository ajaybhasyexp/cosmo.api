using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace COSMO.Data.Repositories
{
    public class StudentAssignmentRepository : GenericRepository<StudentAssignment>, IStudentAssignmentRepository
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

        public StudentAssignmentRepository(IConfiguration config) : base(config)
        {
            _config = config;
        }

        public List<StudentAssignment> GetAllVM(int branchId)
        {
            using (IDbConnection conn = Connection)
            {
                return conn.Query<StudentAssignment>("getStudentAssignments", new { branchid = branchId },
                commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
