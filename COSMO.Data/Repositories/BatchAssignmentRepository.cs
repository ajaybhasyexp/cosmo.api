using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using COSMO.Models.ViewModel;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
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

        #region Private Methods

        private BatchAssignment SaveWithCheck(BatchAssignment batchAssignment)
        {
            using (var conn = Connection)
            {
                conn.Open();
                string query = string.Format(Queries.BatchAssignmentFetch, batchAssignment.CourseId, batchAssignment.BatchId, batchAssignment.BranchId);
                var assignment = conn.QueryFirstOrDefault<BatchAssignment>(query);
                if (assignment == null)
                {
                    batchAssignment.CreatedDate = DateTime.Now;
                    batchAssignment.UpdatedDate = DateTime.Now;
                    conn.Insert(batchAssignment);
                }
                return assignment;
            }
        }

        #endregion

        public List<BatchAssignVM> GetAssignVMs(int branchId)
        {
            var sqlQuery = string.Empty;
            if (branchId != 0)
                sqlQuery = string.Format(Queries.BatchAssignment_get_filtered, branchId);
            else
                sqlQuery = Queries.BatchAssignment_get;

            using (IDbConnection conn = Connection)
            {
                conn.Open();
                var result = conn.Query<BatchAssignVM>(sqlQuery);
                return result.ToList();
            }
        }

        public List<BatchAssignVM> SaveBatchAssignVMs(BatchAssignSaveVM batchAssignSave)
        {

            if (batchAssignSave.Batches.Count != 0)
            {
                foreach (var batch in batchAssignSave.Batches)
                {
                    BatchAssignment assign = new BatchAssignment()
                    {
                        BatchId = batch.Id,
                        BranchId = batchAssignSave.BranchId,
                        CourseId = batchAssignSave.CourseId
                    };
                    Save(assign);
                }
            }
            if (batchAssignSave.IsBranchWise)
                return GetAssignVMs(batchAssignSave.BranchId);
            else
                return GetAssignVMs(0);
        }

        
    }
}
