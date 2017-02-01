using System.Collections.Generic;

namespace SkyHubAdapter.Domain.SkyHub
{
    public class Status
    {
        public string code { get; set; }
        public string label { get; set; }
        public string type { get; set; }

        public class OrderStatusListResponse
        {
            public List<Status> Statuses { get; set; }
            public int Total { get; set; }
        }
    }
}
