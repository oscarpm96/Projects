﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiPrimeraAplicacionWebConEntityFramework.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SUPPLYEntities : DbContext
    {
        public SUPPLYEntities()
            : base("name=SUPPLYEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<MVC_Cliente> MVC_Cliente { get; set; }
        public DbSet<MVC_Marca> MVC_Marca { get; set; }
        public DbSet<MVC_Sexo> MVC_Sexo { get; set; }
        public DbSet<MVC_Sucursal2> MVC_Sucursal2 { get; set; }
    }
}
