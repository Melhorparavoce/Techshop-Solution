namespace SkyHubAdapter.Domain.SkyHub
{
    public class Freight
    {
        public FreightAccount account { get; set; }
        public string created_at { get; set; }
        public string sale_system { get; set; }
        public FreighRequest request { get; set; }
        public FreightResponse response { get; set; }
    }
}
