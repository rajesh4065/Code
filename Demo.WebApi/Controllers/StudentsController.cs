using Demo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Common.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        [HttpGet("StudentsData")]
        public async Task<IActionResult> Get()
        {
            try
            {
                this._logger.LogDebug($"Called Method: {nameof(StudentsController)}/{nameof(this.Get)}");
                var result = await _studentService.GetStudents();
                return this.Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Exception: {nameof(StudentsController)}/{nameof(this.Get)}: {ex.Message}");
                throw;
            }
        }

        [HttpPost("AddData")]
        public async Task<IActionResult> AddStudentsData([FromBody] CreateStudentDto createCaseDto)
        {

            this._logger.LogDebug($"Called Method: {nameof(StudentsController)}/{nameof(this.AddStudentsData)}");
            var result = await _studentService.AddStudent(createCaseDto);
            return this.Ok(result);
        }

        [HttpPost("AddCourse")]
        public async Task<IActionResult> AddCourseData([FromBody] CreateCourseDto createCaseDto)
        {

            this._logger.LogDebug($"Called Method: {nameof(StudentsController)}/{nameof(this.AddCourseData)}");
            var result = await _studentService.AddCourse(createCaseDto);
            return this.Ok(result);
        }
    }
}
