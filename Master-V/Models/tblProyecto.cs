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
    
    public partial class tblProyecto
    {
        public tblProyecto()
        {
            this.tblPersonasAsignadas = new HashSet<tblPersonasAsignadas>();
        }
    
        public int IdProyecto { get; set; }
        public string nomProyecto { get; set; }
        public string nombre { get; set; }
        public Nullable<double> montoDesayuno { get; set; }
        public Nullable<double> montoComida { get; set; }
        public Nullable<double> montoCena { get; set; }
        public string nombreGerente { get; set; }
        public string nombreJefe { get; set; }
        public string nombreConta { get; set; }
    
        public virtual ICollection<tblPersonasAsignadas> tblPersonasAsignadas { get; set; }
    }
}
