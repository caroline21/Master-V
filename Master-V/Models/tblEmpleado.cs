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
    
    public partial class tblEmpleado
    {
        public tblEmpleado()
        {
            this.tblSolicitudV = new HashSet<tblSolicitudV>();
        }
    
        public int IdEmpleado { get; set; }
        public string nombre { get; set; }
        public string foto { get; set; }
        public string usuario { get; set; }
    
        public virtual ICollection<tblSolicitudV> tblSolicitudV { get; set; }
    }
}
