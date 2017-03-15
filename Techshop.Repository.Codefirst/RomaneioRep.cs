using System;
using System.Collections.Generic;
using System.Linq;
using Techshop.Model;
using System.Data.Entity;
namespace Techshop.Repositoy.CodeFirst
{
    public class RomaneioRep : RepositorioGenerico<Romaneio>
    {
        #region  Propriedades
        private TechshopContext context;
        private PedidosProtheusRep objPedidosProtheusRep;
        public RomaneioRep()
        {
            context = new TechshopContext();
            objPedidosProtheusRep = new PedidosProtheusRep();
        }

        #endregion

        #region Métodos

       public int RetornaUltimoGrupo()
        {
            return context.Romaneio.Max(t => t.CodigoGrupo) + 1; ;
        }

        public void Excluir(int Codigo)
        {
            Romaneio entidade = Listar(where => where.CodigoPedidoProtheus == null).FirstOrDefault();
            Excluir(entidade);
        }         
                              
        public List<PedidoProtheus> Listar(int CodigoGrupoRomaneio)
        {

           
            List<PedidoProtheus> lista =(List<PedidoProtheus>) (from p in context.PedidoProtheus join r in context.Romaneio 
                                                                on p.CodigoPedidoProtheus equals r.CodigoPedidoProtheus
                                                                where r.CodigoGrupo == CodigoGrupoRomaneio select p).ToList();
         
            foreach (PedidoProtheus item in lista)
            {
                 item.Romaneios = (from p in context.Romaneio
                                  where p.CodigoPedidoProtheus == item.CodigoPedidoProtheus
                                  select p).FirstOrDefault();
            }


            return lista;
        }

        public List<PedidoProtheus> Listar(int StatusFechamento, int Status, DateTime DataInicio, DateTime DataFim, string Transportadora, string Cliente)
        {
            
            List<PedidoProtheus> lista = (List<PedidoProtheus>)(from p in context.PedidoProtheus join r in context.Romaneio on p.CodigoPedidoProtheus equals r.CodigoPedidoProtheus
                                                                where p.Transportadora.Contains(Transportadora)
                                                                      && DbFunctions.TruncateTime( p.DataNotaFiscal) >= DataInicio
                                                                      && DbFunctions.TruncateTime(p.DataNotaFiscal)<= DataFim 
                                                                       && p.DescricaoCliente.Contains(Cliente) 
                                                                      && r.StatusRomaneio== StatusFechamento                                                                       
                                                                select p).ToList();
            foreach (PedidoProtheus item in lista)
            {
                 item.Romaneios = (from p in context.Romaneio
                                  where p.CodigoPedidoProtheus == item.CodigoPedidoProtheus
                                  select p).FirstOrDefault();
            }


            return lista;
        }

        public List<Romaneio> Listar(DateTime DataInicio, DateTime DataFim, int statusRomaneio)
        {
            List<Romaneio> lista = new List<Romaneio>();

            var result = (from r in context.Romaneio
                                    where r.StatusRomaneio == statusRomaneio
                                    select new {CodigoGrupo=r.CodigoGrupo }).Distinct().ToList();

            foreach(var item in result)
            {
                Romaneio obj = new Romaneio();
                obj.CodigoGrupo = item.CodigoGrupo;
                lista.Add(obj);
            }

            return lista;
        }



        #endregion

    }
}
