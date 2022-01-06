using Demo.Common.Dtos;
using Demo.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Repositories.Converters
{
    public static class Converters
    {

        public static StudentDto ToDto(this Student item)
        {
            StudentDto result = null;
            if (item != null)
            {
                result = new StudentDto
                {
                    StudentId = item.StudentId,
                    Name = item.Name
                };
            }

            return result;
        }

        public static CourseDto ToDto(this Course item)
        {
            CourseDto result = null;
            if (item != null)
            {
                result = new CourseDto
                {
                    CourseId = item.CourseId,
                    StudentId = item.StudentId,
                    CourseName = item.CourseName
                };
            }

            return result;
        }
    }
}
