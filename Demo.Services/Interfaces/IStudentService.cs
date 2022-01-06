using Demo.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IList<StudentDto>> GetStudents();

        Task<StudentDto> AddStudent(CreateStudentDto studentDto);

        Task<CourseDto> AddCourse(CreateCourseDto createCourseDto);
    }
}
