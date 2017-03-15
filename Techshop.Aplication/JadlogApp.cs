using System;
using Techshop.Repositoy.CodeFirst;
using Techshop.Model;
using System.Configuration;
using Techshop.Aplication.Interface;
using SkyHubAdapter.Application;
using SkyHubAdapter.Domain;
using SkyHubAdapter.Domain.SkyHub;
using SkyHubAdapter.Domain.AbsModels;
namespace Techshop.Aplication
{
    public class JadlogApp
    {

        #region Propriedades
        private PedidosProtheusRep objPedidosProtheusRep;
        private string CodigoCliente;
        private string SenhaCliente;
        private string CnpjTechshop;
        private WsdlJadlog.NotfisBeanService wsNotifisbean;
        private wsJadlogConsulta.TrackingBeanService wsConsultajadLog;
        private LogerroApp objLogerroApp;
        public JadlogApp()
        {
            objPedidosProtheusRep = new PedidosProtheusRep();
            wsNotifisbean = new WsdlJadlog.NotfisBeanService();
            wsConsultajadLog = new wsJadlogConsulta.TrackingBeanService();
            CodigoCliente = ConfigurationSettings.AppSettings["CodigoClienteJadlog"];
            SenhaCliente = ConfigurationSettings.AppSettings["SenhaWebserviceJadlog"];
            CnpjTechshop = ConfigurationSettings.AppSettings["CnpjTechshop"];
            objLogerroApp = new LogerroApp();
        }
        #endregion

        #region Métodos

        public string CancelarNotaJadLog(string Codigo)
        {
            string Mensagem = wsNotifisbean.cancelar(Convert.ToInt32(CodigoCliente), SenhaCliente, "78787844452222", "TESTE TECHSHOPJADLOG");

            return null;
        }


        public void AtualizarInformacaoPedidoTransportadora()
        {
           try
            {

                foreach (PedidoProtheus item in objPedidosProtheusRep.Listar(4))
                {

                    wsJadlogConsulta.TrackingBeanService obj = new wsJadlogConsulta.TrackingBeanService();
                    string MensagemRetorno = obj.consultarPedido(CnpjTechshop, SenhaCliente, "264068697201");
                    stringRetorno Resultado = XmlHelper.Deserializacao<stringRetorno>(TratarXmlJadLog(MensagemRetorno, "stringRetorno"));

                    objPedidosProtheusRep.AtualizaStatus(item.CodigoPedidoProtheus, 5);

                    /*if (Resultado.Jadlog_Tracking_Consultar.ND.Status == "ENTREGUE")
                    {
                        objPedidosProtheusRep.AtualizaStatus(5, 6);   

                    }     */


                }

            }catch(Exception ex)
            {
                objLogerroApp.GravarLogErro("Consulta Situação de Pedido Jadlog", "Erro ao consulta pedido Jadlog", ex.Message);

            }

        }


