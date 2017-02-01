namespace SkyHubAdapter.Domain.SkyHub
{
    public class Address
    {
        public int CodigoPedido { get; set; }
        public int TipoEndereco { get; set; }
        public string DescricaoEndereco { get; set; }
        public string full_name { get; set; }
        public string street { get; set; }
        public string number { get; set; }
        public string detail { get; set; }
        public string neighborhood { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public string postcode { get; set; }
    }
}
