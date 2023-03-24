using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Proyecto1L
{
    public class Graphviz
    {
        public LinkedList<Pais> listaPaises;
        public void crearDot(LinkedList<Token> lista)
        {
            listaPaises = new LinkedList<Pais>();
            Directory.CreateDirectory("C:\\proyecto");
            int estado = 0;
            string continente = "", pais = "", saturacion = "", ruta = "", poblacion = "";
            int suma = 0, npaises = 0, prom, satpais;
            TextWriter archivoDot = new StreamWriter("C:\\proyecto\\graphviz.dot");
            archivoDot.WriteLine("digraph G{");


            foreach (Token item in lista)
            {
                switch (estado)
                {
                    case 0:
                        if (item.GetTipo().Equals("Palabra reservada") && item.GetValor().Equals("grafica", StringComparison.OrdinalIgnoreCase))
                        {
                            estado = 1;
                        }
                        else if (item.GetTipo().Equals("Palabra reservada") && item.GetValor().Equals("Continente", StringComparison.OrdinalIgnoreCase))
                        {
                            estado = 2;
                        }
                        else if (item.GetTipo().Equals("Palabra reservada") && item.GetValor().Equals("pais", StringComparison.OrdinalIgnoreCase))
                        {
                            estado = 3;
                        }
                        else if (item.GetTipo().Equals("Palabra reservada") && item.GetValor().Equals("saturacion", StringComparison.OrdinalIgnoreCase))
                        {

                            estado = 4;
                        }
                        else if (item.GetTipo().Equals("Palabra reservada") && item.GetValor().Equals("nombre", StringComparison.OrdinalIgnoreCase))
                        {

                            estado = 3;
                        }
                        else if (item.GetTipo().Equals("Palabra reservada") && item.GetValor().Equals("bandera", StringComparison.OrdinalIgnoreCase))
                        {

                            estado = 5;
                        }
                        else if (item.GetTipo().Equals("Palabra reservada") && item.GetValor().Equals("poblacion", StringComparison.OrdinalIgnoreCase))
                        {

                            estado = 7;
                        }
                        else if (item.GetValor().Equals("}"))
                        {

                            estado = 6;
                        }


                        break;

                    case 1:
                        if (item.GetTipo().Equals("Cadena"))
                        {
                            archivoDot.WriteLine("start[shape = Mdiamond label = " + item.GetValor() + "];");
                            estado = 0;
                        }
                        break;
                    case 2:
                        if (item.GetTipo().Equals("Cadena"))
                        {
                            continente = item.GetValor().TrimStart('"').TrimEnd('"');
                            archivoDot.WriteLine("start->" + item.GetValor());
                            estado = 0;
                        }
                        break;
                    case 3:
                        if (item.GetTipo().Equals("Cadena"))
                        {
                            pais = item.GetValor().TrimStart('"').TrimEnd('"');
                            estado = 0;
                        }
                        break;
                    case 4:
                        if (item.GetTipo().Equals("Numero"))
                        {
                            saturacion = item.GetValor();
                            estado = 0;
                        }
                        break;

                    case 5:
                        if (item.GetTipo().Equals("Cadena"))
                        {
                            ruta = item.GetValor().TrimStart('"').TrimEnd('"');
                            estado = 0;
                        }
                        break;

                    case 6:

                        archivoDot.WriteLine(continente + "->" + pais.Replace(' ', 'a'));
                        archivoDot.WriteLine(pais.Replace(' ', 'a') + "[shape = record label = " + '"' + '{' + pais + "|" + saturacion + '}' + '"' + "style=filled];");
                        estado = 0;
                        string resultado = pais.TrimStart('"').TrimEnd('"');
                        Console.WriteLine(resultado);
                        satpais = Int32.Parse(saturacion);
                        Pais paisS = new Pais(continente, pais, satpais, ruta, poblacion);
                        listaPaises.AddLast(paisS);
                        if (satpais >= 0 && satpais <= 15)
                        {
                            archivoDot.WriteLine(pais.Replace(' ', 'a') + "[fillcolor=white]");
                        }

                        else if (satpais >= 16 && satpais <= 30)
                        {
                            archivoDot.WriteLine(pais.Replace(' ', 'a') + "[fillcolor=blue]");
                        }
                        else if (satpais >= 31 && satpais <= 45)
                        {
                            archivoDot.WriteLine(pais.Replace(' ', 'a') + "[fillcolor=green]");

                        }
                        else if (satpais >= 46 && satpais <= 60)
                        {
                            archivoDot.WriteLine(pais.Replace(' ', 'a') + "[fillcolor=yellow]");

                        }
                        else if (satpais >= 61 && satpais <= 75)
                        {
                            archivoDot.WriteLine(pais.Replace(' ', 'a') + "[fillcolor=orange]");
                        }
                        else if (satpais >= 76 && satpais <= 100)
                        {
                            archivoDot.WriteLine(pais.Replace(' ', 'a') + "[fillcolor=red]");
                        }
                        suma += Int32.Parse(saturacion);
                        npaises++;
                        if (item.GetValor().Equals("}"))
                        {
                            prom = suma / npaises;
                            archivoDot.WriteLine(continente + "[shape = record label = " + '"' + '{' + continente + "|" + prom + '}' + '"' + "style=filled];");
                            if (prom >= 0 && prom <= 15)
                            {
                                archivoDot.WriteLine(continente + "[fillcolor=white]");
                            }

                            else if (prom >= 16 && prom <= 30)
                            {
                                archivoDot.WriteLine(continente + "[fillcolor=blue]");
                            }
                            else if (prom >= 31 && prom <= 45)
                            {
                                archivoDot.WriteLine(continente + "[fillcolor=green]");

                            }
                            else if (prom >= 46 && prom <= 60)
                            {
                                archivoDot.WriteLine(continente + "[fillcolor=yellow]");

                            }
                            else if (prom >= 61 && prom <= 75)
                            {
                                archivoDot.WriteLine(continente + "[fillcolor=orange]");
                            }
                            else if (prom >= 76 && prom <= 100)
                            {
                                archivoDot.WriteLine(continente + "[fillcolor=red]");
                            }
                            npaises = 0;
                            suma = 0;
                            foreach (Pais items in listaPaises)
                            {
                                if (items.GetContinente().Equals(continente))
                                {
                                    items.SetSatConti(prom);
                                    Console.WriteLine(items.imprimir());
                                }
                            }
                        }
                        break;
                    case 7:
                        if (item.GetTipo().Equals("Numero"))
                        {
                            poblacion = item.GetValor();
                            estado = 0;
                        }
                        break;
                    default:
                        break;
                }
            }
            archivoDot.WriteLine('}');
            archivoDot.Close();
            crearCmd();
            Process p = new Process();
            p.StartInfo.FileName = "C:\\proyecto\\comando.cmd";
            p.Start();
            p.WaitForExit();
            Form1.paisSelec = ElegirPais(listaPaises);
        }

        public void crearCmd()
        {
            TextWriter Cmd = new StreamWriter("C:\\proyecto\\comando.cmd");
            Cmd.WriteLine("cd C:\\Program Files (x86)\\Graphviz 2.28\\bin");
            Cmd.WriteLine("dot -Tpng " + '"' + "C:\\proyecto\\graphviz.dot" + '"' + " -o " + '"' + "C:\\proyecto\\diagrama.png" + '"');
            Cmd.WriteLine("");
            Cmd.Close();
        }

        public Pais ElegirPais(LinkedList<Pais> lista)
        {
            Pais aux = null;
            foreach (Pais item in lista)
            {
                if (aux == null)
                {
                    aux = item;
                }
                else if (aux.GetSaturacionP() > item.GetSaturacionP())
                {
                    aux = item;
                }
                else if (item.GetSaturacionP() == aux.GetSaturacionP())
                {
                    if (aux.GetSaturacionG() > item.GetSaturacionG())
                    {
                        aux = item;
                    }
                }
            }
            Console.WriteLine("__________" + aux.imprimir());
            return aux;

        }

    }

}
