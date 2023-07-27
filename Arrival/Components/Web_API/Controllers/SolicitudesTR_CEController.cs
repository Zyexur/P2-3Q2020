using Core_API;
using Entities;
using Exceptions;
using System;
using System.Web.Http;
using Web_API.Models;


namespace Web_API.Controllers
{
    public class SolicitudesTR_CEController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        SolicitudTR_CE solicitud = new SolicitudTR_CE();

        public IHttpActionResult Get(string cedulaJuridica)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new SolicitudTR_CEManager();
                solicitud.CedulaCE = cedulaJuridica;
                apiResp.Data = mng.RetrieveAllSolicitudes(solicitud);

                return Ok(apiResp);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        public IHttpActionResult Post(SolicitudTR_CE solicitud)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new SolicitudTR_CEManager();
                var existe = mng.RetrieveSolicitud(solicitud);
                if (existe)
                {
                    apiResp.Message = "existe";
                    return Ok(apiResp);
                }
                else
                {
                    mng.Create(solicitud);
                    apiResp.Message = "OK";
                    return Ok(apiResp);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        public IHttpActionResult Put(SolicitudTR_CE solicitud)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new SolicitudTR_CEManager();
                mng.Update(solicitud);
                apiResp.Message = "OK";

                return Ok(apiResp);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
