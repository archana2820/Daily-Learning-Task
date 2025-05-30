using AutoMapper;
using System.Runtime;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Repositorypattern
{
    public class AutoMappercs : Profile
    {
        public AutoMappercs()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
        }
    }
}
