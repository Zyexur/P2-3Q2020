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
    public class MembresiaController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        // GET api/membresia
        // Retrieve

        //TODO: api.Response.Message tiene que estar en español
        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new MembresiaManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        // GET api/membresia/5
        // Retrieve by id
        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new MembresiaManager();
                var membresia = new Membresia
                {
                    IdMembresia = Convert.ToInt32(id)
                };

                membresia = mng.RetrieveById(membresia);
                apiResp = new ApiResponse();
                apiResp.Data = membresia;
                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

        // POST 
        // CREATE
        public IHttpActionResult Post(Membresia membresia)
        {

            try
            {
                var mng = new MembresiaManager();
                mng.Create(membresia);

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
        public IHttpActionResult Put(Membresia membresia)
        {
            try
            {
                var mng = new MembresiaManager();
                mng.Update(membresia);

                apiResp = new ApiResponse();
                apiResp.Message = "La acción fue realizada";

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

        public IHttpActionResult Delete(Membresia membresia)
        {
            try
            {
                var mng = new MembresiaManager();
                mng.Delete(membresia);

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
