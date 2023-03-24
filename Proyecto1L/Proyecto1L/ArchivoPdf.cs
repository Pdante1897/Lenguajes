using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Proyecto1L
{
    public class ArchivoPdf
    {
        public void crearPdf(String rutaImg)
        {
            iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.LETTER);
            PdfWriter.GetInstance(doc, new FileStream("C:\\proyecto\\reporte.pdf", FileMode.Create));
            doc.Open();
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(rutaImg);
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_LEFT;
            float porcentage;
            porcentage = 500 / imagen.Width;
            imagen.ScalePercent(porcentage * 100);
            doc.Add(imagen);
            doc.Close();
            abrirPdf();
        }

        public void abrirPdf()
        {
            string pdfPath = Path.Combine(Application.StartupPath, "C:\\proyecto\\reporte.pdf");
            Process.Start(pdfPath);
        }

        public void htmlToken(LinkedList<Token> lista)
        {
            String dir;
            int contador = 1;
            dir = "C:\\proyecto\\tokens.html";
            File.WriteAllText(dir, "");
            StreamWriter escribir = new StreamWriter(dir);
            escribir.WriteLine("<html>");
            escribir.WriteLine("<body>");
            escribir.WriteLine("<table border=" + '"' + '1' + '"' + ">");
            escribir.WriteLine("<tr>");
            escribir.WriteLine("<td>#</td>");
            escribir.WriteLine("<td>fila</td>");
            escribir.WriteLine("<td>columna</td>");
            escribir.WriteLine("<td>lexema</td>");
            escribir.WriteLine("<td>ide Token</td>");
            escribir.WriteLine("<td>Token</td>");
            escribir.WriteLine("</tr>");
            foreach (Token item in lista)
            {
                if (!item.GetTipo().Equals("Desconocido"))
                {
                    escribir.WriteLine("<tr>");
                    escribir.WriteLine("<td>" + item.GetId() + "</td>");
                    escribir.WriteLine("<td>" + item.GetFila() + "</td>");
                    escribir.WriteLine("<td>" + item.GetColumna() + "</td>");
                    escribir.WriteLine("<td>" + item.GetValor() + "</td>");
                    escribir.WriteLine("<td>" + item.GetId() + "</td>");
                    escribir.WriteLine("<td>" + item.GetTipo() + "</td>");
                    escribir.WriteLine("</tr>");
                    contador++;
                }
            }
            escribir.WriteLine("</table>");
            escribir.WriteLine("</body>");
            escribir.WriteLine("</html>");
            escribir.Close();


        }
        public void htmlError(LinkedList<Error> lista2)
        {
            String dir = "C:\\proyecto\\errores.html";
            StreamWriter escribir2 = new StreamWriter(dir);
            escribir2.WriteLine("<html>");
            escribir2.WriteLine("<body>");
            escribir2.WriteLine("<table border=" + '"' + '1' + '"' + ">");
            escribir2.WriteLine("<tr>");
            escribir2.WriteLine("<td>#</td>");
            escribir2.WriteLine("<td>Fila</td>");
            escribir2.WriteLine("<td>Columna</td>");
            escribir2.WriteLine("<td>Caracter</td>");
            escribir2.WriteLine("<td>Descripcion</td>");
            escribir2.WriteLine("</tr>");
            foreach (Error item in lista2)
            {
                escribir2.WriteLine("<tr>");
                escribir2.WriteLine("<td>" + item.GetId() + "</td>");
                escribir2.WriteLine("<td>" + item.GetFila() + "</td>");
                escribir2.WriteLine("<td>" + item.GetColumna() + "</td>");
                escribir2.WriteLine("<td>" + item.GetValor() + "</td>");
                escribir2.WriteLine("<td>" + item.GetDescripcion() + "</td>");
                escribir2.WriteLine("</tr>");

            }
            escribir2.WriteLine("</table>");
            escribir2.WriteLine("</body>");
            escribir2.WriteLine("</html>");
            escribir2.Close();
        }
    }
}