        public string EnviarInformacoesTransportadora(int CodigoPedido)
        {
            PedidoProtheus entidade = objPedidosProtheusRep.ListarCodigo(CodigoPedido)[0];
            string Mensagem = "";

          try
            {
                string MensagemRetorno = wsNotifisbean.inserir(
                                CodigoCliente, //CodCliente
                                SenhaCliente,  //Password
                                entidade.Remetente, //Remetente
                                entidade.RemetenteCnpj.Replace(".", "").Replace("/", "").Replace("-", ""), //RemetenteCNPJ
                                "",                       //RemetenteIE
                                entidade.RemetenteEndereco, //RemetenteEndereco
                                entidade.RemetenteBairro,    //RemetenteBairro   
                                entidade.RemetenteCep.Replace(".", "").Replace("/", "").Replace("-", ""),       // RemetenteCep
                                entidade.RemetenteTelefone.Replace(".", "").Replace("/", "").Replace("-", ""),  //RemetenteTelefone
                                "Inserir Destino",           //Destino
                                entidade.DescricaoCliente,   //Destinatario
                                entidade.DescricaoCPF,
                                "",                          //DestinatarioIE
                                entidade.DescricaoRua,       //DestinatarioEndereco
                                entidade.DescricaoBairro,    //DestinatarioBairro
                                entidade.DescricaoCep,       //DestinatarioCEP
                                entidade.DescricaoTelefone1.Trim().Replace(".", "").Replace("/", "").Replace("-", ""), //DestinatarioTelefone
                                entidade.CodigoColeta,       //ColetaResponsavel
                                entidade.Volumes,            //Volumes
                                entidade.PesoReal,            //PesoReal
                                entidade.Especie,             //Especie
                                entidade.Conteudo,             //Conteudo
                                entidade.NumeroPedidoProtheus,//Nr_Pedido
                                entidade.NumeroNotaFiscal,
                                entidade.Danfe,
                                entidade.SerieNotaFiscal,        //Serie_Nf
                                entidade.ValorDeclaradoNota,     //ValorDeclarado
                                "S/ Observações",                //Observacoes
                                entidade.ModalidadeTransporte,   //Modalidade
                                "S/C Custo",                     //wCentroCusto
                                "",                              //wContaCorrente
                                "S",                             //wTipo
                                "");             //CodUnidade

                stringRetorno obj = XmlHelper.Deserializacao<stringRetorno>(TratarXmlJadLog(MensagemRetorno, "stringRetorno"));


                 switch (obj.Jadlog_Pedido_eletronico_Inserir.Retorno)
                 {
                     case "-1":
                         {

                             return  "Pedido " + entidade.CodigoPedidoProtheus + ", NF:" + entidade.NumeroNotaFiscal + ", erro ao registrar o pedido na Jadlog, mensagem: "+ obj.Jadlog_Pedido_eletronico_Inserir.Mensagem;
                         }
                     case "-2":
                         {
                             return "Pedido " + entidade.CodigoPedidoProtheus + ", NF:" + entidade.NumeroNotaFiscal + ", erro ao registrar o pedido na Jadlog, mensagem: " + obj.Jadlog_Pedido_eletronico_Inserir.Mensagem;
                         }
                     case "-3":
                         {
                             return "Pedido " + entidade.CodigoPedidoProtheus + ", NF:" + entidade.NumeroNotaFiscal + ", erro ao registrar o pedido na Jadlog, mensagem: " + obj.Jadlog_Pedido_eletronico_Inserir.Mensagem;

                         }
                     default:

                        entidade.CodigoColetaJadlog = obj.Jadlog_Pedido_eletronico_Inserir.Retorno;
                        entidade.StatusPedido = 4;
                        objPedidosProtheusRep.Atualizar(entidade);                        

                         return "Pedido " + entidade.CodigoPedidoProtheus + ", NF:" + entidade.NumeroNotaFiscal + ", enviado com sucesso, código coleta nº"+obj.Jadlog_Pedido_eletronico_Inserir.Retorno;
                 }   

            }
            catch (Exception ex)
            {
                Mensagem = "Erro ao enviar o pedido nº:" + CodigoPedido +"-"+ ex.Message;
                return Mensagem;
            }
        }
                       
        public ResultProcessing EnviarSkyhubPedidoEnviadoSeguradora(string CodigoParaRastreio,string ChaveNotaFiscal,string CodigoPedidoSkyhub)
        {

            //var MensagemSkyhub = EnviarSkyhubPedidoEnviadoSeguradora(obj.Jadlog_Pedido_eletronico_Inserir.Retorno, entidade.Danfe, entidade.NumeroEntregaSkyhub);

          //  if (MensagemSkyhub.Success == false)
               // return "Pedido " + entidade.CodigoPedido + ", NF:" + entidade.NumeroNotaFiscal + " Erro ao alterar o status do pedido Skyhub " + entidade.NumeroEntregaSkyhub + ",Descricao:" + MensagemSkyhub.Message;


            var newInvoice = new Invoice { key = ChaveNotaFiscal };
            var newShipment = new Shipment
            {
                code = DateTime.Now.ToString("yyyyMMddHHmmss"),
                track = new ShipmentTrack { carrier = "JADLOG", method = "Expresso", code = CodigoParaRastreio }
            };

           return new OrderApp().PostShipment(CodigoPedidoSkyhub.Trim(), newShipment, newInvoice);

        }

        public string TratarXmlJadLog(string xml,string root)
        {
            xml = xml.Replace("<string", "<"+ root);
            xml = xml.Replace("</string", "</"+ root);
            xml = xml.Replace("xmlns=", "xmlns:i=");

            return xml;
        } 
    
        #endregion    

    }
}
