using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace PracticaL
{
    public partial class Form1 : Form
    {
        static int pestanias = 1;
        public static LinkedList<Evento> fechas = new LinkedList<Evento>();
        public Form1()
        {
            InitializeComponent();
        }

        private void CargarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string dir;
            openFileDialog1.ShowDialog();
            tabControl1.SelectedTab.Text = openFileDialog1.SafeFileName;
            dir = openFileDialog1.FileName;
            Console.WriteLine(dir);
            try
            {

                GetTextBox().Text = File.ReadAllText(dir);
            }
            catch (Exception)
            {
            }


        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void NuevaPestañaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pestanias++;
            TabPage nueva = new TabPage("Pestaña " + pestanias);
            TextBox txt = new TextBox();
            txt.Multiline = true;
            txt.ScrollBars = ScrollBars.Vertical;
            txt.Dock = DockStyle.Fill;
            nueva.Controls.Add(txt);
            tabControl1.TabPages.Add(nueva);

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FolderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void GuardarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                string dir;
                saveFileDialog1.ShowDialog();
                Console.WriteLine(saveFileDialog1.ToString());
                if (saveFileDialog1.ToString() == "ok")
                {
                    dir = saveFileDialog1.FileName;
                    File.WriteAllText(dir, GetTextBox().Text);
                }
            }
            catch (Exception)
            {
            }
        }
        private TextBox GetTextBox()
        {
            TextBox auxiliar = new TextBox();
            TabPage seleccionada = tabControl1.SelectedTab;
            if (seleccionada != null)
            {
                auxiliar = seleccionada.Controls[0] as TextBox;
            }
            return auxiliar;

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            TabPage seleccionada = tabControl1.SelectedTab;
            TextBox auxiliar = new TextBox();
            auxiliar = seleccionada.Controls[0] as TextBox;
            AnalizadorLex analizar = new AnalizadorLex();
            analizar.imprimirListadoToken(analizar.escanear(auxiliar.Text));
            treeView1.Nodes.Clear();
            try
            {
                arbol(AnalizadorLex.Salida);
            }
            catch (Exception)
            {
            }
            try
            {
                html(AnalizadorLex.Salida, AnalizadorLex.Errores);
            }
            catch (Exception)
            {
            }
        }
        public void arbol(LinkedList<Token> lista)
        {

            TreeNode nodo = new TreeNode();
            nodo.Text = "Actividades";
            TreeNode nodoPlan = new TreeNode();
            TreeNode nodoMes = new TreeNode();
            TreeNode nodoAnio = new TreeNode();
            TreeNode nodoDia = new TreeNode();
            treeView1.Nodes.Add(nodo);
            int estado = 0, anio, mes, dia;
            Evento fecha = new Evento();
            DateTime fechaD;
            foreach (Token item in lista)
            {
                if (item.GetValor().Equals("Planificador"))
                {
                    nodoPlan = new TreeNode();
                    estado = 0;
                }
                switch (estado)
                {
                    case 0:
                        if (item.GetTipo().Equals("Cadena"))
                        {
                            nodoPlan = new TreeNode();
                            nodoPlan.Text = item.GetValor();
                            nodo.Nodes.Add(nodoPlan);
                            estado = 1;
                        }
                        break;
                    case 1:
                        if (item.GetTipo().Equals("Corchete abierto"))
                        {
                            estado = 2;
                        }
                        break;
                    case 2:
                        if (item.GetTipo().Equals("Numero"))
                        {
                            nodoAnio = new TreeNode();
                            nodoAnio.Text = item.GetValor();

                            nodoPlan.Nodes.Add(nodoAnio);
                            estado = 3;
                        }
                        else if (item.GetTipo().Equals("Corchete cerrado"))
                        {
                            estado = 0;
                            break;
                        }
                        break;
                    case 3:
                        if (item.GetTipo().Equals("Llave abierta"))
                        {
                            estado = 4;
                        }
                        break;
                    case 4:
                        if (item.GetTipo().Equals("Numero"))
                        {
                            nodoMes = new TreeNode();
                            nodoMes.Text = item.GetValor();
                            nodoAnio.Nodes.Add(nodoMes);
                            estado = 5;
                        }
                        else if (item.GetTipo().Equals("Llave cierra"))
                        {
                            estado = 2;
                            break;
                        }
                        break;
                    case 5:
                        if (item.GetTipo().Equals("Parentecis abierto"))
                        {
                            estado = 6;
                        }
                        break;
                    case 6:
                        if (item.GetTipo().Equals("Numero"))
                        {

                            nodoDia = new TreeNode();
                            nodoDia.Text = item.GetValor();
                            anio = System.Convert.ToInt32(nodoAnio.Text);
                            mes = System.Convert.ToInt32(nodoMes.Text);
                            dia = System.Convert.ToInt32(nodoDia.Text);
                            fecha = new Evento(nodoAnio.Text, nodoMes.Text, nodoDia.Text);
                            fechaD = new DateTime(anio, mes, dia);
                            monthCalendar1.AddBoldedDate(fechaD);
                            nodoDia.Tag = nodoAnio.Text + "/" + nodoMes.Text;
                            nodoMes.Nodes.Add(nodoDia);
                            estado = 7;

                        }
                        else if (item.GetTipo().Equals("Parentecis cerrado"))
                        {
                            estado = 4;
                            break;
                        }
                        break;
                    case 7:
                        if (item.GetTipo().Equals("Cadena"))
                        {
                            fecha.SetDescripcion(item.GetValor());
                            estado = 8;
                        }
                        break;
                    case 8:
                        if (item.GetTipo().Equals("Cadena"))
                        {
                            fecha.SetPath(item.GetValor());
                            estado = 6;
                            fechas.AddLast(fecha);
                        }
                        break;

                }
            }
        }

        public void html(LinkedList<Token> lista, LinkedList<TokenDesconocido> lista2)
        {
            String dir;
            int contador = 1;
            saveFileDialog1.FileName = "Salida Token.html";
            saveFileDialog1.ShowDialog();
            dir = saveFileDialog1.FileName;
            File.WriteAllText(dir, "");
            StreamWriter escribir = new StreamWriter(dir);
            escribir.WriteLine("<html>");
            escribir.WriteLine("<body>");
            escribir.WriteLine("<table border=" + '"' + '1' + '"' + ">");
            escribir.WriteLine("<tr>");
            escribir.WriteLine("<td>#</td>");
            escribir.WriteLine("<td>lexema</td>");
            escribir.WriteLine("<td>ide Token</td>");
            escribir.WriteLine("<td>Token</td>");
            escribir.WriteLine("</tr>");
            foreach (Token item in lista)
            {
                if (!item.GetTipo().Equals("Desconocido"))
                {
                    escribir.WriteLine("<tr>");
                    escribir.WriteLine("<td>" + contador + "</td>");
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
            saveFileDialog1.FileName = "Salida Errores.html";
            saveFileDialog1.ShowDialog();
            dir = saveFileDialog1.FileName;
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
            contador = 1;
            foreach (TokenDesconocido item in lista2)
            {
                escribir2.WriteLine("<tr>");
                escribir2.WriteLine("<td>" + contador + "</td>");
                escribir2.WriteLine("<td>" + item.GetFila() + "</td>");
                escribir2.WriteLine("<td>" + item.GetColumna() + "</td>");
                escribir2.WriteLine("<td>" + item.GetValor() + "</td>");
                escribir2.WriteLine("<td>" + item.GetTipo() + "</td>");
                escribir2.WriteLine("</tr>");
                contador++;

            }
            escribir2.WriteLine("</table>");
            escribir2.WriteLine("</body>");
            escribir2.WriteLine("</html>");
            escribir2.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nombre: Bryan Gerardo Paez Morales" + '\n' +
                            "carne: 201700945" + '\n' +
                            "Curso: Lenguajes Formales y Programacion");

            foreach (Evento date in fechas)
            {
                Console.WriteLine(date.ToString());
            }
        }

        private void MonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void MonthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {

        }

        private void TreeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            panel2.Controls.Clear();
            try
            {
                int contador = 0;
                String cadena, dia, mes, anio;
                cadena = treeView1.SelectedNode.Tag.ToString();
                String[] arreglo = cadena.Split('/');
                Console.WriteLine(cadena);
                anio = arreglo[0];
                mes = arreglo[1];
                dia = treeView1.SelectedNode.Text;

                Console.WriteLine(anio + mes + dia);
                foreach (Evento item in fechas)
                {
                    if ((item.GetAnio().Equals(anio)) && (item.GetMes().Equals(mes)) && (item.GetDia().Equals(dia)))
                    {
                        Console.WriteLine(item.ToString());
                        GenerarLabel(item.GetDescripcion(), item.GetPath(), contador);
                        contador++;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public void GenerarLabel(String descripcion, String path, int contador)
        {

            Label desc = new Label();
            PictureBox imagen = new PictureBox();
            desc.Text = descripcion;
            imagen.Text = path;
            desc.SetBounds(1, 300 * (contador), 500, 150);
            imagen.SetBounds(1, (300 * (contador + 1)) - 150, 300, 150);
            try
            {
                imagen.Image = Image.FromFile(path);
                imagen.SizeMode = PictureBoxSizeMode.StretchImage;
                panel2.Controls.Add(imagen);

            }
            catch (Exception)
            {
                MessageBox.Show("No se encontro la Imagen! ", null);
            }
            panel2.Controls.Add(desc);

        }
    }
}
