﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<tblComprobacion> tblComprobacion { get; set; }
        public DbSet<tblEmpleado> tblEmpleado { get; set; }
        public DbSet<tblGastosSinComprobar> tblGastosSinComprobar { get; set; }
        public DbSet<tblPersonasAsignadas> tblPersonasAsignadas { get; set; }
        public DbSet<tblPersonasSolicitud> tblPersonasSolicitud { get; set; }
        public DbSet<tblProyecto> tblProyecto { get; set; }
        public DbSet<tblSolicitudV> tblSolicitudV { get; set; }
        public DbSet<tblAlimentos> tblAlimentos { get; set; }
        public DbSet<tblComprobacionGastos> tblComprobacionGastos { get; set; }
        public DbSet<tblConceptosDesc> tblConceptosDesc { get; set; }
        public DbSet<tblHospedaje> tblHospedaje { get; set; }
        public DbSet<tblOtrosGastos> tblOtrosGastos { get; set; }
        public DbSet<tblRelacionGastos> tblRelacionGastos { get; set; }
        public DbSet<tblTotalDiario> tblTotalDiario { get; set; }
        public DbSet<tblTotalGastos> tblTotalGastos { get; set; }
        public DbSet<tblTransporte> tblTransporte { get; set; }
    }
}
