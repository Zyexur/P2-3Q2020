using Core_API;
using System.Web.Http;
using Web_API.Models;

namespace Web_API.Controllers
{
    public class SeccionController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new SeccionManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }
    }
}