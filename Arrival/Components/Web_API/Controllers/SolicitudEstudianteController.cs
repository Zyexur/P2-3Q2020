using Core_API;
using Entities;
using Exceptions;
using System;
using System.Web.Http;
using Web_API.Models;

namespace Web_API.Controllers
{
    [RoutePrefix("api/solicitudestudiante")]
    public class SolicitudEstudianteController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get(string cedulaFisica)
        {
            apiResp = new ApiResponse();
            var mng = new SolicitudEstudianteManager();
            apiResp.Data = mng.RetrieveAll(cedulaFisica);

            return Ok(apiResp);
        }

        [Route("{id:int}/approve")]
        public IHttpActionResult PutApprove(int id, string cedulaFisica)
        {
            try
            {
                var mng = new SolicitudEstudianteManager();
                var solicitud = new SolicitudEstudiante
                {
                    IdSolicitud = id
                };

                mng.Approve(solicitud, cedulaFisica);

                apiResp = new ApiResponse();
                apiResp.Message = "La solicitud ha sido aprobada.";

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

        [Route("{id:int}/reject")]
        public IHttpActionResult PutReject(int id, string cedulaFisica)
        {
            try
            {
                var mng = new SolicitudEstudianteManager();
                var solicitud = new SolicitudEstudiante
                {
                    IdSolicitud = id
                };

                mng.Reject(solicitud, cedulaFisica);

                apiResp = new ApiResponse();
                apiResp.Message = "La solicitud ha sido rechazada.";

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

        [Route("pariente")]
        public IHttpActionResult Post([FromBody] SolicitudEstudiante solicitud, [FromUri] string cedulaFisicaPariente)
        {
            try
            {
                var mng = new SolicitudEstudianteManager();
                mng.Create(solicitud, cedulaFisicaPariente);

                apiResp = new ApiResponse();
                apiResp.Message = "OK";
                return Created("", apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

        [Route("pariente")]
        public IHttpActionResult GetSolicitudesPariente(string cedulaFisicaPariente)
        {
            apiResp = new ApiResponse();
            var mng = new SolicitudEstudianteManager();
            apiResp.Data = mng.RetrieveAllPariente(cedulaFisicaPariente);

            return Ok(apiResp);
        }
    }
}