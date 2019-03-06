using COSMO.Business.Abstractions;
using COSMO.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace COSMO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BatchController : ControllerBase
    {
        #region Private members

        /// <summary>
        /// The branch service for busines methods.
        /// </summary>
        private IBatchService _batchService { get; set; }

        #endregion

        /// <summary>
        /// Constructor for injection.
        /// </summary>
        /// <param name="branchServive">The branch service to inject.</param>
        public BatchController(IBatchService batchService)
        {
            _batchService = batchService;
        }

        /// <summary>
        /// Gets all the branch entities.
        /// </summary>
        /// <returns>A list of branch entity.</returns>
        [HttpGet]
        public ResponseDto<List<Batch>> GetAll()
        {
            ResponseDto<List<Batch>> response = new ResponseDto<List<Batch>>
            {
                Data = _batchService.GetAll()
            };
            return response;
        }

        /// <summary>
        /// Gets a branch entity by id.
        /// </summary>
        /// <param name="id">The id for branch</param>
        /// <returns>A branch entity.</returns>
        [HttpGet]
        [Route("{id}")]
        public ResponseDto<Batch> Get([FromRoute] int id)
        {
            ResponseDto<Batch> response = new ResponseDto<Batch>
            {
                Data = _batchService.Get(id)
            };
            return response;
        }

        /// <summary>
        /// The save/update method for branch
        /// </summary>
        /// <param name="branch"></param>
        /// <returns>A saved or updated branch entity.</returns>
        [HttpPost]
        [AllowAnonymous]
        public ResponseDto<Batch> Save([FromBody]Batch branch)
        {
            ResponseDto<Batch> response = new ResponseDto<Batch>();
            response.Data = _batchService.Save(branch);
            return response;
        }
    }
}