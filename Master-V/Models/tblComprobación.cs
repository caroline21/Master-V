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
    
    public partial class tblComprobación
    {
        public tblComprobación()
        {
            this.tblComprobacionGastos = new HashSet<tblComprobacionGastos>();
            this.tblGastosSinComprobar = new HashSet<tblGastosSinComprobar>();
            this.tblTotalDiario = new HashSet<tblTotalDiario>();
            this.tblTotalGastos = new HashSet<tblTotalGastos>();
        }
    
        public int Idcomprobacion { get; set; }
        public int IdSolicitud { get; set; }
        public string IdProyecto { get; set; }
        public int IdEmpleado { get; set; }
        public System.DateTime fecha { get; set; }
        public string gerenteAdmin { get; set; }
        public string jefeInmediato { get; set; }
        public string areaContable { get; set; }
    
        public virtual tblSolicitudV tblSolicitudV { get; set; }
        public virtual ICollection<tblComprobacionGastos> tblComprobacionGastos { get; set; }
        public virtual ICollection<tblGastosSinComprobar> tblGastosSinComprobar { get; set; }
        public virtual ICollection<tblTotalDiario> tblTotalDiario { get; set; }
        public virtual ICollection<tblTotalGastos> tblTotalGastos { get; set; }
    }
}
