using Core_API;
using Entities;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API.Models;

namespace Web_API.Controllers
{
    [RoutePrefix("api/ruta")]
    public class RutaController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Post(Ruta ruta)
        {
            try
            {
                var mng = new RutaManager();
                mng.Create(ruta);

                apiResp = new ApiResponse();
                apiResp.Message = "La acción fue realizada";

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
                
            }
        }

        public IHttpActionResult GetAll(string centroeducativo)
        {
            try
            {
                var mng = new RutaManager();
                var ruta = new Ruta
                {
                    CentroEducativo = centroeducativo
                };
                apiResp = new ApiResponse();
                apiResp.Data = mng.RetrieveAllById(ruta);

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new RutaManager();
                var usr = new Usuario
                {
                    CedulaFisica = id
                };
                apiResp = new ApiResponse();
                apiResp.Data = mng.RetrieveByCedula(usr);

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

        public IHttpActionResult Put(Ruta ruta)
        {
            try
            {
                var mng = new RutaManager();
                mng.Update(ruta);

                apiResp = new ApiResponse();
                apiResp.Message = "La acción fue realizada";

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

        public IHttpActionResult Delete(Ruta ruta)
        {
            try
            {
                var mng = new RutaManager();
                mng.Delete(ruta);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

        [Route("asociar")]
        public IHttpActionResult PostAsociar(Ruta ruta)
        {
            try
            {
                var mng = new RutaManager();
                mng.Asociar(ruta);

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
