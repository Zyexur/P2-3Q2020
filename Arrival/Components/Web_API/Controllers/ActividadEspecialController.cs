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
    [RoutePrefix("api/actividadespecial")]
    public class ActividadEspecialController : ApiController
    {
        
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult GetAll(string centroeducativo)
        {
            try
            {
                var mng = new ActividadEspecialManager();
                var actividadEspecial = new ActividadEspecial
                {
                    CentroEducativo = centroeducativo
                };
                apiResp = new ApiResponse();
                apiResp.Data = mng.RetrieveAllById(actividadEspecial);

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
                var mng = new ActividadEspecialManager();
                var actividad = new ActividadEspecial
                {
                    IdActividad = Convert.ToInt32(id)
                };
                apiResp = new ApiResponse();
                apiResp.Data = mng.RetrieveById(actividad);

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

        public IHttpActionResult Post(ActividadEspecial actividadEspecial)
        {
            try
            {
                var mng = new ActividadEspecialManager();
                mng.Create(actividadEspecial);

                apiResp = new ApiResponse();
                apiResp.Message = "La acción fue realizada";

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.MessageText));
            }
        }

        public IHttpActionResult Put(ActividadEspecial actividadEspecial)
        {
            try
            {
                var mng = new ActividadEspecialManager();
                mng.Update(actividadEspecial);

                apiResp = new ApiResponse();
                apiResp.Message = "La acción fue realizada";

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

        [Route("asociar")]
        public IHttpActionResult PostAsociar(ActividadEspecial actividadEspecial)
        {
            try
            {
                var mng = new ActividadEspecialManager();
                mng.Asociar(actividadEspecial);

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
