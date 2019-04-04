﻿using System;
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
    public class StudentAssignController : ControllerBase
    {
        #region Private members

        /// <summary>
        /// The branch service for busines methods.
        /// </summary>
        private IStudentAssignmentService _studentAssignmentService { get; set; }

        /// <summary>
        /// The common resource file.
        /// </summary>
        private ICommonResource _commonResource { get; set; }

        #endregion

        /// <summary>
        /// Constructor for injection.
        /// </summary>
        /// <param name="branchServive">The branch service to inject.</param>
        public StudentAssignController(IStudentAssignmentService studentAssignmentService, ICommonResource commonResource)
        {
            _studentAssignmentService = studentAssignmentService;
            _commonResource = commonResource;
        }

        [HttpGet]
        [Route("{branchId}")]
        public ResponseDto<List<StudentAssignment>> GetAll([FromRoute] int branchId)
        {
            ResponseDto<List<StudentAssignment>> response = new ResponseDto<List<StudentAssignment>>(_commonResource);
            try
            {
                response.Data = _studentAssignmentService.GetAllVM(branchId);
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
        public ResponseDto<StudentAssignment> Save([FromBody]StudentAssignment assign)
        {
            ResponseDto<StudentAssignment> response = new ResponseDto<StudentAssignment>(_commonResource);
            try
            {
                response.Data = _studentAssignmentService.Save(assign);
                return response;
            }
            catch
            {
                return response.HandleException(response);
            }
        }
    }
}