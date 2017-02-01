using SkyHubAdapter.Application.Interfaces;
using SkyHubAdapter.Domain.AbsModels;
using SkyHubAdapter.Domain.SkyHub;

namespace SkyHubAdapter.Application
{
    public class StatusApp :IGenericType<Status>
    {
        private const string Uri = "statuses";

        public ResultProcessing Post(Status newOrderStatus)
        {
            return ClientHelper.Post(newOrderStatus, Uri);
        }

        public ResultProcessing Put(Status orderStatus)
        {
            return ClientHelper.Put(orderStatus, Uri + "/" + orderStatus.code);
        }

        public ResultProcessing Get(string code = "")
        {
            return ClientHelper.Get<Status>(Uri);
        }

        public ResultProcessing Delete(string code)
        {
            return ClientHelper.Delete(Uri, code);
        }
    }
}
