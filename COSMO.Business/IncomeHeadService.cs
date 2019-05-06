using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace COSMO.Business
{
    public class IncomeHeadService
    {
        #region Private Members

        /// <summary>
        /// The repository for branch entity.
        /// </summary>
        public IIncomeHeadRepository _incomeHeadRepository { get; set; }

        #endregion

        public IncomeHeadService(IIncomeHeadRepository incomeHeadRepository)
        {
            _incomeHeadRepository = incomeHeadRepository;

        }

        public IncomeHead Get(int id)
        {
            return _incomeHeadRepository.Get(id);
        }

        public List<IncomeHead> GetAll()
        {
            return _incomeHeadRepository.GetAll();
        }

        public IncomeHead Save(IncomeHead incomeHead)
        {
            return _incomeHeadRepository.Save(incomeHead);
        }
    }
}
