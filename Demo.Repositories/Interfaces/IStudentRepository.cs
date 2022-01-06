using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Demo.Common.Dtos;

namespace Demo.Repositories.Interfaces
{
    public interface IStudentRepository
    {

        Task<IList<StudentDto>> GetStudents();

        Task<StudentDto> AddStudent(CreateStudentDto studentDto);

        Task<CourseDto> AddCourse(CreateCourseDto createCourseDto);
    }
}
