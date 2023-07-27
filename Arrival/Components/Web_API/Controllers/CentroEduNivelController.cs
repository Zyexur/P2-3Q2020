using Core_API;
using Entities;
using Exceptions;
using System;
using System.Web.Http;
using Web_API.Models;

namespace Web_API.Controllers
{
    public class CentroEduNivelController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new CentroEduNivelManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }


        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new CentroEduNivelManager();
                var centroEduNivel = new CentroEducativoNivel
                {
                    IdCentroEdu = id
                };

                apiResp = new ApiResponse();
                apiResp.Data = mng.RetrieveAllById(centroEduNivel);
                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

        // POST 
        // CREATE
        public IHttpActionResult Post(CentroEducativoNivel centroEduNivel)
        {
            try
            {
                var mng = new CentroEduNivelManager();
                mng.Create(centroEduNivel);

                apiResp = new ApiResponse();
                apiResp.Message = "La acción fue realizada";

                return Ok(apiResp);

            }
            catch (BusinessException)
            {
                return Ok();
                    //InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }
    }
}