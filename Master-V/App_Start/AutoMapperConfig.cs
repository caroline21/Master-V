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
            // Mape de Empleado y sus DTO's.
            AutoMapper.Mapper.CreateMap<tblEmpleado, EmpleadoDTO>();
            AutoMapper.Mapper.CreateMap<EmpleadoDTO, tblEmpleado>();

            //

        }
    }
}