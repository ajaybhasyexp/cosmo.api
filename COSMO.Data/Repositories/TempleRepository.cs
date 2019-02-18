using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace COSMO.Data.Repositories
{
    public class TempleRepository : ITempleRepository
    {
        private readonly IConfiguration _config;

        public TempleRepository(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// The common property to get connection.
        /// </summary>
        public IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(_config.GetConnectionString("COSMODev"));
            }
        }

        public Task<List<Temple>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Temple> GetByID(int id)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM `Temples` where TempleId = 1";
                conn.Open();
                var result = await conn.QueryAsync<Temple>(sQuery);
                return result.FirstOrDefault();
            }
        }
    }
}
