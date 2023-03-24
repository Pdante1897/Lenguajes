using System;
using System.Collections.Generic;
using System.IO;

namespace Proyecto2L
{
    class ArchivoHTML
    {
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
        public void htmlError(LinkedList<ErrorLex> lista2)
        {
            String dir = "C:\\proyecto\\erroresLex.html";
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
            foreach (ErrorLex item in lista2)
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
        public void htmlErrorS(LinkedList<ErrorSint> lista2)
        {
            String dir = "C:\\proyecto\\erroresSint.html";
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
            foreach (ErrorSint item in lista2)
            {
                escribir2.WriteLine("<tr>");
                escribir2.WriteLine("<td>" + item.GetId() + "</td>");
                escribir2.WriteLine("<td>" + item.GetFila() + "</td>");
                escribir2.WriteLine("<td>" + item.GetColumna() + "</td>");
                escribir2.WriteLine("<td>" + item.GetError() + "</td>");
                escribir2.WriteLine("<td>" + item.GetCorrecto() + "</td>");
                escribir2.WriteLine("</tr>");

            }
            escribir2.WriteLine("</table>");
            escribir2.WriteLine("</body>");
            escribir2.WriteLine("</html>");
            escribir2.Close();
        }
    }
}
