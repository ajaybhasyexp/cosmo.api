using COSMO.Models.Models;
using System.Threading.Tasks;

namespace COSMO.Data.Abstractions.Repositories
{
    public interface IBranchRepository
    {
        Task<Branch> Save(Branch branch);
    }
}
