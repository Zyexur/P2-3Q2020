using Core_API;
using Entities;
using Exceptions;
using System;
using System.Web.Http;
using Web_API.Models;

namespace Web_API.Controllers
{
    [RoutePrefix("api/solicitudes")]
    public class SolicitudEmpresaController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new SolicitudEmpresaManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        [Route("{id:int}/approve")]
        public IHttpActionResult PutApprove(int id)
        {
            try
            {
                var mng = new SolicitudEmpresaManager();
                var solicitud = new SolicitudEmpresa
                {
                    IdSolicitud = id
                };

                mng.Approve(solicitud);

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
        public IHttpActionResult PutReject(int id)
        {
            try
            {
                var mng = new SolicitudEmpresaManager();
                var solicitud = new SolicitudEmpresa
                {
                    IdSolicitud = id
                };

                mng.Reject(solicitud);

                apiResp = new ApiResponse();
                apiResp.Message = "La solicitud ha sido rechazada.";

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }
    }
}