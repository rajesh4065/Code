using Demo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Demo.Common.Dtos;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Demo.WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SecurityController : ControllerBase
    {
        private readonly IStudentService _studentService;

        private readonly ILogger<SecurityController> _logger;

        public SecurityController(ILogger<SecurityController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        [HttpGet]
        public string Get()
        {
            return GenerateJSONWebToken("Raj");
        }

        [HttpPost("AddData")]
        public async Task<IActionResult> AddStudentsData([FromBody] CreateStudentDto createCaseDto)
        {

            this._logger.LogDebug($"Called Method: {nameof(SecurityController)}/{nameof(this.AddStudentsData)}");
            var result = await _studentService.AddStudent(createCaseDto);
            return this.Ok(result);
        }

        [HttpPost("AddCourse")]
        public async Task<IActionResult> AddCourseData([FromBody] CreateCourseDto createCaseDto)
        {

            this._logger.LogDebug($"Called Method: {nameof(SecurityController)}/{nameof(this.AddCourseData)}");
            var result = await _studentService.AddCourse(createCaseDto);
            return this.Ok(result);
        }

        private string GenerateJSONWebToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Raj@123333Raj@12333"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("Issuer", "Raj"),
                new Claim("Admin", "true"),
                new Claim(JwtRegisteredClaimNames.UniqueName, username),
            };

            var token = new JwtSecurityToken("Raj", "Raj", claims, expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
