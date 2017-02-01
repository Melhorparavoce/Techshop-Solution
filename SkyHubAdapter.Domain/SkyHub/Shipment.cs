using System.Collections.Generic;

namespace SkyHubAdapter.Domain.SkyHub
{
    public class Shipment
    {
        public string code { get; set; }
        public List<ShipmentItem> items { get; set; }
        public ShipmentTrack track { get; set; }
    }
}
