using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Common.Dtos;
using Demo.DataAccess;
using Demo.DataAccess.Models;
using Demo.Repositories.Converters;
using Demo.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Demo.Repositories.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ILogger<StudentRepository> _logger;

        private readonly SchoolContext _context;

        public StudentRepository(ILogger<StudentRepository> logger, SchoolContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async  Task<CourseDto> AddCourse(CreateCourseDto createCourseDto)
        {
            try
            {
                var courseData = new Course
                {
                    CourseName = createCourseDto.CourseName,
                    StudentId = createCourseDto.StudentId
                };

                await this._context.Courses.AddAsync(courseData);
                await this._context.SaveChangesAsync();
                return courseData.ToDto();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Exception: {nameof(this.GetStudents)}:{ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// AddStudent
        /// </summary>
        /// <param name="studentDto">CreateStudentDto</param>
        /// <returns></returns>
        public async Task<StudentDto> AddStudent(CreateStudentDto studentDto)
        {
            try
            {
                var student = new Student
                {
                    Name = studentDto.Name
                };

                await this._context.Students.AddAsync(student);
                await this._context.SaveChangesAsync();
                return student.ToDto();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Exception: {nameof(this.GetStudents)}:{ex.Message}");
                throw;
            }
        }

        public async Task<IList<StudentDto>> GetStudents()
        {
            try
            {
                return await _context.Students.Select(x => x.ToDto()).ToListAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Exception: {nameof(this.GetStudents)}:{ex.Message}");
                throw;
            }
        }
    }
}
