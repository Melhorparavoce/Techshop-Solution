namespace SkyHubAdapter.Domain.SkyHub
{
    public class Payment
    {
        public string method { get; set; }
        public string description { get; set; }
        public int parcels { get; set; }
        public double value { get; set; }
    }
}
