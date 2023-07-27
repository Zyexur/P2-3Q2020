using Core_API;
using Entities;
using Exceptions;
using System;
using System.Web.Http;
using Web_API.Models;

namespace Web_API.Controllers
{
    public class ListOptionController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GET api/listoption/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = ListOptionManager.GetInstance();
                var option = new OptionList
                {
                    ListId = id
                };

                var lstOptions = mng.RetrieveById(option);
                return Ok(lstOptions);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

    }
}