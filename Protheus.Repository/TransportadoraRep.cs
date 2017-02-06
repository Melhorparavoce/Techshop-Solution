using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.Linq;
using System.Data;
using System.Data.SqlClient;
using Techshop.Model;
using System.Collections.Generic;

namespace Protheus.Repository
{
    public class TransportadoraRep
    {
        #region Propriedades
        private ProtheusContext context;

        public TransportadoraRep()
        {

            context = new ProtheusContext();
        }

        #endregion

        #region Métodos
        public string RetornaTransportadora(string cep,string uf)
        {
            
            context.Database.Connection.Open();
            DbCommand cmd = context.Database.Connection.CreateCommand();
            cmd.CommandText = "PROC_TRANSPORTADORA";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("COD_CEP", cep.Trim()));
            cmd.Parameters.Add(new SqlParameter("COD_ESTADO", uf.Trim()));

            List<Transportadora> list= new List<Transportadora>();
            var reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                string teste = reader["DSC_TRANSPORTADORA"].ToString();

            }
               
            return null;
        }

        #endregion
    }
}
