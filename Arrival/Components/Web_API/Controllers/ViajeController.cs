using Core_API;
using Entities;
using Exceptions;
using System;
using System.Web.Http;
using Web_API.Models;

namespace Web_API.Controllers
{
    [RoutePrefix("api/viaje")]
    public class ViajeController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        public IHttpActionResult Get(string cedulaFisicaChofer)
        {
            apiResp = new ApiResponse();
            var mng = new ViajeManager();
            apiResp.Data = mng.RetrieveViaje(cedulaFisicaChofer);

            return Ok(apiResp);
        }

        public IHttpActionResult Post(Viaje viaje)
        {
            try
            {
                var mng = new ViajeManager();
                mng.Abordaje(viaje);
                apiResp = new ApiResponse();
                apiResp.Message = "OK";
                return Created("", apiResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Put(Viaje viaje)
        {
            try
            {
                var mng = new ViajeManager();
                mng.Start(viaje);
                apiResp = new ApiResponse();
                apiResp.Message = "OK";
                return Ok(apiResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Delete(Viaje viaje)
        {
            try
            {
                var mng = new ViajeManager();
                mng.End(viaje);
                apiResp = new ApiResponse();
                apiResp.Message = "OK";
                return Ok(apiResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("estudiantes")]
        public IHttpActionResult GetEstudiantes(string cedulaFisicaChofer)
        {
            apiResp = new ApiResponse();
            var mng = new ViajeManager();
            apiResp.Data = mng.RetrieveEstudiantes(cedulaFisicaChofer);

            return Ok(apiResp);
        }

        [Route("estudiantes/add")]
        public IHttpActionResult PostEstudiante(string cedulaFisicaChofer, string cedulaFisicaEstudiante)
        {
            var mng = new ViajeManager();
            mng.AddEstudiante(cedulaFisicaChofer,cedulaFisicaEstudiante);
            apiResp = new ApiResponse();
            apiResp.Message = "OK";
            return Ok(apiResp);
        }

        [Route("estudiantes/remove")]
        public IHttpActionResult DeleteEstudiante(string cedulaFisicaChofer, string cedulaFisicaEstudiante)
        {
            var mng = new ViajeManager();
            mng.RemoveEstudiante(cedulaFisicaChofer, cedulaFisicaEstudiante);
            apiResp = new ApiResponse();
            apiResp.Message = "OK";
            return Ok(apiResp);
        }
    }
}

