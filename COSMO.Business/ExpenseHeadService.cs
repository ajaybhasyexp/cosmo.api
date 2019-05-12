using COSMO.Business.Abstractions;
using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using System;
using System.Collections.Generic;

namespace COSMO.Business
{
    public class ExpenseHeadService : IExpenseHeadService
    {
        #region Private Members

        /// <summary>
        /// The repository for branch entity.
        /// </summary>
        public IExpenseHeadRepository _expenseHeadRepository { get; set; }

        #endregion

        /// <summary>
        /// The constructor for expenseheadservice.
        /// </summary>
        /// <param name="expenseHeadRepository"></param>
        public ExpenseHeadService(IExpenseHeadRepository expenseHeadRepository)
        {
            _expenseHeadRepository = expenseHeadRepository;

        }

        #region Public Methods

        public void Delete(ExpenseHead expenseHead)
        {
            _expenseHeadRepository.Delete(expenseHead);
        }

        public ExpenseHead Get(int id)
        {
            return _expenseHeadRepository.Get(id);
        }

        public List<ExpenseHead> GetAll()
        {
            return _expenseHeadRepository.GetAll();
        }

        public ExpenseHead Save(ExpenseHead expenseHead)
        {
            return _expenseHeadRepository.Save(expenseHead);
        }

        #endregion
    }
}
