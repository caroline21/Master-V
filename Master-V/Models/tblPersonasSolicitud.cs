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
    
    public partial class tblPersonasSolicitud
    {
        public int IdSolicitud { get; set; }
        public int IdPersona { get; set; }
        public int IdRelacion { get; set; }
    
        public virtual tblPersonasAsignadas tblPersonasAsignadas { get; set; }
        public virtual tblSolicitudV tblSolicitudV { get; set; }
    }
}
