using System;
using SkyHubAdapter.Application.Interfaces;
using SkyHubAdapter.Domain.AbsModels;

namespace SkyHubAdapter.Application
{
    public class MarketplacesApp : IGenericType<MarketplacesApp>
    {
        private const string Uri = "sale_systems";
        public ResultProcessing Post(MarketplacesApp newModel)
        {
            throw new NotImplementedException();
        }

        public ResultProcessing Put(MarketplacesApp model)
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
