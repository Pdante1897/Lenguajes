using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto1L
{


    public class Analizador
    {
        public static LinkedList<Token> salida;
        public LinkedList<Error> errores;
        private int estado;
        private String auxlex;
        private int contador;
        private int contadorErr;

        public LinkedList<Token> escanear(String entrada)
        {
            String caracterAux;
            estado = 0;
            auxlex = "";
            Char caracter;
            salida = new LinkedList<Token>();
            errores = new LinkedList<Error>();
            int fila = 1, columna = 1;
            for (int i = 0; i < entrada.Length; i++)
            {
                caracter = entrada.ElementAt(i);
                switch (estado)
                {

                    case 0:
                        if (caracter.Equals('"'))
                        {
                            estado = 1;
                            auxlex += caracter;
                        }
                        else if (caracter.Equals('p') || caracter.Equals('P') ||
                                 caracter.Equals('c') || caracter.Equals('C') ||
                                 caracter.Equals('g') || caracter.Equals('G') ||
                                 caracter.Equals('n') || caracter.Equals('N') ||
                                 caracter.Equals('b') || caracter.Equals('B') ||
                                 caracter.Equals('s') || caracter.Equals('S'))
                        {
                            estado = 3;
                            auxlex += caracter;
                        }
                        else if (Char.IsDigit(caracter))
                        {
                            estado = 2;
                            auxlex += caracter;
                        }
                        else if (caracter.Equals('{'))
                        {
                            auxlex += caracter;
                            agregarToken(Token.Tipo.LLAVE_ABIERTA, fila, columna, "rojo");
                        }
                        else if (caracter.Equals('}'))
                        {
                            auxlex += caracter;
                            agregarToken(Token.Tipo.LLAVE_CIERRA, fila, columna, "rojo");
                        }
                        else if (caracter.Equals(':'))
                        {
                            auxlex += caracter;
                            agregarToken(Token.Tipo.SIGNO_DOS_PUNTOS, fila, columna, "negro");
                        }
                        else if (caracter.Equals(';'))
                        {
                            auxlex += caracter;
                            agregarToken(Token.Tipo.PUNTO_Y_COMA, fila, columna, "anaranjado");
                        }
                        else if (caracter.Equals('%'))
                        {
                            auxlex += caracter;
                            agregarToken(Token.Tipo.PORCIENTO, fila, columna, "negro");
                        }
                        else if (caracter.Equals('\n'))
                        {
                            estado = 0;
                            columna = 0;
                            fila++;
                        }
                        else if (caracter.Equals('\f') || caracter.Equals('\b') || caracter.Equals('\r') || caracter.Equals('\t') || caracter.Equals(' '))
                        {
                            columna++;
                            estado = 0;
                        }
                        else
                        {
                            if (i == entrada.Length - 1)
                            {
                                Console.WriteLine("ya terminamos!");
                            }
                            else
                            {
                                Console.WriteLine("Error");
                                auxlex = "";
                                auxlex += caracter;
                                agregarError(auxlex, "elemento desconocido", fila, columna);
                                estado = 0;
                            }
                        }
                        columna++;
                        break;
                    case 1:
                        if (caracter.Equals('"'))
                        {
                            auxlex += caracter;
                            agregarToken(Token.Tipo.CADENA, fila, columna, "amarillo");
                        }
                        else
                        {
                            auxlex += caracter;
                            estado = 1;
                        }
                        break;

                    case 2:
                        if (Char.IsDigit(caracter))
                        {

                            estado = 2;
                            auxlex += caracter;
                        }
                        else
                        {
                            columna--;
                            i--;
                            agregarToken(Token.Tipo.NUMERO, fila, columna, "verde");

                        }
                        break;

                    case 3:
                        if (auxlex.Equals("grafica", StringComparison.OrdinalIgnoreCase) ||
                            auxlex.Equals("saturacion", StringComparison.OrdinalIgnoreCase) ||
                            auxlex.Equals("bandera", StringComparison.OrdinalIgnoreCase) ||
                            auxlex.Equals("nombre", StringComparison.OrdinalIgnoreCase) ||
                            auxlex.Equals("continente", StringComparison.OrdinalIgnoreCase) ||
                            auxlex.Equals("pais", StringComparison.OrdinalIgnoreCase) ||
                            auxlex.Equals("poblacion", StringComparison.OrdinalIgnoreCase))
                        {
                            columna--;
                            agregarToken(Token.Tipo.PALABRA_RESERVADA, fila, columna, "azul");
                            columna++;
                            i--;
                        }
                        else if (caracter.Equals(':'))
                        {

                            agregarError(auxlex, "se esperaba una palabra reservada", fila, columna);
                            columna--;
                            i--;

                        }
                        else
                        {
                            columna++;
                            estado = 3;
                            auxlex += caracter;
                        }
                        break;
                    default:
                        break;
                }
            }

            return salida;
        }
        public void agregarToken(Token.Tipo tipo, int fila, int columna, String color)
        {
            salida.AddLast(new Token(contador, tipo, auxlex, fila, columna, "color"));
            estado = 0;
            auxlex = "";
            contador++;
        }
        public void imprimirListadoToken(LinkedList<Token> lista)
        {
            foreach (Token item in lista)
            {
                Console.WriteLine(item.GetId() + "." + item.GetTipo() + "------" + item.GetValor());

            }

        }
        public void imprimirListadoErrores(LinkedList<Error> lista)
        {
            foreach (Error item in lista)
            {
                Console.WriteLine(item.GetId() + "." + item.GetValor() + "------" + item.GetDescripcion());

            }
        }
        public void agregarError(String valor, String descripcion, int fila, int columna)
        {
            errores.AddLast(new Error(contadorErr, valor, descripcion, fila, columna));
            estado = 0;
            auxlex = "";
            contadorErr++;
        }

        public void saturacion()
        {

        }
    }

}
