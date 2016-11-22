using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALCSA.Negocio.Documentos
{
    public class GeneradorWord
    {
        public System.Web.HttpServerUtility Servidor { get; set; }

        public GeneradorWord(System.Web.HttpServerUtility servidor)
        {
            Servidor = servidor;
        }

        protected void GenerarArchivoDocxDesdeRutaHtml(string paginaWeb, string rutaNombreArchivoDestino)
        {
            using (System.IO.StreamReader objPagina = new System.IO.StreamReader(System.Net.WebRequest.Create(paginaWeb).GetResponse().GetResponseStream()))
            {
                GenerarArchivoDocxDesdeTextoHtml(objPagina.ReadToEnd(), rutaNombreArchivoDestino);
            }
        }

        protected void GenerarArchivoDocxDesdeRutasHtml(string[] paginasWeb, string rutaNombreArchivoDestino)
        {
            List<string> arrTextos = new List<string>();
            foreach(string strRuta in paginasWeb)
                using (System.IO.StreamReader objPagina = new System.IO.StreamReader(System.Net.WebRequest.Create(strRuta).GetResponse().GetResponseStream()))
                {
                    arrTextos.Add(objPagina.ReadToEnd());
                }

            GenerarArchivoDocxDesdeTextosHtml(arrTextos.ToArray(), rutaNombreArchivoDestino);
        }

        public void GenerarArchivoDocxDesdeRutaHtml(string paginaWeb, System.IO.Stream archivo)
        {
            GenerarArchivoDocxDesdeRutasHtml(new string[] { paginaWeb }, archivo);
        }

        public void GenerarArchivoDocxDesdeRutasHtml(string[] paginasWeb, System.IO.Stream archivo)
        {
            List<string> arrTextos = new List<string>();
            foreach (string strRuta in paginasWeb)
                using (System.IO.StreamReader objPagina = new System.IO.StreamReader(System.Net.WebRequest.Create(strRuta).GetResponse().GetResponseStream()))
                {
                    arrTextos.Add(objPagina.ReadToEnd());
                }

            GenerarArchivoDocxDesdeTextosHtml(arrTextos.ToArray(), archivo);
        }

        public void GenerarArchivoDocxDesdeTextoHtml(string textoHtml, string nombreArchivoDocx)
        {
            GenerarArchivoDocxDesdeTextosHtml(new string[] { textoHtml }, nombreArchivoDocx);
        }

        public void GenerarArchivoDocxDesdeTextosHtml(string[] textosHtml, string nombreArchivoDocx)
        {
            if (System.IO.File.Exists(nombreArchivoDocx)) System.IO.File.Delete(nombreArchivoDocx);
            using (System.IO.MemoryStream objArchivoMemoria = new System.IO.MemoryStream())
            {
                GenerarArchivoDocxDesdeTextosHtml(textosHtml, objArchivoMemoria);
                System.IO.File.WriteAllBytes(nombreArchivoDocx, objArchivoMemoria.ToArray());
            }
        }

        public void GenerarArchivoDocxDesdeTextoHtml(string textoHtml, System.IO.Stream archivo)
        {
            GenerarArchivoDocxDesdeTextosHtml(new string[] { textoHtml }, archivo);
        }

        public void GenerarArchivoDocxDesdeTextosHtml(string[] textosHtml, System.IO.Stream archivo)
        {
            using (DocumentFormat.OpenXml.Packaging.WordprocessingDocument objPaquete = DocumentFormat.OpenXml.Packaging.WordprocessingDocument.Create(archivo, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                DocumentFormat.OpenXml.Packaging.MainDocumentPart objDocumentoPrincipal = objPaquete.MainDocumentPart;
                if (objDocumentoPrincipal == null)
                {
                    objDocumentoPrincipal = objPaquete.AddMainDocumentPart();
                    new DocumentFormat.OpenXml.Wordprocessing.Document(new DocumentFormat.OpenXml.Wordprocessing.Body()).Save(objDocumentoPrincipal);
                }

                NotesFor.HtmlToOpenXml.HtmlConverter objConversorHtml = new NotesFor.HtmlToOpenXml.HtmlConverter(objDocumentoPrincipal);
                DocumentFormat.OpenXml.Wordprocessing.Body objCuerpo = objDocumentoPrincipal.Document.Body;
                objConversorHtml.ImageProcessing = NotesFor.HtmlToOpenXml.ImageProcessing.ManualProvisioning;
                objConversorHtml.ProvisionImage += eventoHtmlDoc_ProveerImagenes;

                for (int intIndiceHtml = 0; intIndiceHtml < textosHtml.Length; intIndiceHtml++)
                {
                    if (intIndiceHtml > 0)
                    {
                        Paragraph PageBreakParagraph = new Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Break() { Type = BreakValues.Page }));
                        objCuerpo.Append(PageBreakParagraph);
                    }

                    var arrParrafos = objConversorHtml.Parse(textosHtml[intIndiceHtml]);
                    foreach (var objParrafo in arrParrafos) objCuerpo.Append(objParrafo);
                }

                objDocumentoPrincipal.Document.Save();
            }
        }

        protected virtual void eventoHtmlDoc_ProveerImagenes(object sender, NotesFor.HtmlToOpenXml.ProvisionImageEventArgs e)
        {
            e.Data = System.IO.File.ReadAllBytes(Servidor.MapPath(e.ImageUrl.ToString()));
        }
    }
}
