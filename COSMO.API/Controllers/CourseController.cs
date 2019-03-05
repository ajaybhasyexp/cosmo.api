using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using COSMO.Business.Abstractions;
using COSMO.Models.Models;

namespace COSMO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
         #region Private members

        /// <summary>
        /// The course service for busines methods.
        /// </summary>
        private ICourseService _courseService { get; set; }

        #endregion

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        #region Public Methods

        [HttpGet]
        public ResponseDto<List<Course>> GetAll()
        {
            ResponseDto<List<Course>> response = new ResponseDto<List<Course>>
            {
                Data = _courseService.GetAll()
            };
            return response;
        }

        [HttpGet]
        public ResponseDto<Course> Get(int id)
        {
            ResponseDto<Course> response = new ResponseDto<Course>
            {
                Data = _courseService.Get(id)
            };
            return response;
        }

        #endregion
    }
}