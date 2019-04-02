using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace COSMO.Data.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRespository
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

        public StudentRepository(IConfiguration config)
            : base(config)
        {
            _config = config;
        }

        public List<Student> GetAllVM(int branchId)
        {
            throw new NotImplementedException();
        }
    }
}
