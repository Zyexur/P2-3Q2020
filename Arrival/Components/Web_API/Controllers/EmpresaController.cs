using Core_API;
using Entities;
using Exceptions;
using System;
using System.Web.Http;
using Web_API.Models;

namespace Web_API.Controllers
{
    [RoutePrefix("api/empresa")]
    public class EmpresaController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        Empresa empresa = new Empresa();

        [Route("Empresas")]
        public IHttpActionResult GetEmpresas()
        {
            try
            {
                var mng = new EmpresaManager();
                apiResp.Data = mng.RetrieveAll();
                apiResp.Message = "OK";
                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

        public IHttpActionResult GetEmpresa(string cedulaJuridica)
        {
            try
            {
                var mng = new EmpresaManager();
                empresa.CedulaJuridica = cedulaJuridica;
                apiResp.Data = mng.RetrieveById(empresa);
                apiResp.Message = "OK";
                return Ok(apiResp);
            }catch(BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

        [Route("CentrosEducativos")]
        public IHttpActionResult GetCentrosEducativos()
        {
            try
            {
                var mng = new EmpresaManager();
                apiResp.Data = mng.RetrieveAllCE();
                apiResp.Message = "OK";
                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }


        [Route("CentrosEducativos")]
        public IHttpActionResult GetCentrosEducativosById(string cedulaTr)
        {
            try
            {
                var mng = new EmpresaManager();
                apiResp.Data = mng.RetrieveAllCEById(cedulaTr);
                apiResp.Message = "OK";
                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

        [Route("Transportistas")]
        public IHttpActionResult GetTransportistas()
        {
            try
            {
                var mng = new EmpresaManager();
                apiResp.Data = mng.RetrieveAllTrans();
                apiResp.Message = "OK";
                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

        [Route("Transportistas")]
        public IHttpActionResult GetTransportistasById(string cedulaCe)
        {
            try
            {
                var mng = new EmpresaManager();
                apiResp.Data = mng.RetrieveAllTransById(cedulaCe);
                apiResp.Message = "OK";
                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

        public IHttpActionResult GetEmpresaByUserId(string cedulaFisica)
        {
            try
            {
                var mng = new EmpresaManager();
                apiResp = new ApiResponse();
                apiResp.Data = mng.RetrieveEmpresaByUserId(cedulaFisica);

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

        public IHttpActionResult GetEmpresasTransporteByCJ(string cj)
        {
            try
            {
                var mng = new EmpresaManager();
                apiResp = new ApiResponse();
                apiResp.Data = mng.RetrieveEmpresasTransporteByCJ(cj);

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

        public IHttpActionResult Post([FromBody] Empresa empresa, [FromUri] string cedulaFisica)
        {
            try
            {
                var mng = new EmpresaManager();
                mng.Create(empresa, cedulaFisica);
                apiResp = new ApiResponse();
                apiResp.Message = "OK";
                return Created("", apiResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Put([FromBody] Empresa empresa, [FromUri] string cedulaFisica)
        {
            try
            {
                var mng = new EmpresaManager();
                mng.Update(empresa, cedulaFisica);

                apiResp = new ApiResponse();
                apiResp.Message = "Actualización exitosa.";

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }

        }

        public IHttpActionResult Delete([FromBody] Empresa empresa, [FromUri] string cedulaFisica)
        {
            try
            {
                var mng = new EmpresaManager();
                mng.Delete(empresa, cedulaFisica);

                apiResp = new ApiResponse();
                apiResp.Message = "Eliminación exitosa.";

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }
    }
}
