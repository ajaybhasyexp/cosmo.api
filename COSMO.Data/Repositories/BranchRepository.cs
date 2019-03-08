using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using Microsoft.Extensions.Configuration;

namespace COSMO.Data.Repositories
{
    public class BranchRepository : GenericRepository<Branch>, IBranchRepository
    {

        /// <summary>
        /// THe constuctor that also contains the injected dependencies.
        /// </summary>
        /// <param name="config"></param>
        public BranchRepository(IConfiguration config)
            : base(config)
        {
        }



    }
}
