using Core_API;
using Entities;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Web_API.Models;

namespace Web_API.Controllers
{

    public class UsuariosCentroController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        // GET: UsuariosCentro
        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new UsuarioManager();
                var emp = new Empresa
                {
                    CedulaJuridica = id
                };
                apiResp = new ApiResponse();
                apiResp.Data = mng.RetrieveByCentro(emp);

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

        public IHttpActionResult GetEstudiantes(string centroeducativoestudiante)
        {
            try
            {
                var mng = new UsuarioManager();
                var emp = new Empresa
                {
                    CedulaJuridica = centroeducativoestudiante
                };
                apiResp = new ApiResponse();
                apiResp.Data = mng.RetrieveByCentroEstudiante(emp);

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

        public IHttpActionResult GetTransportistas(string centroeducativotransportista)
        {
            try
            {
                var mng = new UsuarioManager();
                var emp = new Empresa
                {
                    CedulaJuridica = centroeducativotransportista
                };
                apiResp = new ApiResponse();
                apiResp.Data = mng.RetrieveByCentroTransportista(emp);

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

    }
}