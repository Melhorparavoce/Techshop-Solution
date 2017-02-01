using System;
using SkyHubAdapter.Application.Interfaces;
using SkyHubAdapter.Domain.AbsModels;

namespace SkyHubAdapter.Application
{
    public class StatusTypeApp : IGenericType<string>
    {
        private const string Uri = "status_types";
        public ResultProcessing Post(string newModel)
        {
            throw new NotImplementedException();
        }

        public ResultProcessing Put(string model)
        {
            throw new NotImplementedException();
        }

        public ResultProcessing Get(string code = "")
        {
            return ClientHelper.Get<string>(Uri, "");
        }

        public ResultProcessing Delete(string sku)
        {
            throw new NotImplementedException();
        }
    }
}
