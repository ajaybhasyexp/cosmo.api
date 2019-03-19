using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using COSMO.Business.Abstractions;
using Microsoft.AspNetCore.Authorization;
using COSMO.Models.Models;

namespace COSMO.API.Controllers
{
    //[Authorize]
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
        [Route("{id}")]
        public ResponseDto<Course> Get(int id)
        {
            ResponseDto<Course> response = new ResponseDto<Course>
            {
                Data = _courseService.Get(id)
            };
            return response;
        }

        [HttpPost]
        public ResponseDto<Course> Save([FromBody] Course course)
        {
            ResponseDto<Course> response = new ResponseDto<Course>();
            try
            {
                response = new ResponseDto<Course>
                {
                    Data = _courseService.Save(course),
                    IsSuccess = true,
                    Message = "Saved Successsfully."
                };
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }
        }

        /// <summary>
        /// The delete api method for course entity.
        /// </summary>
        /// <param name="course">The course entity.</param>
        /// <returns>A standard response object.</returns>
        [HttpDelete]
        public ResponseDto<bool> Delete([FromBody] Course course)
        {
            ResponseDto<bool> response = new ResponseDto<bool>();
            try
            {
                _courseService.Delete(course);
                response.Data = true;
                response.Message = "Deleted Successfully";
                return response;
            }
            catch (Exception ex)
            {
                return response.HandleException(response);
            }
        }

        #endregion
    }
}