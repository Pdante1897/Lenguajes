using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto2L
{
    class AnalizadorLex
    {
        public static LinkedList<Token> salida;
        public LinkedList<ErrorLex> errores;
        private int estado;
        private String auxlex;
        private int contador;
        private int contadorErr;
        public LinkedList<Token> escannear(String entrada)
        {
            estado = 0;
            auxlex = "";
            Char caracter;
            salida = new LinkedList<Token>();
            errores = new LinkedList<ErrorLex>();
            int fila = 1, columna = 0;
            for (int i = 0; i < entrada.Length; i++)
            {
                caracter = entrada.ElementAt(i);
                switch (estado)
                {
                    case 0:
                        if (caracter.Equals('C') || caracter.Equals('c') ||
                            caracter.Equals('i') ||
                            caracter.Equals('f') || caracter.Equals('b') ||
                            caracter.Equals('s') || caracter.Equals('S') ||
                            caracter.Equals('v') || caracter.Equals('t') ||
                            caracter.Equals('p') || caracter.Equals('e') ||
                            caracter.Equals("n") || caracter.Equals('w'))
                        {
                            columna++;
                            estado = 3;
                            auxlex += caracter;
                        }
                        else if (caracter.Equals('!'))
                        {
                            columna++;
                            auxlex += caracter;
                            agregarToken(Token.Tipo.EXCLAMASION, fila, columna);
                        }
                        else if (caracter.Equals('{'))
                        {
                            columna++;
                            auxlex += caracter;
                            agregarToken(Token.Tipo.LLAVE_ABIERTA, fila, columna);
                        }
                        else if (caracter.Equals('}'))
                        {
                            columna++;
                            auxlex += caracter;
                            agregarToken(Token.Tipo.LLAVE_CIERRA, fila, columna);
                        }
                        else if (caracter.Equals('['))
                        {
                            columna++;
                            auxlex += caracter;
                            agregarToken(Token.Tipo.COR_ABIERTA, fila, columna);
                        }
                        else if (caracter.Equals(']'))
                        {
                            columna++;
                            auxlex += caracter;
                            agregarToken(Token.Tipo.COR_CIERRA, fila, columna);
                        }
                        else if (caracter.Equals('('))
                        {
                            columna++;
                            auxlex += caracter;
                            agregarToken(Token.Tipo.PR_AB, fila, columna);
                        }
                        else if (caracter.Equals(')'))
                        {
                            columna++;
                            auxlex += caracter;
                            agregarToken(Token.Tipo.PR_CR, fila, columna);
                        }
                        else if (caracter.Equals(':'))
                        {
                            columna++;
                            auxlex += caracter;
                            agregarToken(Token.Tipo.SIGNO_DOS_PUNTOS, fila, columna);
                        }
                        else if (caracter.Equals('.'))
                        {
                            columna++;
                            auxlex += caracter;
                            estado = 8;
                        }
                        else if (caracter.Equals(';'))
                        {
                            columna++;
                            auxlex += caracter;
                            agregarToken(Token.Tipo.PUNTO_Y_COMA, fila, columna);
                        }
                        else if (caracter.Equals('>'))
                        {
                            columna++;
                            auxlex += caracter;
                            agregarToken(Token.Tipo.MAYOR, fila, columna);
                        }
                        else if (caracter.Equals('<'))
                        {
                            columna++;
                            auxlex += caracter;
                            agregarToken(Token.Tipo.MENOR, fila, columna);
                        }
                        else if (caracter.Equals('+'))
                        {
                            columna++;
                            auxlex += caracter;
                            agregarToken(Token.Tipo.MAS, fila, columna);
                        }
                        else if (caracter.Equals('-'))
                        {
                            columna++;
                            auxlex += caracter;
                            agregarToken(Token.Tipo.MENOS, fila, columna);
                        }
                        else if (caracter.Equals('*'))
                        {
                            columna++;
                            auxlex += caracter;
                            agregarToken(Token.Tipo.MULT, fila, columna);
                        }
                        else if (caracter.Equals(','))
                        {
                            columna++;
                            auxlex += caracter;
                            agregarToken(Token.Tipo.COMA, fila, columna);
                        }
                        else if (caracter.Equals('"'))
                        {
                            columna++;
                            auxlex += caracter;
                            estado = 2;
                        }
                        else if (caracter.Equals('\''))
                        {
                            columna++;
                            auxlex += caracter;
                            estado = 2;
                        }
                        else if (caracter.Equals('='))
                        {
                            columna++;
                            auxlex += caracter;
                            agregarToken(Token.Tipo.IGUAL, fila, columna);
                        }
                        else if (caracter.Equals('/'))
                        {
                            columna++;
                            estado = 4;
                            auxlex += caracter;
                        }
                        else if (Char.IsLetter(caracter))
                        {
                            columna++;
                            auxlex += caracter;
                            estado = 1;
                        }
                        else if (Char.IsDigit(caracter))
                        {
                            columna++;
                            auxlex += caracter;
                            estado = 7;
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
                            auxlex += caracter;
                            estado = 9;
                        }
                        break;
                    case 1:
                        if (!Char.IsLetterOrDigit(caracter))
                        {
                            agregarToken(Token.Tipo.CADENA, fila, columna);
                            i--;
                        }
                        else
                        {
                            auxlex += caracter;
                            estado = 1;
                        }
                        break;
                    case 2:
                        if (caracter.Equals('"'))
                        {
                            auxlex += caracter;
                            agregarToken(Token.Tipo.CADENA_STRING, fila, columna);
                        }
                        else if (caracter.Equals('\''))
                        {
                            auxlex += caracter;
                            agregarToken(Token.Tipo.CARACTER, fila, columna);
                        }
                        else
                        {
                            auxlex += caracter;
                            estado = 2;
                        }
                        break;

                    case 3:
                        if ((auxlex.Equals("class") ||
                            auxlex.Equals("int") ||
                            auxlex.Equals("String") ||
                            auxlex.Equals("string") ||
                            auxlex.Equals("char") ||
                            auxlex.Equals("float") ||
                            auxlex.Equals("bool") ||
                            auxlex.Equals("while") ||
                            auxlex.Equals("for") ||
                            auxlex.Equals("if") ||
                            auxlex.Equals("switch") ||
                            auxlex.Equals("case") ||
                            auxlex.Equals("static") ||
                            auxlex.Equals("public") ||
                            auxlex.Equals("else") ||
                            auxlex.Equals("new") ||
                            auxlex.Equals("void")) && (caracter.Equals(null) || caracter.Equals(' ') || caracter.Equals('[') || caracter.Equals('(')))
                        {
                            agregarToken(Token.Tipo.ID, fila, columna);
                            i--;
                        }
                        else if (auxlex.Equals("Console.WriteLine") && (caracter.Equals(null) || caracter.Equals(' ') || caracter.Equals('[') || caracter.Equals('(')))
                        {
                            agregarToken(Token.Tipo.CADENA, fila, columna);
                            i--;
                        }
                        else if ((auxlex.Equals("true", StringComparison.OrdinalIgnoreCase) ||
                                 auxlex.Equals("false", StringComparison.OrdinalIgnoreCase)))
                        {
                            agregarToken(Token.Tipo.BOOL, fila, columna);
                            i--;
                        }
                        else if (caracter.Equals('.'))
                        {
                            estado = 3;
                            auxlex += caracter;
                        }
                        else if (!Char.IsLetterOrDigit(caracter))
                        {

                            agregarToken(Token.Tipo.CADENA, fila, columna);
                            i--;

                        }
                        else
                        {
                            estado = 3;
                            auxlex += caracter;
                        }
                        break;
                    case 4:
                        if (caracter.Equals('*'))
                        {
                            estado = 5;
                            auxlex += caracter;
                        }
                        else if (caracter.Equals('/'))
                        {
                            estado = 6;
                            auxlex += caracter;
                            columna++;

                        }
                        else if (!caracter.Equals('/'))
                        {
                            agregarToken(Token.Tipo.DIV, fila, columna);
                            i--;
                        }
                        else
                        {
                            estado = 0;
                        }
                        break;
                    case 5:
                        if (caracter.Equals('/'))
                        {
                            auxlex += caracter;
                            agregarToken(Token.Tipo.COMENTARIO_LARGO, fila, columna);
                        }
                        else
                        {
                            auxlex += caracter;
                            estado = 5;
                        }

                        break;

                    case 6:
                        if (caracter.Equals('\n'))
                        {
                            agregarToken(Token.Tipo.COMENTARIO, fila, columna);
                            i--;
                        }
                        else
                        {
                            auxlex += caracter;
                            estado = 6;
                        }

                        break;
                    case 7:
                        if (caracter.Equals('.'))
                        {
                            estado = 7;
                            auxlex += caracter;

                        }
                        else if (caracter.Equals('f'))
                        {
                            auxlex += caracter;
                            agregarToken(Token.Tipo.NUMERO, fila, columna);
                        }
                        else if (!Char.IsDigit(caracter))
                        {
                            agregarToken(Token.Tipo.NUMERO, fila, columna);
                            i--;
                        }
                        else
                        {
                            estado = 7;
                            auxlex += caracter;

                        }

                        break;
                    case 8:
                        if (!Char.IsDigit(caracter))
                        {
                            agregarToken(Token.Tipo.PUNTO, fila, columna);

                        }
                        else
                        {
                            estado = 7;
                            auxlex += caracter;
                        }
                        break;
                    default:
                        if (caracter.Equals(' '))
                        {
                            agregarError(auxlex, "Desconosido", fila, columna);

                        }
                        else
                        {
                            estado = 9;
                            auxlex += caracter;
                        }
                        break;


                }
            }
            imprimirListadoErrores(errores);
            imprimirTokens(salida);
            return salida;
        }
        public void agregarToken(Token.Tipo tipo, int fila, int columna)
        {
            salida.AddLast(new Token(contador, tipo, auxlex, fila, columna));
            estado = 0;
            auxlex = "";
            contador++;
        }
        public void imprimirTokens(LinkedList<Token> lista)
        {
            foreach (var item in lista)
            {
                Console.WriteLine(item.Imprimir());
            }
        }
        public void imprimirListadoErrores(LinkedList<ErrorLex> lista)
        {
            foreach (ErrorLex item in lista)
            {
                Console.WriteLine(item.GetId() + "." + item.GetValor() + "------" + item.GetDescripcion());

            }
        }
        public void agregarError(String valor, String descripcion, int fila, int columna)
        {
            errores.AddLast(new ErrorLex(contadorErr, valor, descripcion, fila, columna));
            estado = 0;
            auxlex = "";
            contadorErr++;
        }
        public LinkedList<ErrorLex> GetListaErrorLex()
        {
            return errores;
        }


    }
}
