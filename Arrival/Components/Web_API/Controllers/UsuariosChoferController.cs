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
    [System.Web.Http.RoutePrefix("api/UsuariosChofer")]
    public class UsuariosChoferController : ApiController
    {
        // GET: UsuariosChofer
        ApiResponse apiResp = new ApiResponse();

        [System.Web.Http.Route("{cedulaJuridica}")]
        public IHttpActionResult Post(Usuario usuario, string cedulaJuridica)
        {
            try
            {
                var mng = new UsuarioManager();
                mng.CreateUsuarioChofer(usuario, cedulaJuridica);

                apiResp = new ApiResponse();
                apiResp.Message = "OK";
                apiResp.Data = usuario;
                return Created("", apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }
    }
}