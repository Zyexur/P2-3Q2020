using Core_API;
using Entities;
using Exceptions;
using System;
using System.Web.Http;
using Web_API.Models;

namespace Web_API.Controllers
{
    public class PerfilController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new PerfilManager();
                var perfil = new Perfil
                {
                    Rol = id
                };

                apiResp = new ApiResponse();
                apiResp.Data = mng.RetrieveAllById(perfil);
                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

        public IHttpActionResult Post(Perfil perfil)
        {
            try
            {
                var mng = new PerfilManager();
                mng.Create(perfil);

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

        public IHttpActionResult Put(Perfil perfil)
        {
            try
            {
                var mng = new PerfilManager();
                mng.Update(perfil);

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