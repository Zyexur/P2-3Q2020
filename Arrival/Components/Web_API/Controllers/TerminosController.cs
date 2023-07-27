using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities;
using Core_API;
using Web_API.Models;

namespace Web_API.Controllers
{
    [ExceptionFilter]
    public class TerminosController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new TerminosManager();
                apiResp.Data = mng.RetrieveAll();

                return Ok(apiResp);
            }
            catch (Exception ex)
            {
                return BadRequest(apiResp.Message = ex.Message);
            }

        }

        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new TerminosManager();
                var tc = new TerminosCondiciones
                {
                    IdApartado = Convert.ToInt32(id)
                };

                tc = mng.Retrieve(tc);
                apiResp = new ApiResponse();
                apiResp.Data = tc;
                return Ok(apiResp);
            }
            catch (Exception ex)
            {
                return BadRequest(apiResp.Message = ex.Message);
            }
        }

        public IHttpActionResult Post(TerminosCondiciones tc)
        {

            try
            {
                var mng = new TerminosManager();
                mng.Create(tc);
                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (Exception ex)
            {
                return BadRequest(apiResp.Message = ex.Message);
            }
        }

        public IHttpActionResult Put(TerminosCondiciones tc)
        {
            try
            {
                var mng = new TerminosManager();
                mng.Update(tc);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (Exception ex)
            {
                return BadRequest(apiResp.Message = ex.Message);
            }
        }

        public IHttpActionResult Delete(TerminosCondiciones tc)
        {
            try
            {
                var mng = new TerminosManager();
                mng.Delete(tc);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (Exception ex)
            {
                return BadRequest(apiResp.Message = ex.Message);
            }
        }
    }
}