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
    
    public partial class tblRelacionGastos
    {
        public int IdGastosSinComprobar { get; set; }
        public System.DateTime fecha { get; set; }
        public string concepto { get; set; }
        public double importe { get; set; }
    
        public virtual tblGastosSinComprobar tblGastosSinComprobar { get; set; }
    }
}
