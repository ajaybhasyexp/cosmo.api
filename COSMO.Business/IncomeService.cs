using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using System.Collections.Generic;

namespace COSMO.Business
{
    public class IncomeService
    {
        #region Private Members

        /// <summary>
        /// The repository for branch entity.
        /// </summary>
        public IIncomeRepository _incomeRepository { get; set; }

        #endregion

        public IncomeService(IIncomeRepository incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }

        /// <summary>
        /// Gets a single batchassignment entity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The batch assignment entity.</returns>
        public Income Get(int id)
        {
            return _incomeRepository.Get(id);
        }

        public List<Income> GetAll()
        {
            return _incomeRepository.GetAll();
        }

        public Income Save(Income assignment)
        {
            return _incomeRepository.Save(assignment);
        }

        public void Delete(Income batchAssignment)
        {
            _incomeRepository.Delete(batchAssignment);
        }
    }
}
