using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticaL
{
    public class AnalizadorLex
    {
        public static LinkedList<TokenDesconocido> Errores;
        public static LinkedList<Token> Salida;
        private int estado;
        private String auxiliarlex;
        private int contador = 1;
        private int contadorDesc = 1;

        public LinkedList<Token> escanear(String entrada)
        {
            estado = 0;
            auxiliarlex = "";
            Char caracter;
            Salida = new LinkedList<Token>();
            Errores = new LinkedList<TokenDesconocido>();
            int fila = 1, columna = 1;

            for (int i = 0; i < entrada.Length; i++)
            {
                caracter = entrada.ElementAt(i);

                switch (estado)
                {
                    case 0:
                        {
                            if (char.IsDigit(caracter))
                            {
                                auxiliarlex += caracter;
                                estado = 17;
                                break;
                            }

                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\b':
                                case '\f':
                                    estado = 0;
                                    break;
                                case '\n':
                                    estado = 0;
                                    columna = 0;
                                    fila++;
                                    break;
                                case '[':
                                    auxiliarlex += caracter;
                                    agregarToken(Token.Tipo.CORCHETE_ABIERTA);
                                    estado = 0;
                                    break;
                                case ']':
                                    auxiliarlex += caracter;
                                    agregarToken(Token.Tipo.CORCHETE_CIERRA);
                                    estado = 0;
                                    break;
                                case '(':
                                    auxiliarlex += caracter;
                                    agregarToken(Token.Tipo.PARENTECIS_ABRE);
                                    estado = 0;
                                    break;
                                case ')':
                                    auxiliarlex += caracter;
                                    agregarToken(Token.Tipo.PARENTECIS_CIERRA);
                                    estado = 0;
                                    break;
                                case '<':
                                    auxiliarlex += caracter;
                                    agregarToken(Token.Tipo.MENOR);
                                    estado = 0;
                                    break;
                                case '>':
                                    auxiliarlex += caracter;
                                    agregarToken(Token.Tipo.MAYOR);
                                    estado = 0;
                                    break;
                                case ';':
                                    auxiliarlex += caracter;
                                    agregarToken(Token.Tipo.PUNTO_Y_COMA);
                                    estado = 0;
                                    break;
                                case '{':
                                    auxiliarlex += caracter;
                                    agregarToken(Token.Tipo.LLAVE_ABIERTA);
                                    estado = 0;
                                    break;
                                case '}':
                                    auxiliarlex += caracter;
                                    agregarToken(Token.Tipo.LLAVE_CIERRA);
                                    estado = 0;
                                    break;
                                case ':':
                                    auxiliarlex += caracter;
                                    agregarToken(Token.Tipo.SIGNO_DOS_PUNTOS);
                                    estado = 0;
                                    break;
                                case '"':
                                    auxiliarlex += caracter;
                                    agregarToken(Token.Tipo.SIGNO_COMILLAS);
                                    estado = 16;
                                    break;
                                case 'P':
                                    estado = 1;
                                    auxiliarlex += caracter;
                                    break;
                                case 'p':
                                    estado = 1;
                                    auxiliarlex += caracter;
                                    break;
                                case 'A':
                                    estado = 3;
                                    auxiliarlex += caracter;
                                    break;
                                case 'a':
                                    estado = 3;
                                    auxiliarlex += caracter;
                                    break;
                                case 'M':
                                    estado = 6;
                                    auxiliarlex += caracter;
                                    break;
                                case 'm':
                                    estado = 6;
                                    auxiliarlex += caracter;
                                    break;
                                case 'D':
                                    estado = 9;
                                    auxiliarlex += caracter;
                                    break;
                                case 'd':
                                    estado = 9;
                                    auxiliarlex += caracter;
                                    break;
                                case 'I':
                                    estado = 14;
                                    auxiliarlex += caracter;
                                    break;
                                case 'i':
                                    estado = 14;
                                    auxiliarlex += caracter;
                                    break;
                                default:
                                    auxiliarlex += caracter;
                                    agregarTokenDesconocido(fila, columna);
                                    break;

                            }

                        }
                        break;
                    case 1:
                        {
                            if (caracter.Equals('l'))
                            {
                                estado = 1;
                                auxiliarlex += caracter;
                                break;
                            }
                            else if (caracter.Equals('a'))
                            {
                                estado = 1;
                                auxiliarlex += caracter;
                                break;
                            }
                            else if (caracter.Equals('n'))
                            {
                                estado = 1;
                                auxiliarlex += caracter;
                                break;

                            }
                            else if (caracter.Equals('i'))
                            {
                                estado = 1;
                                auxiliarlex += caracter;
                                break;

                            }
                            else if (caracter.Equals('f'))
                            {
                                estado = 1;
                                auxiliarlex += caracter;
                                break;
                            }
                            else if (caracter.Equals('c'))
                            {
                                estado = 1;
                                auxiliarlex += caracter;
                                break;
                            }
                            else if (caracter.Equals('d'))
                            {
                                estado = 1;
                                auxiliarlex += caracter;
                                break;
                            }
                            else if (caracter.Equals('o'))
                            {
                                estado = 1;
                                auxiliarlex += caracter;
                                break;
                            }
                            else if (caracter.Equals('r'))
                            {
                                estado = 2;
                                auxiliarlex += caracter;
                                break;
                            }
                            else
                            {
                                estado = 0;
                                auxiliarlex += caracter;
                                agregarTokenDesconocido(fila, columna);
                                break;
                            }

                        }
                    case 2:
                        {
                            agregarToken(Token.Tipo.PALABRA_RESERVADA);
                            i--;
                            break;
                        }

                    case 3:
                        {
                            if (caracter.Equals('ñ'))
                            {
                                estado = 4;
                                auxiliarlex += caracter;
                                break;
                            }
                            else
                            {
                                estado = 0;
                                auxiliarlex += caracter;
                                agregarTokenDesconocido(fila, columna);
                                break;
                            }
#pragma warning disable CS0162 // Se detectó código inaccesible
                            break;
#pragma warning restore CS0162 // Se detectó código inaccesible
                        }

                    case 4:
                        {
                            if (caracter.Equals('o'))
                            {
                                estado = 5;
                                auxiliarlex += caracter;
                                break;
                            }
                            else
                            {
                                estado = 0;
                                auxiliarlex += caracter;
                                agregarTokenDesconocido(fila, columna);
                                break;
                            }
                        }
                    case 5:
                        {
                            agregarToken(Token.Tipo.PALABRA_RESERVADA);
                            i--;
                            break;
                        }
                    case 6:
                        {
                            if (caracter.Equals('e'))
                            {
                                estado = 7;
                                auxiliarlex += caracter;
                                break;
                            }
                            else
                            {
                                estado = 0;
                                auxiliarlex += caracter;
                                agregarTokenDesconocido(fila, columna);
                                break;
                            }
                        }
                    case 7:
                        {
                            if (caracter.Equals('s'))
                            {
                                estado = 8;
                                auxiliarlex += caracter;
                                break;
                            }
                            else
                            {
                                estado = 0;
                                auxiliarlex += caracter;
                                agregarTokenDesconocido(fila, columna);
                                break;
                            }
                        }
                    case 8:
                        {
                            agregarToken(Token.Tipo.PALABRA_RESERVADA);
                            i--;
                            break;
                        }
                    case 9:
                        {
                            if (caracter.Equals('i'))
                            {
                                estado = 10;
                                auxiliarlex += caracter;
                                break;
                            }
                            else if (caracter.Equals('e'))
                            {
                                estado = 12;
                                auxiliarlex += caracter;
                                break;
                            }
                            else
                            {
                                estado = 0;
                                auxiliarlex += caracter;
                                agregarTokenDesconocido(fila, columna);
                                break;
                            }
                        }
                    case 10:
                        if (caracter.Equals('a'))
                        {
                            estado = 11;
                            auxiliarlex += caracter;
                            break;
                        }
                        else
                        {
                            estado = 0;
                            auxiliarlex += caracter;
                            agregarTokenDesconocido(fila, columna);
                            break;
                        }
                    case 11:
                        agregarToken(Token.Tipo.PALABRA_RESERVADA);
                        i--;
                        break;
                    case 12:
                        if (caracter.Equals('s'))
                        {
                            estado = 12;
                            auxiliarlex += caracter;
                            break;
                        }
                        else if (caracter.Equals('c'))
                        {
                            estado = 12;
                            auxiliarlex += caracter;
                            break;
                        }
                        else if (caracter.Equals('r'))
                        {
                            estado = 12;
                            auxiliarlex += caracter;
                            break;
                        }
                        else if (caracter.Equals('i'))
                        {
                            estado = 12;
                            auxiliarlex += caracter;
                            break;
                        }
                        else if (caracter.Equals('p'))
                        {
                            estado = 12;
                            auxiliarlex += caracter;
                            break;
                        }
                        else if (caracter.Equals('o'))
                        {
                            estado = 12;
                            auxiliarlex += caracter;
                            break;
                        }
                        else if (caracter.Equals('n'))
                        {
                            estado = 13;
                            auxiliarlex += caracter;
                            break;
                        }
                        else
                        {
                            estado = 0;
                            auxiliarlex += caracter;
                            agregarTokenDesconocido(fila, columna);
                            break;
                        }
                    case 13:
                        agregarToken(Token.Tipo.PALABRA_RESERVADA);
                        i--;
                        break;
                    case 14:
                        if (caracter.Equals('m'))
                        {
                            estado = 14;
                            auxiliarlex += caracter;
                            break;
                        }
                        else if (caracter.Equals('a'))
                        {
                            estado = 14;
                            auxiliarlex += caracter;
                            break;
                        }
                        else if (caracter.Equals('g'))
                        {
                            estado = 14;
                            auxiliarlex += caracter;
                            break;
                        }
                        else if (caracter.Equals('e'))
                        {
                            estado = 14;
                            auxiliarlex += caracter;
                            break;
                        }
                        else if (caracter.Equals('n'))
                        {
                            estado = 15;
                            auxiliarlex += caracter;
                            break;
                        }
                        else
                        {
                            estado = 0;
                            auxiliarlex += caracter;
                            agregarTokenDesconocido(fila, columna);
                            break;
                        }
                    case 15:
                        agregarToken(Token.Tipo.PALABRA_RESERVADA);
                        i--;
                        break;
                    case 16:
                        {
                            if (caracter.Equals('"'))
                            {
                                agregarToken(Token.Tipo.CADENA);
                                auxiliarlex += caracter;
                                agregarToken(Token.Tipo.SIGNO_COMILLAS);
                                break;
                            }
                            else
                            {
                                estado = 16;
                                auxiliarlex += caracter;
                                break;
                            }
                        }
                    case 17:
                        if (char.IsDigit(caracter))
                        {
                            auxiliarlex += caracter;
                            estado = 17;
                            break;
                        }
                        else
                        {
                            agregarToken(Token.Tipo.NUMERO);
                            estado = 0;
                            i--;
                        }
                        break;
                    default:
                        break;


                }
                columna++;

            }
            return Salida;
        }

        public void agregarToken(Token.Tipo tipo)
        {
            Salida.AddLast(new Token(contador, tipo, auxiliarlex));
            estado = 0;
            auxiliarlex = "";
            contador++;
        }
        public void imprimirListadoToken(LinkedList<Token> lista)
        {
            foreach (Token item in lista)
            {
                Console.WriteLine(item.GetId() + "." + item.GetTipo() + "------" + item.GetValor());

            }

        }
        public void agregarTokenDesconocido(int fila, int columna)
        {
            Errores.AddLast(new TokenDesconocido(contadorDesc, fila, columna, "Desconocido", auxiliarlex));
            estado = 0;
            auxiliarlex = "";
            contadorDesc++;
        }
    }
}
