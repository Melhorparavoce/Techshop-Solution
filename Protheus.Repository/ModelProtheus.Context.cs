﻿//------------------------------------------------------------------------------
// <auto-generated>
//    O código foi gerado a partir de um modelo.
//
//    Alterações manuais neste arquivo podem provocar comportamento inesperado no aplicativo.
//    Alterações manuais neste arquivo serão substituídas se o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Protheus.Repository
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProtheusEntities : DbContext
    {
        public ProtheusEntities()
            : base("name=ProtheusEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<SA1010> SA1010 { get; set; }
        public DbSet<SB1010> SB1010 { get; set; }
        public DbSet<SC5010> SC5010 { get; set; }
        public DbSet<SC6010> SC6010 { get; set; }
    }
}
