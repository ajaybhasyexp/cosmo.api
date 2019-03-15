using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using Microsoft.Extensions.Configuration;

namespace COSMO.Data.Repositories
{
    public class BatchAssignmentRepositoy : GenericRepository<BatchAssignment>, IBatchAssignmentRepository
    {
        public BatchAssignmentRepositoy(IConfiguration config)
            : base(config)
        {
        }
    }
}
