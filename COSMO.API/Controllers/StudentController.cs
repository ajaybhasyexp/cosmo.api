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

        [HttpGet]
        [Route("{branchId}/all")]
        public ResponseDto<List<Student>> GetAll([FromRoute] int branchId)
        {
            ResponseDto<List<Student>> response = new ResponseDto<List<Student>>(_commonResource);
            try
            {
                response.Data = _studentService.GetAll(branchId);
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }

        }

        [HttpGet]
        [Route("{studentId}")]
        public ResponseDto<Student> Get([FromRoute] int studentId)
        {
            ResponseDto<Student> response = new ResponseDto<Student>(_commonResource);
            try
            {
                response.Data = _studentService.Get(studentId);
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }

        }

        [HttpGet]
        [Route("sources")]
        public ResponseDto<List<Source>> GetSources()
        {
            ResponseDto<List<Source>> response = new ResponseDto<List<Source>>(_commonResource);
            try
            {
                response.Data = _studentService.GetSources();
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }

        }

        [HttpGet]
        [Route("qualifications")]
        public ResponseDto<List<Qualification>> GetQualifications()
        {
            ResponseDto<List<Qualification>> response = new ResponseDto<List<Qualification>>(_commonResource);
            try
            {
                response.Data = _studentService.GetQualifications();
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }

        }

        [HttpGet]
        [Route("professions")]
        public ResponseDto<List<Profession>> GetProfessions()
        {
            ResponseDto<List<Profession>> response = new ResponseDto<List<Profession>>(_commonResource);
            try
            {
                response.Data = _studentService.GetProfessions();
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }

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