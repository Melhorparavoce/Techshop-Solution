using System;
using Techshop.Repositoy.CodeFirst;
using Techshop.Model;  
using System.Collections.Generic;
using Protheus.Repository;

namespace Techshop.Aplication
{
    public class PedidoProtheusApp
    {
        #region Propriedades
        private PedidosProtheusRep objPedidosProtheusRep;
        public PedidoProtheusApp()
        {
            objPedidosProtheusRep = new PedidosProtheusRep();

        }

        #endregion

        #region Métodos


        public void AlteraStatusPedido(int Anterior, int Atual)
        {
            foreach (PedidoProtheus item in objPedidosProtheusRep.Listar(Anterior))
            {

                item.StatusPedido = Atual;
                objPedidosProtheusRep.Atualizar(item);

            }

        }

        public bool VerificaSePedidoExiste(string CodigoPedido)
        {

            return false;

        }       

        public void IncluirPedidosBaseEspelhoProtheus()
        {

            try
            {

                #region Propriedades Métodos

                PedidosRep objPedidosSkyhub = new PedidosRep();
                PedidosProtheusRep objPedidosProtheusRep = new PedidosProtheusRep();
                ItemPedidoRep objItemPedidoRep = new ItemPedidoRep();
                ItemPedidosProtheusRep objItemPedidoProtheusRep = new ItemPedidosProtheusRep();
                VendedorRep objVendedorRep = new VendedorRep();
                TransportadoraRep objTransportadoraRep = new TransportadoraRep();
                VendedorApp objVendedorApp = new VendedorApp();
                MarketplaceApp objMarketplaceApp = new MarketplaceApp();
                LogerroApp objLogerroApp = new LogerroApp();
                string CodigoParceiro = "";
                PedidosApp objPedidosApp = new PedidosApp();


                #endregion


                foreach (Pedido item in objPedidosSkyhub.ListarPedidosImportadosSkyhub())
                {
                    CodigoParceiro = objMarketplaceApp.RetornaParceiro(item.DescricaoCanal);
                    List<ItemPedidoProtheus> listItens = new List<ItemPedidoProtheus>();
                    var entidadeProtheus = new PedidoProtheus
                    {

                        TipoPedido = "N",
                        TipoFrete = "C",
                        CodigoTransportadora = objTransportadoraRep.RetornaTransportadora(item.DescricaoCep, item.DescricaoRegiao),
                        CodigoTabelaPrecos = "07",
                        Parceiro = CodigoParceiro,
                        DescricaoCanal = item.DescricaoCanal,
                        NumeroEntregaSkyhub = item.CodigoSkyhub,
                        DescricaoCliente = item.DescricaoCliente,
                        DescricaoEmail = item.DescricaoEmail,
                        DescricaoGenero = item.DescricaoGenero,
                        DescricaoCPF = item.DescricaoCPF,
                        DescricaoTelefone1 = item.DescricaoTelefone1,
                        DescricaoTelefone2 = item.DescricaoTelefone2,
                        DescricaoTelefone3 = item.DescricaoTelefone3,
                        DescricaoTelefone4 = item.DescricaoTelefone4,
                        DataNascimento = item.DataNascimento,
                        DescricaoBairro = item.DescricaoBairro,
                        DescricaoCep = item.DescricaoCep,
                        DescricaoCidade = item.DescricaoCidade,
                        DescricaoDetalhes = item.DescricaoDetalhes,
                        DescricaoNome = item.DescricaoNome,
                        DescricaoPais = item.DescricaoPais,
                        DescricaoRegiao = item.DescricaoRegiao,
                        DescricaoRua = item.DescricaoRua,
                        CodigoPedidoSkyhub = item.CodigoPedido,
                        Remetente = "Tech SHOP.COM.BR COMERCIO e SERVICO DE INFORMATICA LTDA",
                        RemetenteCnpj = "08351293000830",
                        RemetenteIe = "0010961460393",
                        RemetenteEndereco = "Rua Itamarandiba,401",
                        RemetenteBairro = "Carlos Prates",
                        RemetenteCep = "30710-360",
                        RemetenteTelefone = "3125337777",
                        //Informação deverá vir do Protheus
                        PesoReal = "1",
                        NumeroPedidoProtheus = "",
                        Danfe = "31170108351293000830550010000385021002111085",
                        NumeroNotaFiscal = "000038502",
                        SerieNotaFiscal = "1",
                        ValorDeclaradoNota = "793,50",
                        Volumes = "1",
                        Transportadora = "Jadlog",

                        //Validar com Ricardo
                        Especie = "N Inform.",
                        Conteudo = "N Inform.",

                        ModalidadeTransporte = "5",

                        //Informações Preenchidas no retorno da emissão de pedidos
                        CodigoColeta = "",
                        CodigoRastreio = "",


                        MensagemErro = "",
                        MensagemErroDetalhada = "",
                        StatusImportacao = "1",

                        StatusPedido = 1

                    };                      

                    foreach (ItemPedidos itemPedido in objItemPedidoRep.Listar(item.CodigoPedido))
                    {
                        entidadeProtheus.CodigoVendendor = objVendedorApp.RetornaVendedor(itemPedido.CodigoId, CodigoParceiro);

                        var EntidadeItensPedidosProtheus = new ItemPedidoProtheus
                        {
                            SkuProduto = itemPedido.CodigoId,
                            Quantidade = itemPedido.DescricaoQuantidade.ToString(),
                            Preco = itemPedido.DescricaoPrecoOriginal.ToString()
                        };

                        listItens.Add(EntidadeItensPedidosProtheus);
                    }

                    entidadeProtheus.ItemPedidoProtheus = listItens;     

                    objPedidosProtheusRep.Criar(entidadeProtheus);

                    //Indica que o produto foi importado Protheus
                    objPedidosApp.IndicaPedidoImportadoBaseEspelhoProtheus(item.CodigoPedido);

                }
            }
            catch (Exception ex)
            {
                LogerroApp LogerroApp = new LogerroApp();
                LogerroApp.GravarLogErro("Exportação Dados Espelho Protheus", "Erro inserção pedido", ex.InnerException.Message);
          
            }

        }

        public List<PedidoProtheus> ListarPedidoPorDanfe(int StatusPedido)
        {
            return objPedidosProtheusRep.Listar(StatusPedido);
        }

        public List<PedidoProtheus> ListarPedidoPorTransportadora(int StatusPedido,string Transportadora)
        {
            return objPedidosProtheusRep.Listar(StatusPedido);
        }

        public void AtualizaStatusPedido(string Danfe,int StatusPedido)
        {
             objPedidosProtheusRep.AtualizaStatus(Danfe, StatusPedido);

        }


        #endregion

    }

}
