using AutoMapper;
using Domain.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Employee, EmployeeDTO>()
                .ReverseMap();
            CreateMap<Department, DepartmentDTO>()
                .ReverseMap();
            CreateMap<Department, DepartmentInsertDTO>()
                .ReverseMap();

        }
    }
}
