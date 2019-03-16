using COSMO.Business.Abstractions;
using COSMO.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace COSMO.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        #region Private members

        /// <summary>
        /// The branch service for busines methods.
        /// </summary>
        private IBranchService _branchServive { get; set; }

        #endregion

        /// <summary>
        /// Constructor for injection.
        /// </summary>
        /// <param name="branchServive">The branch service to inject.</param>
        public BranchController(IBranchService branchServive)
        {
            _branchServive = branchServive;
        }
        

        /// <summary>
        /// Gets all the branch entities.
        /// </summary>
        /// <returns>A list of branch entity.</returns>
        [HttpGet]
        public ResponseDto<List<Branch>> GetAll()
        {
            ResponseDto<List<Branch>> response = new ResponseDto<List<Branch>>
            {
                Data = _branchServive.GetAll()
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
        public ResponseDto<Branch> Get([FromRoute] int id)
        {
            ResponseDto<Branch> response = new ResponseDto<Branch>
            {
                Data = _branchServive.Get(id)
            };
            return response;
        }

        /// <summary>
        /// The save/update method for branch
        /// </summary>
        /// <param name="branch"></param>
        /// <returns>A saved or updated branch entity.</returns>
        [HttpPost]
        public ResponseDto<Branch> Save([FromBody]Branch branch)
        {
            ResponseDto<Branch> response = new ResponseDto<Branch>();
            response.Data = _branchServive.Save(branch);
            return response;
        }

        /// <summary>
        /// Deletes the branch entity.
        /// </summary>
        /// <param name="branch">The entity to delete.</param>
        [HttpDelete]
        public ResponseDto<bool> Delete([FromBody] Branch branch)
        {
            ResponseDto<bool> response = new ResponseDto<bool>();
            try
            {
                _branchServive.Delete(branch);
                response.Data = true;
                
            }
            catch
            {
                response.Data = false;
            }
            return response;
        }
    }
}
