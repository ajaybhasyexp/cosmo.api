using COSMO.API.Resources;
using COSMO.Business.Abstractions;
using COSMO.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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

        /// <summary>
        /// The common resource file.
        /// </summary>
        private ICommonResource _commonResource { get; set; }

        #endregion

        public CourseController(ICourseService courseService, ICommonResource commonResource)
        {
            _courseService = courseService;
            _commonResource = commonResource;
        }

        #region Public Methods

        [HttpGet]
        public ResponseDto<List<Course>> GetAll()
        {
            ResponseDto<List<Course>> response = new ResponseDto<List<Course>>(_commonResource);
            try
            {
                response.Data = _courseService.GetAll();
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ResponseDto<Course> Get(int id)
        {
            ResponseDto<Course> response = new ResponseDto<Course>(_commonResource);
            try
            {
                response.Data = _courseService.Get(id);
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }
        }

        [HttpGet]
        [Route("{id}/assigned")]
        public ResponseDto<List<Course>> GetAssigned(int id)
        {
            ResponseDto<List<Course>> response = new ResponseDto<List<Course>>(_commonResource);
            try
            {
                response.Data = _courseService.GetAssignedCourse(id);
                return response;
            }
            catch(Exception ex)
            {
                return response.HandleException(response);
            }
        }

        [HttpPost]
        public ResponseDto<Course> Save([FromBody] Course course)
        {
            ResponseDto<Course> response = new ResponseDto<Course>(_commonResource);
            try
            {
                response.Data = _courseService.Save(course);
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
            ResponseDto<bool> response = new ResponseDto<bool>(_commonResource);
            try
            {
                _courseService.Delete(course);
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }
        }

        #endregion
    }
}