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
    
    public partial class tblPersonasAsignadas
    {
        public tblPersonasAsignadas()
        {
            this.tblSolicitudV = new HashSet<tblSolicitudV>();
        }
    
        public string IdProyecto { get; set; }
        public int IdPersonas { get; set; }
    
        public virtual tblProyecto tblProyecto { get; set; }
        public virtual ICollection<tblSolicitudV> tblSolicitudV { get; set; }
    }
}