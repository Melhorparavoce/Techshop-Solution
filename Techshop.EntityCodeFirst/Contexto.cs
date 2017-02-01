using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Techshop.EntityCodeFirst
{
    public class Contexto : DbContext
     {
          public DbSet<Grupo> Grupo { get; set; }
          public DbSet<Produto> Produto { get; set; }
     } 
 }
