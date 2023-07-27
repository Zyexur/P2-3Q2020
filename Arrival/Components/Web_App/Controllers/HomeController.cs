using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Your index page.";

            return View();
        }

        public ActionResult Registro()
        {
            ViewBag.Message = "Your registration page.";

            return View();
        }

        public ActionResult RegistroAdminCE()
        {
            ViewBag.Message = "Your registration page.";

            return View();
        }

        public ActionResult LandingPage()
        {
            ViewBag.Message = "Your landing page.";

            return View();
        }

        public ActionResult InicioSesion()
        {
            ViewBag.Message = "Your logIn page.";

            return View();
        }

        public ActionResult RecuperarContrasenna()
        {
            ViewBag.Message = "Your password recover page.";

            return View();
        }

        public ActionResult ValidarCuenta()
        {
            ViewBag.Message = "Your account validation page.";

            return View();
        }


        public ActionResult RegistrarContrasenna()
        {
            ViewBag.Message = "Your password register page.";

            return View();
        }

        public ActionResult PerfilAdmin()
        {
            ViewBag.Message = "Your profile admin page";

            return View();
        }

        public ActionResult DashboardAdmin()
        {
            ViewBag.Message = "Your dashboard admin page";

            return View();
        }

        public ActionResult SolicitudesAdmin()
        {
            ViewBag.Message = "Your requests admin page";

            return View();
        }

        public ActionResult EmpresasAdmin()
        {
            ViewBag.Message = "Your companies admin page";

            return View();
        }

        public ActionResult UsuariosAdmin()
        {
            ViewBag.Message = "Your users admin page";

            return View();
        }

        public ActionResult MembresiasAdmin()
        {
            ViewBag.Message = "Your membership admin page";

            return View();
        }

        public ActionResult TerminosAdmin()
        {
            ViewBag.Message = "Your term and conditions admin page";

            return View();
        }

        public ActionResult BitacoraAdmin()
        {
            ViewBag.Message = "Your bitácora admin page";

            return View();
        }

        public ActionResult VerificacionCodigo()
        {
            ViewBag.Message = "Your code verification page";

            return View();
        }

        public ActionResult RutasAdminCe()
        {
            ViewBag.Message = "Your routes admin page";

            return View();
        }

        public ActionResult CentroEducativoAdminCe()
        {
            ViewBag.Message = "Your education institution admin page";

            return View();
        }

        public ActionResult EventosAdminCe()
        {
            ViewBag.Message = "Your events admin page";

            return View();
        }

        public ActionResult UsuariosAdminCe()
        {
            ViewBag.Message = "Your usuario admin ce page";

            return View();
        }

        public ActionResult RegistroAdminCeHome()
        {
            ViewBag.Message = "Your registro admin ce home page";

              return View();
        }

        public ActionResult RegistroTransportista()
        {
            ViewBag.Message = "Your registro transportista home page";

            return View();
        }

        public ActionResult RegistroAdminGeneralHome()
        {
            ViewBag.Message = "Your registro transportista ce home page";

            return View();
        }

        public ActionResult SolicitudesAdminCE()
        {
            ViewBag.Message = "Your requests admin page";

            return View();
        }

        public ActionResult EmpresaTransporte()
        {
            ViewBag.Message = "Your registration page";

            return View();
        }

        public ActionResult NivelSeccion()
        {
            ViewBag.Message = "Your nivel y seccion page.";

            return View();
        }

        public ActionResult Unidades()
        {
            ViewBag.Message = "Your unidades page.";

            return View();
        }

        public ActionResult RegistroPariente()
        {
            ViewBag.Message = "Your registro pariente home page";

            return View();
        }
        public ActionResult EmpresasTransporteCE()
        {
            ViewBag.Message = "Your transportation companies page.";

            return View();
        }

        public ActionResult RegistroChoferCeHome()
        {
            ViewBag.Message = "Your chofer register page.";

            return View();
        }

        public ActionResult PerfilAdminCe()
        {
            ViewBag.Message = "Your profile admin page";

            return View();
        }
        public ActionResult CentrosEducativosTR()
        {
            ViewBag.Message = "Your CE companies page.";

            return View();
        }

        public ActionResult UsuariosTransportista()
        {
            ViewBag.Message = "Your transportista companies page.";
            return View();
        }
        
        public ActionResult EstudiantesPariente()
        {
            ViewBag.Message = "Your students page.";

            return View();
        }

        public ActionResult SolicitudesPariente()
        {
            ViewBag.Message = "Your requests page.";

            return View();
        }

        public ActionResult PerfilTransportista()
        {
            ViewBag.Message = "Your perfil transportista page";

            return View();
        }

        public ActionResult PerfilPariente()
        {
            ViewBag.Message = "Your perfil pariente page";

            return View();
        }

        public ActionResult Viajes()
        {
            ViewBag.Message = "Your trips page.";

            return View();
        }

        public ActionResult PerfilChofer()
        {
            ViewBag.Message = "Your perfil chofer page.";

            return View();
        }
    }
}