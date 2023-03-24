using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Proyecto1L
{
    public partial class Form1 : Form
    {
        public static Pais paisSelec;
        static int pestanias = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pestanias++;
            TabPage nueva = new TabPage("Pestaña " + pestanias);
            RichTextBox txt = new RichTextBox();
            txt.Multiline = true;
            txt.ScrollBars = RichTextBoxScrollBars.Vertical;
            txt.Dock = DockStyle.Fill;
            txt.BackColor = Color.Silver;
            txt.ForeColor = Color.Black;
            nueva.Controls.Add(txt);
            tabControl1.TabPages.Add(nueva);

        }

        private void GuardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string dir;
            openFileDialog1.Filter = "Archivos de ORG (*.org)|*.org|Todos los archivos (*.*)|*.*";
            openFileDialog1.ShowDialog();
            tabControl1.SelectedTab.Text = openFileDialog1.SafeFileName;
            dir = openFileDialog1.FileName;
            Console.WriteLine(dir);
            try
            {
                GetRichTextBox().Text = File.ReadAllText(dir);
                GetRichTextBox().Tag = dir;
            }
            catch (Exception)
            {
            }
        }

        private void GuardarComoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {

                string dir;
                saveFileDialog1.ShowDialog();
                Console.WriteLine(saveFileDialog1.ToString());

                dir = saveFileDialog1.FileName;
                File.WriteAllText(dir, GetRichTextBox().Text);

            }
            catch (Exception)
            {
            }
        }
        private RichTextBox GetRichTextBox()
        {
            RichTextBox auxiliar = new RichTextBox();
            TabPage seleccionada = tabControl1.SelectedTab;
            if (seleccionada != null)
            {
                auxiliar = seleccionada.Controls[0] as RichTextBox;
            }
            return auxiliar;

        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void GuardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                string dir;
                if (GetRichTextBox().Tag == null)
                {

                    saveFileDialog1.ShowDialog();
                    dir = saveFileDialog1.FileName;
                    tabControl1.SelectedTab.Text = saveFileDialog1.FileName;
                    File.WriteAllText(dir, GetRichTextBox().Text);
                    GetRichTextBox().Tag = dir;
                }
                else
                {
                    dir = GetRichTextBox().Tag.ToString();
                    File.WriteAllText(dir, GetRichTextBox().Text);
                }
            }
            catch (Exception)
            {
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image.Dispose();
            }
            catch (Exception)
            {

            }


            String dir;
            TabPage seleccionada = tabControl1.SelectedTab;
            RichTextBox auxiliar = new RichTextBox();
            auxiliar = seleccionada.Controls[0] as RichTextBox;
            Analizador analizar = new Analizador();
            LinkedList<Token> tokens = analizar.escanear(auxiliar.Text);
            analizar.imprimirListadoToken(tokens);
            analizar.imprimirListadoErrores(analizar.errores);
            int i = 0;
            if (analizar.errores != null)
            {
                foreach (Token item in tokens)
                {
                    auxiliar.Find(item.GetValor(), i, 0);
                    if (item.GetTipo() == "Cadena")
                    {
                        i = auxiliar.SelectionStart;
                        auxiliar.SelectionColor = Color.Yellow;
                    }
                    else if (item.GetTipo() == "Palabra reservada")
                    {
                        i = auxiliar.SelectionStart;
                        auxiliar.SelectionColor = Color.Blue;
                    }

                    else if (item.GetTipo() == "Llave abierta" || item.GetTipo() == "Llave cierra")
                    {
                        i = auxiliar.SelectionStart + 1;
                        auxiliar.SelectionColor = Color.Red;
                    }
                    else if (item.GetTipo() == "Numero")
                    {
                        i = auxiliar.SelectionStart;
                        auxiliar.SelectionColor = Color.Green;
                    }

                    else if (item.GetTipo() == "Punto y coma")
                    {
                        i = auxiliar.SelectionStart;
                        auxiliar.SelectionColor = Color.Orange;


                    }
                }
                Graphviz grafo = new Graphviz();
                grafo.crearDot(tokens);
                dir = "C:\\proyecto\\diagrama.png";

                pictureBox1.Image = Image.FromFile(dir);
                pictureBox2.Image = Image.FromFile(paisSelec.ruta);
                label2.Text = paisSelec.pais;
                label4.Text = paisSelec.poblacion;
                ArchivoPdf html = new ArchivoPdf();
                html.htmlToken(tokens);
            }
            else
            {
                LinkedList<Error> errores = analizar.errores;
                analizar.imprimirListadoErrores(errores);
                ArchivoPdf html = new ArchivoPdf();
                html.htmlError(errores);
                MessageBox.Show("Se encontraron errores!");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ArchivoPdf generar = new ArchivoPdf();
            generar.crearPdf("C:\\proyecto\\diagrama.png");
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nombre: Bryan Gerardo Paez Morales" + '\n' +
                            "carne: 201700945" + '\n' +
                            "Curso: Lenguajes Formales y Programacion");
        }
    }

}
