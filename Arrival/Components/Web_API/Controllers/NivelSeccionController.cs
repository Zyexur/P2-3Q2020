using Core_API;
using Entities;
using Exceptions;
using System;
using System.Web.Http;
using Web_API.Models;

namespace Web_API.Controllers
{
    public class NivelSeccionController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get(string id, string idsecc)
        {
            try
            {
                var mng = new NivelSeccionManager();
                var nivelSeccion = new NivelSeccion
                {
                    IdCentroEdu = id,
                    IdSeccion = Convert.ToInt32(idsecc)
                };

                apiResp = new ApiResponse();
                apiResp.Data = mng.RetrieveAllById(nivelSeccion);
                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

        // POST 
        // CREATE
        public IHttpActionResult Post(NivelSeccion nivelSeccion)
        {
            try
            {
                var mng = new NivelSeccionManager();
                mng.Create(nivelSeccion);

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