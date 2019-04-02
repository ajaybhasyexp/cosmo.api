using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COSMO.API.Resources;
using COSMO.Business.Abstractions;
using COSMO.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COSMO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        #region Private members

        /// <summary>
        /// The branch service for busines methods.
        /// </summary>
        private IStudentService _studentService { get; set; }

        /// <summary>
        /// The common resource file.
        /// </summary>
        private ICommonResource _commonResource { get; set; }

        #endregion

        /// <summary>
        /// Constructor for injection.
        /// </summary>
        /// <param name="branchServive">The branch service to inject.</param>
        public StudentController(IStudentService studentService, ICommonResource commonResource)
        {
            _studentService = studentService;
            _commonResource = commonResource;
        }

        /// <summary>
        /// The save/update method for branch
        /// </summary>
        /// <param name="branch"></param>
        /// <returns>A saved or updated branch entity.</returns>
        [HttpPost]
        public ResponseDto<Student> Save([FromBody]Student student)
        {
            ResponseDto<Student> response = new ResponseDto<Student>(_commonResource);
            try
            {
                response.Data = _studentService.Save(student);
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }
        }
    }
}