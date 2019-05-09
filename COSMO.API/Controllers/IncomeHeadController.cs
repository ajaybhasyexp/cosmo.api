using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COSMO.API.Resources;
using COSMO.Business.Abstractions;
using COSMO.Models.Exceptions;
using COSMO.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COSMO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeHeadController : ControllerBase
    {
        #region Private members

        /// <summary>
        /// The branch service for busines methods.
        /// </summary>
        private IIncomeHeadService _incomeHeadService { get; set; }

        /// <summary>
        /// The common resource file.
        /// </summary>
        private ICommonResource _commonResource { get; set; }

        #endregion

        /// <summary>
        /// Constructor for injection.
        /// </summary>
        /// <param name="branchServive">The branch service to inject.</param>
        public IncomeHeadController(IIncomeHeadService incomeHeadService, ICommonResource commonResource)
        {
            _incomeHeadService = incomeHeadService;
            _commonResource = commonResource;
        }

        /// <summary>
        /// The save/update method for BatchAssignment
        /// </summary>
        /// <param name="BatchAssignment"></param>
        /// <returns>A saved or updated BatchAssignment entity.</returns>
        [HttpPost]
        public ResponseDto<IncomeHead> Save([FromBody]IncomeHead incomeHead)
        {
            ResponseDto<IncomeHead> response = new ResponseDto<IncomeHead>(_commonResource);
            try
            {
                response.Data = _incomeHeadService.Save(incomeHead);
                return response;
            }
            catch (CosmoBusinessException ex)
            {
                return response.HandleCustomException(response, ex);
            }
            catch
            {
                return response.HandleException(response);
            }
        }

        /// <summary>
        /// Gets a branch entity by id.
        /// </summary>
        /// <param name="id">The id for BatchAssignment</param>
        /// <returns>A BatchAssignment entity.</returns>
        [HttpGet]        
        public ResponseDto<List<IncomeHead>> Get()
        {
            ResponseDto<List<IncomeHead>> response = new ResponseDto<List<IncomeHead>>(_commonResource);
            try
            {
                response.Data = _incomeHeadService.GetAll();
                response.IsSuccess = true;
            }
            catch(Exception ex)
            {
                return response.HandleException(response);
            }
            return response;
        }
    }
}