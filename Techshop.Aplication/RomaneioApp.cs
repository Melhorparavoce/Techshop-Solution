using System;
using SkyHubAdapter.Application;
using SkyHubAdapter.Domain.SkyHub;
using Techshop.Repositoy.CodeFirst;
using Techshop.Model;  
using System.Collections.Generic;
using Protheus.Repository;

namespace Techshop.Aplication
{
    public class RomaneioApp
    {
        #region Propriedades
        private RomaneioRep objRomaneioRep;
        private PedidosProtheusRep objPedidosProtheusRep;

        public RomaneioApp()
        {
            objRomaneioRep = new RomaneioRep();
            objPedidosProtheusRep = new PedidosProtheusRep();
        }

        #endregion

        #region Métodos
      
        public void FecharRomaneio(string DataInicio,string DataFim)
        {
                        

        }  

        public List<PedidoProtheus> Listar(int StatusFechamento,int Status,DateTime DataInicio,DateTime DataFim, string Empresa,string Cliente)
        {
                             
            return objRomaneioRep.Listar(StatusFechamento,Status, DataInicio, DataFim, Empresa, Cliente);
        }
                      
        public List<PedidoProtheus> FecharLote(string [] Pedidos)
        {
            int CodigoGrupo = objRomaneioRep.RetornaUltimoGrupo();

            foreach (string item in Pedidos)
            {
                Romaneio EntidadeRomaneio = (Romaneio)objRomaneioRep.Listar(where => where.CodigoPedidoProtheus == Convert.ToInt32(item))[0];

                EntidadeRomaneio.CodigoGrupo = CodigoGrupo;
                EntidadeRomaneio.DataFechamento = DateTime.Now;
                EntidadeRomaneio.StatusRomaneio = 1;                                                  
                EntidadeRomaneio.DescricaoStatus = "Romaneio Fechado";
                objRomaneioRep.Atualizar(EntidadeRomaneio);
            }

            return objRomaneioRep.Listar(CodigoGrupo);      
  
        }    

        public List<Romaneio> ListarRomaneiosPeriodo(DateTime DataInicio,DateTime DataFim)
        {

            return objRomaneioRep.Listar(DataInicio, DataFim, 1);


        }

        
        #endregion

    }

}
