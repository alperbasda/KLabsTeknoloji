using System.Security.AccessControl;
using KLabs.Entities.Responses.Abstract;


namespace KLabs.Entities.Responses
{
    public class BaseResponse : IViewResponse
    {
        public bool Success { get; set; }
   
    }
}