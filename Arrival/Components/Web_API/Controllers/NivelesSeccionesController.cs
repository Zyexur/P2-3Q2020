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
    public class NivelesSeccionesController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new NivelesSeccionesManager();
                var nivelesSecciones = new NivelesSecciones
                {
                    IdCentroEdu = id
                };
                apiResp = new ApiResponse();
                apiResp.Data = mng.RetrieveAllById(nivelesSecciones);

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }
    }
}