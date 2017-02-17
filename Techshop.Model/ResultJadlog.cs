using System;
using System.Xml;
using System.Xml.Serialization;
namespace Techshop.Model
{
    [XmlRoot(ElementName = "Pai")]
    public class Pai
    {
        [XmlElement(ElementName = "filho")]
        public string Filho { get; set; }
    }

    [XmlRoot(ElementName = "JadLogResulting")]
    public class JadLogResulting
    {
        [XmlElement(ElementName = "Pai")]
        public Pai Pai { get; set; }
        [XmlElement(ElementName = "LastUpdated")]
        public string LastUpdated { get; set; }
        [XmlElement(ElementName = "Message")]
        public string Message { get; set; }
        [XmlElement(ElementName = "State")]
        public string State { get; set; }
        [XmlElement(ElementName = "StateName")]
        public string StateName { get; set; }
    }
}
