//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Master_V.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblComprobacionGastos
    {
        public int IdComprobacion { get; set; }
        public System.DateTime fecha { get; set; }
        public Nullable<double> tarifa { get; set; }
        public Nullable<double> hospedaje { get; set; }
        public Nullable<double> alimentacion { get; set; }
        public Nullable<double> gasolina { get; set; }
        public Nullable<double> taxi { get; set; }
        public Nullable<double> caseta { get; set; }
        public Nullable<double> tel { get; set; }
        public Nullable<double> estacionamiento { get; set; }
        public Nullable<double> internet { get; set; }
        public Nullable<double> paquetEnvio { get; set; }
        public Nullable<double> comidaNeg { get; set; }
        public Nullable<double> otros { get; set; }
    
        public virtual tblComprobación tblComprobación { get; set; }
    }
}