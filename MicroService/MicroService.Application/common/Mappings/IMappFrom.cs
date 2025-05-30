using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Application.common.Mappings
{
    public interface IMappFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}




