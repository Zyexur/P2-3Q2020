using Core_API;
using Entities;
using Exceptions;
using System;
using System.Web.Http;
using Web_API.Models;

namespace Web_API.Controllers
{
    public class BitacoraController : ApiController
    {
        //TODO: Corregir Get
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new BitacoraManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new BitacoraManager();
                var bitacora = new Bitacora
                {
                    CedulaFisica = id
                };

                apiResp = new ApiResponse();
                apiResp.Data = mng.RetrieveAllById(bitacora);
                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

        public IHttpActionResult Post(Bitacora bitacora)
        {
            try
            {
                var mng = new BitacoraManager();
                bitacora.Fecha = DateTime.Now;
                mng.Create(bitacora);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.MessageText));
            }
        }
    }
}