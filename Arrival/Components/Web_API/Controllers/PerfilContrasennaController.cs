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
    public class PerfilContrasennaController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new UsuarioManager();
                var usuario = new Usuario
                {
                    CedulaFisica = id
                };
                usuario = mng.RetrieveById(usuario); 
                apiResp = new ApiResponse();
                apiResp.Data = usuario;
                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.MessageText));
            }
        }

        public IHttpActionResult Put([FromBody] Usuario usuario, [FromUri] string id)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new UsuarioManager();
                var usr = new Usuario
                {
                    CedulaFisica = id,
                    Contrasenna = usuario.Contrasenna
                    
                };
                mng.UpdateContrasenna(usr);
                apiResp.Message = "OK";
                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.MessageText));
            }
        }

        public IHttpActionResult Put(Usuario usuario)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new UsuarioManager();
                mng.Update(usuario);
                apiResp.Message = "OK";
                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.MessageText));
            }
        }

    }

}
