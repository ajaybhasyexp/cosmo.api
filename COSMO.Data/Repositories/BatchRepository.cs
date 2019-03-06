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
    public class BatchRepository : IBatchRepository
    {
        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly IConfiguration _config;

        /// <summary>
        /// THe constuctor that also contains the injected dependencies.
        /// </summary>
        /// <param name="config"></param>
        public BatchRepository(IConfiguration config)
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

        #region Public Methods

        public Batch Get(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                return conn.Get<Batch>(id);
            }
        }

        public List<Batch> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                return conn.GetAll<Batch>().ToList();
            }
        }

        public Batch Save(Batch batch)
        {
            using (var conn = Connection)
            {
                conn.Open();
                if (batch.BatchId == 0)
                {
                    conn.Insert(batch);
                }
                else
                    conn.Update(batch);
                return batch;
            }
        }

        #endregion
    }
}
