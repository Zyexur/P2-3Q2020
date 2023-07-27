using Core_API;
using Entities;
using Exceptions;
using System;
using System.Web.Http;
using Web_API.Models;

namespace Web_API.Controllers
{
    public class PagoController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        { 
            apiResp = new ApiResponse();
            var mng = new PagoManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new PagoManager();
                var pago = new Pago
                {
                    IdPago = Convert.ToInt32(id)
                };

                pago = mng.RetrieveById(pago);
                apiResp = new ApiResponse();
                apiResp.Data = pago;
                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

        public IHttpActionResult Post(Pago pago)
        {

            try
            {
                var mng = new PagoManager();
                mng.Create(pago);

                apiResp = new ApiResponse();
                apiResp.Message = "La acción fue realizada";

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

        public IHttpActionResult Delete(Pago pago)
        {
            try
            {
                var mng = new PagoManager();
                mng.Delete(pago);

                apiResp = new ApiResponse();
                apiResp.Message = "La acción fue realizada";

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }
    }
}
