using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techshop.Model;
using System.IO;
using System.Xml.Serialization;
namespace Techshop.Aplication.Interface
{
   public class XmlHelper
    {

        public static T Deserializacao<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));
            T result;

            using (TextReader reader = new StringReader(xml))
            {
               return result = (T)serializer.Deserialize(reader);
            }    
            
        }        
    }
}
