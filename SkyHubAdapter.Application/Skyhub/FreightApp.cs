using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkyHubAdapter.Application.Interfaces;
using SkyHubAdapter.Domain.AbsModels;
using SkyHubAdapter.Domain.SkyHub;

namespace SkyHubAdapter.Application
{
    public class FreightApp : IGenericType<Freight>
    {
        private const string Uri = "freights";

        public ResultProcessing Post(Freight newModel)
        {
            throw new NotImplementedException();
        }

        public ResultProcessing Put(Freight model)
        {
            throw new NotImplementedException();
        }

        public ResultProcessing Get(string code = "")
        {
            return ClientHelper.Get<Freight>(Uri);
        }

        public ResultProcessing Delete(string code)
        {
            throw new NotImplementedException();
        }
    }
}
