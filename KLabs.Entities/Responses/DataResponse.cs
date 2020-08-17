using System.Net;
using KLabs.Entities.Responses.Abstract;

namespace KLabs.Entities.Responses
{
    public class DataResponse : IViewResponse
    {
        public bool Success { get; set; }

        public object Data { get; set; }
        
        public string Message { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public int StatusCodeInt => (int)StatusCode;

    }
}