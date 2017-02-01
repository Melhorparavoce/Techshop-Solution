using System.Collections.Generic;

namespace SkyHubAdapter.Domain.SkyHub
{
    public class FreighRequest
    {
        public string path { get; set; }
        public string zipcode { get; set; }
        public List<Product> products { get; set; }
    }
}
