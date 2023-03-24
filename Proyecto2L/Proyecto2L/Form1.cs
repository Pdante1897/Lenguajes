using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto2L
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GuardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                string dir;
                saveFileDialog1.DefaultExt = "cs";
                saveFileDialog1.ShowDialog();

                Console.WriteLine(saveFileDialog1.ToString());

                dir = saveFileDialog1.FileName;
                File.WriteAllText(dir, richTextBox1.Text);

                saveFileDialog2.DefaultExt = "py";
                saveFileDialog2.ShowDialog();

                Console.WriteLine(saveFileDialog2.ToString());

                dir = saveFileDialog2.FileName;
                File.WriteAllText(dir, richTextBox3.Text);
            }
            catch (Exception)
            {
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nombre: Bryan Gerardo Paez Morales" + '\n' +
                            "carne: 201700945" + '\n' +
                            "Curso: Lenguajes Formales y Programacion");
        }

        private void GenerarTraduccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox3.Text = null;
            AnalizadorLex analizar = new AnalizadorLex();
            AnalizadorSint analizarSint = new AnalizadorSint();
            ArchivoHTML generar = new ArchivoHTML();
            LinkedList<Token> lista = new LinkedList<Token>();
            //analizar.escannear(richTextBox1.Text);
            lista = analizar.escannear(richTextBox1.Text);
            generar.htmlToken(lista);
            LinkedList<ErrorLex> listaErrL = new LinkedList<ErrorLex>();
            LinkedList<ErrorSint> listaErrS = new LinkedList<ErrorSint>();

            listaErrL = analizar.GetListaErrorLex();
            if (listaErrL != null)
            {
                generar.htmlError(listaErrL);
            }
            analizarSint.parsear((lista));
            listaErrS = analizarSint.GetListaErrorSint();
            if (listaErrS != null)
            {
                generar.htmlErrorS(listaErrS);
            }
            if (!listaErrL.Any() && !listaErrS.Any())
            {
                richTextBox3.Text = analizarSint.cadenaPyton;

            }
        }

        private void ArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AbrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string dir;
            openFileDialog1.Filter = "Archivos de C# (*.cs)|*.cs|Todos los archivos (*.*)|*.*";
            openFileDialog1.ShowDialog();

            dir = openFileDialog1.FileName;
            Console.WriteLine(dir);
            try
            {
                richTextBox1.Text = File.ReadAllText(dir);
            }
            catch (Exception)
            {
            }
        }
    }
}

