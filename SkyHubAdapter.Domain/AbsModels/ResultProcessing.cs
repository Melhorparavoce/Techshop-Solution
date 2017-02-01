using System.Net;

namespace SkyHubAdapter.Domain.AbsModels
{
    public class ResultProcessing
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object AdditionalData { get; set; }
        public HttpStatusCode StatusCode { get; set; }


        public ResultProcessing()
        {
            Success = true;
            Message = "";
            AdditionalData = "";
        }

    }
}
