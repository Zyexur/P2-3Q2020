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
    public class ContrasennaController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Post(Usuario usuario)
        {

            try
            {
                var mng = new UsuarioManager();
                mng.CreateContrasenna(usuario);
                apiResp = new ApiResponse();              
                apiResp.Message = "La acción fue realizada";

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }
       
        public IHttpActionResult Get(string correo)
        {
            try
            {
                var mng = new UsuarioManager();
                var usuario = new Usuario
                {
                    Correo = correo
                };
                usuario = mng.Retrieve(usuario);
                apiResp = new ApiResponse();
                apiResp.Message = "La acción fue realizada";
                apiResp.Data = usuario;
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
                var mng = new UsuarioManager();
                mng.UpdateContrasenna(usuario);

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
