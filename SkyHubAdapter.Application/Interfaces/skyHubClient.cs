using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SkyHubAdapter.Application.Interfaces
{
    internal class SkyHubClient : HttpClient
    {
        public SkyHubClient()
        {
            BaseAddress = new Uri("https://in.skyhub.com.br/");
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            DefaultRequestHeaders.Add("X-User-Email", "danieltomy@techshop.com.br");
            DefaultRequestHeaders.Add("X-User-Token", "gcspXsf52Qu54Gab9G7z");

          

        }
    }
}
