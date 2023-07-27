using Data_Access.Crud;
using Entities;
using Exceptions;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;

namespace Core_API
{
    public class UsuarioManager : BaseManager
    {
        private UsuarioCrudFactory crudUsuario;
        private BitacoraCrudFactory crudBitacora;
        private static readonly Random random = new Random();

        public UsuarioManager()
        {
            crudUsuario = new UsuarioCrudFactory();
            crudBitacora = new BitacoraCrudFactory();
        }

        public void Create(Usuario usuario)
        {
            try
            {
                var u = crudUsuario.Retrieve<Usuario>(usuario);
                if (u != null) //usuario ya existe
                {
                    throw new BusinessException(5);
                }
                else
                {
                    var codigo = RandomCode(6);
                    usuario.Codigo = codigo;
                    crudUsuario.Create(usuario);

                    if (usuario.Rol.Equals("Estudiante"))
                    {
                        GenerarCodigo(usuario);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void GenerarCodigo(Usuario usuario)
        {
            var nombrePDF = usuario.CedulaFisica;
            var contenidoPDF = "CEDULA: " + usuario.CedulaFisica + " NOMBRE: " + usuario.Nombre + " APELLIDO: " + usuario.Apellido + " CORREO: " + usuario.Correo;
            Document doc = new Document(PageSize.A4);
            PdfWriter.GetInstance(doc, new FileStream(@"C:\Arrival\EstudiantesQR\" + nombrePDF + ".pdf", FileMode.Create));
            doc.Open();
            BarcodeQRCode barcodeQRcode = new BarcodeQRCode(contenidoPDF, 1000, 1000, null);
            Image codeQRimage = barcodeQRcode.GetImage();
            codeQRimage.ScaleAbsolute(200, 200);
            doc.Add(codeQRimage);

            doc.Close();
        }

        public void CreateUsuarioCe(Usuario usuario, string centroEducativo)
        {
            try
            {
                var u = crudUsuario.Retrieve<Usuario>(usuario);
                if (u != null)
                {
                    throw new BusinessException(5);
                }
                else
                {
                    var codigo = RandomCode(6);
                    usuario.Codigo = codigo;
                    crudUsuario.Create(usuario);
                    crudUsuario.AsociarEmpresa(centroEducativo, usuario.CedulaFisica);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void CreateUsuarioChofer(Usuario usuario, string centroEducativo)
        {
            try
            {
                var u = crudUsuario.Retrieve<Usuario>(usuario);
                if (u != null)
                {
                    throw new BusinessException(5);
                }
                else
                {
                    usuario.Coordenada = "0";
                    var codigo = RandomCode(6);
                    usuario.Codigo = codigo;
                    crudUsuario.CreateChofer(usuario);
                    crudUsuario.AsociarEmpresa(centroEducativo, usuario.CedulaFisica);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public Usuario Iniciar(Usuario usuario)
        {
            Usuario u = null;
            try
            {
                u = crudUsuario.Retrieve<Usuario>(usuario);
                if (u != null) //usuario existe
                {
                    if (u.Contrasenna == usuario.Contrasenna)
                    {
                        return u;
                    }
                    else
                    {
                        //contraseña incorrecta
                        throw new BusinessException(0);
                    };
                }
                else
                {
                    //usuario no existe
                    throw new BusinessException(0);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return u;
        }

        public void Update(Usuario usuario)
        {
            try
            {
                crudUsuario.Update(usuario);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void UpdateEstado(Usuario usuario)
        {
            try
            {
                crudUsuario.UpdateEstado(usuario);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void Activate(Usuario usuario)
        {
            try
            {
                crudUsuario.Activate(usuario);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void Delete(Usuario usuario)
        {
            try
            {
                if (usuario.CedulaFisica.Equals(""))
                {
                    throw new BusinessException(3);
                }

                crudUsuario.Delete(usuario);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Usuario> RetrieveAll()
        {
            return crudUsuario.RetrieveAll<Usuario>();
        }

        public List<Usuario> RetrieveByCentro(BaseEntity entity)
        {
            return crudUsuario.RetrieveAllByCentro<Usuario>(entity);
        }

        public List<Usuario> RetrieveByTransportista(BaseEntity entity)
        {
            return crudUsuario.RetrieveAllByTransportista<Usuario>(entity);
        }

        public List<Usuario> RetrieveByChofer(BaseEntity entity)
        {
            return crudUsuario.RetrieveAllByChofer<Usuario>(entity);
        }
        
        public List<Usuario> RetrieveByCentroEstudiante(BaseEntity entity)
        {
            List<Usuario> usuarios = crudUsuario.RetrieveAllByCentro<Usuario>(entity);
            List<Usuario> estudiantes = new List<Usuario>();
            foreach (var item in usuarios)
            {
                if (item.Rol.Equals("Estudiante"))
                {
                    estudiantes.Add(item);
                }
            }
            return estudiantes;
        }

        public List<Usuario> RetrieveByCentroTransportista(BaseEntity entity)
        {
            List<Usuario> usuarios = crudUsuario.RetrieveAllByCentro<Usuario>(entity);
            List<Usuario> transportistas = new List<Usuario>();
            foreach (var item in usuarios)
            {
                if (item.Rol.Equals("Transportista"))
                {
                    transportistas.Add(item);
                }
            }
            return transportistas;
        }

        public void CreateContrasenna(Usuario usuario)
        {
            try
            {
                if (usuario.Correo.Equals("") || usuario.Contrasenna.Equals(""))
                {
                    throw new BusinessException(2);
                }

                Usuario u = null;
                u = crudUsuario.Retrieve<Usuario>(usuario);
                if (u == null) //usuario no existe
                {
                    throw new BusinessException(3);
                }
                crudUsuario.CreateContrasenna(usuario);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public Usuario Retrieve(Usuario usuario)
        {
            Usuario u = null;
            try
            {
                u = crudUsuario.Retrieve<Usuario>(usuario);
                if (u == null) //usuario no existe
                {
                    throw new BusinessException(3);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return u;
        }

        public Usuario RetrieveById(Usuario usuario)
        {
            Usuario c = crudUsuario.RetrieveById<Usuario>(usuario);
            return c;
        }

        public void UpdateContrasenna(Usuario usuario)
        {
            crudUsuario.UpdateContrasenna(usuario);
        }

        public static string RandomCode(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[length];
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new string(stringChars);
            return finalString;
        }

        public void CreateUsuarioEstudiante(Usuario usuario, string cedulaFisicaPariente)
        {
            try
            {
                var accion = new Bitacora
                {
                    Accion = "Estudiante creado",
                    CedulaFisica = cedulaFisicaPariente,
                    Fecha = DateTime.Now
                };
                var u = crudUsuario.Retrieve<Usuario>(usuario);
                if (u != null)
                {
                    throw new BusinessException(5);
                }
                else
                {
                    crudUsuario.CreateEstudiante(usuario);
                    crudUsuario.AsociarEstudiantePariente(cedulaFisicaPariente, usuario.CedulaFisica);
                    crudBitacora.Create(accion);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Usuario> RetrieveEstudiantesPariente(BaseEntity entity)
        {
            return crudUsuario.RetrieveEstudiantesPariente<Usuario>(entity);
        }

        public List<Usuario> RetrieveEstudiantesSinCentro(BaseEntity entity)
        {
            return crudUsuario.RetrieveEstudiantesSinCentro<Usuario>(entity);
        }

        public List<Usuario> RetrieveEstudiantesRuta(BaseEntity entity)
        {
            return crudUsuario.RetrieveEstudiantesRuta<Usuario>(entity);
        }


    }
}
