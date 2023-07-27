using Core_API;
using Entities;
using Exceptions;
using System;
using System.Web.Http;
using Web_API.Models;

namespace Web_API.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        //TODO: Modificar contrasenna
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new UsuarioManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        public IHttpActionResult Post(Usuario usuario)
        {
            try
            {
                var mng = new UsuarioManager();
                mng.Create(usuario);

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

        [Route("{centroEducativo}")]
        public IHttpActionResult PostUsuarioCe(Usuario usuario, string centroEducativo)
        {

            try
            {
                var mng = new UsuarioManager();
                mng.CreateUsuarioCe(usuario, centroEducativo);

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

        [Route("iniciar")]
        public IHttpActionResult PostIniciarSesion(Usuario usuario)
        {

            try
            {
                var mng = new UsuarioManager();
                var user = mng.Iniciar(usuario);

                apiResp = new ApiResponse();
                apiResp.Message = "Inicio de sesión correcto.";
                apiResp.Data = user;

                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.MessageText));
            }
        }

        public IHttpActionResult Get(string correo, string codigo)
        {
            try
            {
                var mng = new UsuarioManager();
                var usuario = new Usuario
                {
                    Correo = correo,
                    Codigo = codigo
                };
                usuario = mng.Retrieve(usuario);
                if (usuario.Codigo != codigo)
                {
                    usuario.Codigo = null;
                }
                else
                {
                    mng.Activate(usuario);
                }
                apiResp = new ApiResponse();
                apiResp.Data = usuario;
                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.MessageText));
            }
        }

        public IHttpActionResult Put(string correo)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new UsuarioManager();
                var usuario = new Usuario
                {
                    Correo = correo
                };
                mng.Update(usuario);
                apiResp.Message = "OK";
                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.MessageText));
            }
        }

        [Route("activar")]
        public IHttpActionResult PutActivar(Usuario usuario)
        {

            try
            {
                apiResp = new ApiResponse();
                var mng = new UsuarioManager();
                usuario.EstadoUsuario = "ACTIVO";
                mng.UpdateEstado(usuario);
                apiResp.Message = "OK";
                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.MessageText));
            }
        }

        [Route("desactivar")]
        public IHttpActionResult PutDesactivar(Usuario usuario)
        {

            try
            {
                apiResp = new ApiResponse();
                var mng = new UsuarioManager();
                usuario.EstadoUsuario = "INACTIVO";
                mng.UpdateEstado(usuario);
                apiResp.Message = "OK";
                return Ok(apiResp);
            }
            catch (BusinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + " - " + bex.AppMessage.MessageText));
            }
        }

        public IHttpActionResult Delete(Usuario usuario)
        {
            try
            {
                var mng = new UsuarioManager();
                mng.Delete(usuario);

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

        [Route("pariente/estudiantes")]
        public IHttpActionResult PostEstudiante([FromBody] Usuario usuario, [FromUri] string cedulaFisicaPariente)
        {
            try
            {
                var mng = new UsuarioManager();
                mng.CreateUsuarioEstudiante(usuario, cedulaFisicaPariente);

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

        [Route("pariente/estudiantes")]
        public IHttpActionResult GetEstudiantesPariente(string cedulaFisicaPariente, bool sin_centro)
        {
            var u = new Usuario();
            u.CedulaFisica = cedulaFisicaPariente;
            apiResp = new ApiResponse();
            var mng = new UsuarioManager();
            if (sin_centro)
            {
                apiResp.Data = mng.RetrieveEstudiantesSinCentro(u);
            }
            else
            {
                apiResp.Data = mng.RetrieveEstudiantesPariente(u);
            }
            return Ok(apiResp);
        }

        [Route("estudiantes/ruta")]
        public IHttpActionResult GetEstudiantesRuta(string cedulaFisicaChofer)
        {
            var u = new Usuario();
            u.CedulaFisica = cedulaFisicaChofer;
            apiResp = new ApiResponse();
            var mng = new UsuarioManager();
            apiResp.Data = mng.RetrieveEstudiantesRuta(u);
            return Ok(apiResp);
        }
    }
}

