using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Master_V.Models;

namespace Master_V.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            // Mappings de Empleado y sus DTO's.
            AutoMapper.Mapper.CreateMap<tblEmpleado, EmpleadoDTO>();
            AutoMapper.Mapper.CreateMap<EmpleadoDTO, tblEmpleado>();

            // Mappings de Empleado y sus DTO's.
            AutoMapper.Mapper.CreateMap<tblComprobacion, ComprobacionesDTO>();

            AutoMapper.Mapper.CreateMap<tblComprobacion, ComprobacionDTO>();
            AutoMapper.Mapper.CreateMap<ComprobacionDTO, tblComprobacion>();
        }
    }
}