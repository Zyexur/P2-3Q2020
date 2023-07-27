using Data_Access.Crud;
using Entities;
using Exceptions;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_API
{
    public class UnidadManager : BaseManager
    {
        private UnidadCrudFactory crudUnidad;

        public UnidadManager()
        {
            crudUnidad = new UnidadCrudFactory();
        }

        public void Create(Unidad unidad)
        {
            try
            {
                var u = crudUnidad.Retrieve<Unidad>(unidad);
                if (u != null)
                {
                    throw new BusinessException(7);
                }
                crudUnidad.Create(unidad);
                GenerarCodigo(unidad);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void GenerarCodigo(Unidad unidad)
        {
            var nombrePDF = unidad.Placa;
            var contenidoPDF = "PLACA: " + unidad.Placa + " ID EMPRESA: " + unidad.IdEmpresa + " ID RUTA: " + unidad.IdRuta + " ID CHOFER " + unidad.IdChofer;
            Document doc = new Document(PageSize.A4);
            PdfWriter.GetInstance(doc, new FileStream(@"C:\Arrival\UnidadesQR\" + nombrePDF + ".pdf", FileMode.Create));
            doc.Open();
            BarcodeQRCode barcodeQRcode = new BarcodeQRCode(contenidoPDF, 1000, 1000, null);
            Image codeQRimage = barcodeQRcode.GetImage();
            codeQRimage.ScaleAbsolute(200, 200);
            doc.Add(codeQRimage);

            doc.Close();
        }

        public List<Unidad> RetrieveAll(BaseEntity entity)
        {
            return crudUnidad.RetrieveAllByEmpresa<Unidad>(entity);
        }

        public Unidad RetrieveById(BaseEntity entity)
        {
            return crudUnidad.RetrieveByPlaca<Unidad>(entity);
        }

        public void Update(BaseEntity entity)
        {
            try
            {
                crudUnidad.Update(entity);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void Delete(BaseEntity entity)
        {
            crudUnidad.Delete(entity);
        }

    }
}
