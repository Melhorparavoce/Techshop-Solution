using SkyHubAdapter.Application.Interfaces;
using SkyHubAdapter.Domain.AbsModels;
using SkyHubAdapter.Domain.SkyHub;

namespace SkyHubAdapter.Application
{
    public class QueueApp
    {
        private const string Uri = "queues";

        public ResultProcessing GetNextOrder()
        {
            return ClientHelper.Get<Order>(Uri + "/orders", "", false);
        }

        public ResultProcessing DeleteOrder(string code)
        {
            return ClientHelper.Delete(Uri + "/orders", code);
        }
    }
}
