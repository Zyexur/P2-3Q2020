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
    public class UnidadController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get(string id)
        {
            apiResp = new ApiResponse();
            var mng = new UnidadManager();

            var unidad = new Unidad
            {
                IdEmpresa = id
            };

            apiResp.Data = mng.RetrieveAll(unidad);

            return Ok(apiResp);
        }

        // POST 
        // CREATE
        public IHttpActionResult Post(Unidad unidad)
        {

            try
            {
                var mng = new UnidadManager();
                mng.Create(unidad);

                apiResp = new ApiResponse();
                apiResp.Message = "La acción fue realizada";

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

        // PUT
        // UPDATE
        public IHttpActionResult Put(Unidad unidad)
        {
            try
            {
                var mng = new UnidadManager();
                mng.Update(unidad);

                apiResp = new ApiResponse();
                apiResp.Message = "La acción fue realizada";

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

        public IHttpActionResult Delete(Unidad unidad)
        {
            try
            {
                var mng = new UnidadManager();
                mng.Delete(unidad);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }
    }
}