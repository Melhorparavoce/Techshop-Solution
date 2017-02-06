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
            string Transportadora="";
            context.Database.Connection.Open();
            DbCommand cmd = context.Database.Connection.CreateCommand();
            cmd.CommandText = "PROC_TRANSPORTADORA";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("CEP", cep.Trim()));
            cmd.Parameters.Add(new SqlParameter("UF", uf.Trim()));

            List<Transportadora> list= new List<Transportadora>();
            var reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                Transportadora = reader["TRANSPORTADORA"].ToString(); 
            }
            context.Database.Connection.Close();

            return Transportadora;
        }

        #endregion
    }
}
