﻿//------------------------------------------------------------------------------
// <auto-generated>
//    O código foi gerado a partir de um modelo.
//
//    Alterações manuais neste arquivo podem provocar comportamento inesperado no aplicativo.
//    Alterações manuais neste arquivo serão substituídas se o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tecsshcop.Repository
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TechshopEntities1 : DbContext
    {
        public TechshopEntities1()
            : base("name=TechshopEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<TEC_CLIENTES> TEC_CLIENTES { get; set; }
        public DbSet<TEC_ENDERECO> TEC_ENDERECO { get; set; }
        public DbSet<TEC_FATURA> TEC_FATURA { get; set; }
        public DbSet<TEC_ITEM_PEDIDO> TEC_ITEM_PEDIDO { get; set; }
        public DbSet<TEC_PAGAMENTO> TEC_PAGAMENTO { get; set; }
        public DbSet<TEC_PEDIDOS> TEC_PEDIDOS { get; set; }
        public DbSet<TEC_PERFIL> TEC_PERFIL { get; set; }
        public DbSet<TEC_USUARIO> TEC_USUARIO { get; set; }
    }
}
