using COSMO.Business.Abstractions;
using COSMO.Models.Models;
using COSMO.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace COSMO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchAssignmentController : ControllerBase
    {
        #region Private members

        /// <summary>
        /// The branch service for busines methods.
        /// </summary>
        private IBatchAssignmentService _batchAssignmentService { get; set; }

        #endregion

        /// <summary>
        /// Constructor for injection.
        /// </summary>
        /// <param name="branchServive">The branch service to inject.</param>
        public BatchAssignmentController(IBatchAssignmentService batchAssignmentService)
        {
            _batchAssignmentService = batchAssignmentService;
        }

        /// <summary>
        /// Gets all the BatchAssignment entities.
        /// </summary>
        /// <returns>A list of BatchAssignment entity.</returns>
        [HttpGet]
        public ResponseDto<List<BatchAssignment>> GetAll()
        {
            ResponseDto<List<BatchAssignment>> response = new ResponseDto<List<BatchAssignment>>
            {
                Data = _batchAssignmentService.GetAll()
            };
            return response;
        }

        /// <summary>
        /// Gets a branch entity by id.
        /// </summary>
        /// <param name="id">The id for BatchAssignment</param>
        /// <returns>A BatchAssignment entity.</returns>
        [HttpGet]
        [Route("{id}")]
        public ResponseDto<BatchAssignment> Get([FromRoute] int id)
        {
            ResponseDto<BatchAssignment> response = new ResponseDto<BatchAssignment>
            {
                Data = _batchAssignmentService.Get(id)
            };
            return response;
        }

        /// <summary>
        /// The save/update method for BatchAssignment
        /// </summary>
        /// <param name="BatchAssignment"></param>
        /// <returns>A saved or updated BatchAssignment entity.</returns>
        [HttpPost]
        public ResponseDto<List<BatchAssignVM>> Save([FromBody]BatchAssignSaveVM assignments)
        {
            ResponseDto<List<BatchAssignVM>> response = new ResponseDto<List<BatchAssignVM>>();
            response.Data = _batchAssignmentService.Save(assignments);
            return response;
        }

        /// <summary>
        /// Deletes the BatchAssignment entity.
        /// </summary>
        /// <param name="BatchAssignment">The entity to delete.</param>
        [HttpDelete]
        public ResponseDto<bool> Delete([FromBody] BatchAssignment batchAssign)
        {
            ResponseDto<bool> response = new ResponseDto<bool>();
            try
            {
                _batchAssignmentService.Delete(batchAssign);
                response.Data = true;

            }
            catch
            {
                response.Data = false;
            }
            return response;
        }

        [HttpGet]
        [Route("all/{branchId}")]
        public ResponseDto<List<BatchAssignVM>> BatchAssigns(int branchId)
        {
            ResponseDto<List<BatchAssignVM>> response = new ResponseDto<List<BatchAssignVM>>();
            try
            {
                response.Data = _batchAssignmentService.GetVMs(branchId);
            }
            catch(Exception ex)
            {

            }
            return response;
        }
    }
}