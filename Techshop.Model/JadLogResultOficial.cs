using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Techshop.Model
{

   [XmlRoot(ElementName="Jadlog_Pedido_eletronico_Inserir")]
	public class Jadlog_Pedido_eletronico_Inserir {
		[XmlElement(ElementName="versao")]
		public string Versao { get; set; }
		[XmlElement(ElementName="Retorno")]
		public string Retorno { get; set; }
		[XmlElement(ElementName="Mensagem")]
		public string Mensagem { get; set; }
	}


    [XmlRoot(ElementName = "Jadlog_Tracking_Consultar")]
    public class Jadlog_Tracking_Consultar
    {
        [XmlElement(ElementName = "ND")]
        public ND ND { get; set; }
    }


    [XmlRoot(ElementName= "stringRetorno")]
	public class stringRetorno
    {
		[XmlElement(ElementName="Jadlog_Pedido_eletronico_Inserir")]
		public Jadlog_Pedido_eletronico_Inserir Jadlog_Pedido_eletronico_Inserir { get; set; }

        [XmlElement(ElementName = "Jadlog_Tracking_Consultar")]
        public Jadlog_Tracking_Consultar Jadlog_Tracking_Consultar { get; set; }
    }
    [XmlRoot(ElementName = "ND")]
    public class ND
    {
        [XmlElement(ElementName = "Numero")]
        public string Numero { get; set; }
        [XmlElement(ElementName = "Status")]
        public string Status { get; set; }
        [XmlElement(ElementName = "DataHoraEntrega")]
        public string DataHoraEntrega { get; set; }
        [XmlElement(ElementName = "Recebedor")]
        public string Recebedor { get; set; }
        [XmlElement(ElementName = "Documento")]
        public string Documento { get; set; }
        [XmlElement(ElementName = "ChaveAcesso")]
        public string ChaveAcesso { get; set; }
        [XmlElement(ElementName = "Cte")]
        public string Cte { get; set; }
        [XmlElement(ElementName = "Serie")]
        public string Serie { get; set; }
        [XmlElement(ElementName = "DataEmissao")]
        public string DataEmissao { get; set; }
        [XmlElement(ElementName = "Valor")]
        public string Valor { get; set; }
    }
    
}