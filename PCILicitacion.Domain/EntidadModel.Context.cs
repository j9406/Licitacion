﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PCILicitacion.Domain
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PCILicitacionEntities : DbContext
    {
        public PCILicitacionEntities()
            : base("name=PCILicitacionEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<LicitacionPartidaProductoView> LicitacionPartidaProductoView { get; set; }
        public virtual DbSet<LicitacionPartidaView> LicitacionPartidaView { get; set; }
        public virtual DbSet<LicitanteLicitacionView> LicitanteLicitacionView { get; set; }
    }
}