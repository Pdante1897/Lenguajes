using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto2L
{
    public class AnalizadorSint
    {
        int controlToken;
        Token tokenActual;
        int tabulaciones, varEnFor;
        LinkedList<Token> listaTok;
        LinkedList<ErrorSint> listaErrorS;
        public String cadenaPyton;
        int contadorErr;
        public void parsear(LinkedList<Token> tokens)
        {
            listaErrorS = new LinkedList<ErrorSint>();
            this.listaTok = tokens;
            controlToken = 0;
            tokenActual = listaTok.ElementAt(controlToken);
            Console.WriteLine(listaTok.Count);
            INICIO();
        }

        public void INICIO()

        {
            if (tokenActual.GetTIPO() == Token.Tipo.ID)
            {
                emparejar(Token.Tipo.ID, null);
                emparejar(Token.Tipo.CADENA, null);
                emparejar(Token.Tipo.LLAVE_ABIERTA, null);
                METODO();
                emparejar(Token.Tipo.LLAVE_CIERRA, null);
            }
            else
            {
            }
        }

        public void METODO()
        {
            if (tokenActual.GetTIPO() == Token.Tipo.ID)
            {
                emparejar(Token.Tipo.ID, null);
                emparejar(Token.Tipo.ID, null);
                emparejar(Token.Tipo.CADENA, null);
                PARAMETROS();
                emparejar(Token.Tipo.LLAVE_ABIERTA, null);
                INSTRUCCIONES();
                emparejar(Token.Tipo.LLAVE_CIERRA, null);
            }
            else
            {

            }
        }
        public void PARAMETROS()
        {
            if (tokenActual.GetTIPO() == Token.Tipo.PR_AB)
            {
                emparejar(Token.Tipo.PR_AB, null);
                emparejar(Token.Tipo.ID, null);
                emparejar(Token.Tipo.COR_ABIERTA, null);
                emparejar(Token.Tipo.COR_CIERRA, null);
                emparejar(Token.Tipo.CADENA, null);
                emparejar(Token.Tipo.PR_CR, null);
            }
            else
            {

            }
        }
        public void CASE()
        {
            if (tokenActual.GetTIPO() == Token.Tipo.SIGNO_DOS_PUNTOS)
            {

            }
        }
        public void INSTRUCCIONES()
        {
            if (tokenActual.GetTIPO() == Token.Tipo.ID)
            {
                emparejar(Token.Tipo.ID, tokenActual.GetValor());
                if (tokenActual.GetTIPO() == Token.Tipo.CADENA)
                {

                    DECLARACION();
                    CASE();
                }
                else if (tokenActual.GetTIPO() == Token.Tipo.PR_AB)
                {
                    SENTENCIAIF();
                }
                else if (tokenActual.GetTIPO() == Token.Tipo.LLAVE_ABIERTA)
                {
                    SENTENCIAELSE();
                }
                else if (tokenActual.GetTIPO() == Token.Tipo.ID)
                {
                    emparejar(Token.Tipo.ID, "if");
                    SENTENCIAIF();
                }
                else
                {
                }
                OTRAINSTRUCCION();

            }
            else if (tokenActual.GetTIPO() == Token.Tipo.CADENA)
            {
                if (tokenActual.GetValor().Equals("Console.WriteLine"))
                {

                    emparejar(Token.Tipo.CADENA, "console");

                }
                else
                {
                    emparejar(Token.Tipo.CADENA, "asignasion");
                }
                if (tokenActual.GetTIPO() == Token.Tipo.IGUAL)
                {
                    ASIGNACION();
                }
                else if (tokenActual.GetTIPO() == Token.Tipo.PR_AB)
                {

                    CONSOLE();
                }
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.COMENTARIO || tokenActual.GetTIPO() == Token.Tipo.COMENTARIO_LARGO)
            {
                COMENTARIO();
            }
            {

            }
            OTRAINSTRUCCION();
        }
        public void COMENTARIO()
        {
            if (tokenActual.GetTIPO() == Token.Tipo.COMENTARIO)
            {
                emparejar(Token.Tipo.COMENTARIO, null);
            }
            else {
                emparejar(Token.Tipo.COMENTARIO_LARGO, null);
            }
            INSTRUCCIONES();
        }

        public void CONSOLE()
        {
            emparejar(Token.Tipo.PR_AB, "console");

            DATO("console");
            emparejar(Token.Tipo.PUNTO_Y_COMA, "console");

        }
        public void OTRAINSTRUCCION()
        {
            if (tokenActual.GetTIPO() == Token.Tipo.ID)
            {
                INSTRUCCIONES();
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.CADENA)
            {
                INSTRUCCIONES();
            }
        }
        public void SENTENCIAFOR()
        {
            emparejar(Token.Tipo.ID, "for");
            emparejar(Token.Tipo.CADENA, "for");
            emparejar(Token.Tipo.IGUAL, "for");
            emparejar(Token.Tipo.NUMERO, "for");
            emparejar(Token.Tipo.PUNTO_Y_COMA, "for");
            CONDICION("for");
            emparejar(Token.Tipo.PUNTO_Y_COMA, "for");
            emparejar(Token.Tipo.CADENA, "for");
            SIGNO_SR();


        }

        public void SENTENCIAIF()
        {
            emparejar(Token.Tipo.PR_AB, "if");
            if (tokenActual.GetTIPO() == Token.Tipo.ID)
            {
                SENTENCIAFOR();
                emparejar(Token.Tipo.PR_CR, "for");
                emparejar(Token.Tipo.LLAVE_ABIERTA, "for");
                INSTRUCCIONES();
                emparejar(Token.Tipo.LLAVE_CIERRA, "if");
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.NUMERO || tokenActual.GetTIPO() == Token.Tipo.CADENA || tokenActual.GetTIPO() == Token.Tipo.CADENA_STRING || tokenActual.GetTIPO() == Token.Tipo.CARACTER || tokenActual.GetTIPO() == Token.Tipo.BOOL)
            {
                CONDICION("if");

                emparejar(Token.Tipo.LLAVE_ABIERTA, "if");
                INSTRUCCIONES();
                emparejar(Token.Tipo.LLAVE_CIERRA, "if");
            }
            else
            {
            }


        }
        public void SENTENCIAELSE()
        {

            emparejar(Token.Tipo.LLAVE_ABIERTA, "else");
            INSTRUCCIONES();
            emparejar(Token.Tipo.LLAVE_CIERRA, "else");
        }
        public void SIGNO_SR()
        {
            if (tokenActual.GetTIPO() == Token.Tipo.MAS)
            {
                emparejar(Token.Tipo.MAS, "signo");
                emparejar(Token.Tipo.MAS, "signo");

            }
            else if (tokenActual.GetTIPO() == Token.Tipo.MENOS)
            {
                emparejar(Token.Tipo.MENOS, "signo");
                emparejar(Token.Tipo.MENOS, "signo");

            }
            else
            {

            }
        }
        public void OPERADOR(String operador)
        {
            if (tokenActual.GetTIPO() == Token.Tipo.MAS)
            {
                emparejar(Token.Tipo.MAS, operador);

            }
            else if (tokenActual.GetTIPO() == Token.Tipo.MENOS)
            {
                emparejar(Token.Tipo.MENOS, operador);

            }
            else if (tokenActual.GetTIPO() == Token.Tipo.MULT)
            {
                emparejar(Token.Tipo.MULT, operador);

            }
            else if (tokenActual.GetTIPO() == Token.Tipo.DIV)
            {
                emparejar(Token.Tipo.DIV, operador);

            }
            else if (tokenActual.GetTIPO() == Token.Tipo.PR_CR)
            {
                emparejar(Token.Tipo.PR_CR, operador);

            }
            else if (tokenActual.GetTIPO() == Token.Tipo.PR_AB)
            {
                emparejar(Token.Tipo.PR_AB, operador);

            }
            else
            {

            }
            OTROOPERADOR(operador);
        }
        public void OTROOPERADOR(String operador)
        {
            if (tokenActual.GetTIPO() == Token.Tipo.PR_AB ||
                tokenActual.GetTIPO() == Token.Tipo.PR_CR)
            {
                DATO(operador);
            }
        }
        public void OPERADOR_L(String operadorL)
        {
            if (tokenActual.GetTIPO() == Token.Tipo.EXCLAMASION)
            {
                emparejar(Token.Tipo.EXCLAMASION, operadorL);
                if (tokenActual.GetTIPO() == Token.Tipo.IGUAL)
                {
                    emparejar(Token.Tipo.IGUAL, operadorL);

                }
                else
                {
                }
            }
            if (tokenActual.GetTIPO() == Token.Tipo.MAYOR)
            {
                emparejar(Token.Tipo.MAYOR, operadorL);
                if (tokenActual.GetTIPO() == Token.Tipo.IGUAL)
                {
                    emparejar(Token.Tipo.IGUAL, operadorL);

                }
                else
                {
                }
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.MENOR)
            {
                emparejar(Token.Tipo.MENOR, operadorL);
                if (tokenActual.GetTIPO() == Token.Tipo.IGUAL)
                {
                    emparejar(Token.Tipo.IGUAL, operadorL);

                }
                else
                {
                }

            }
            if (tokenActual.GetTIPO() == Token.Tipo.IGUAL)
            {
                emparejar(Token.Tipo.IGUAL, operadorL);
                emparejar(Token.Tipo.IGUAL, operadorL);
            }
            else
            {
            }
        }
        public void CONDICION(String condicion)
        {

            DATO(condicion);
            OPERADOR_L(condicion);
            DATO(condicion);
        }

        public void DECLARACION()
        {
            if (tokenActual.GetTIPO() == Token.Tipo.CADENA)
            {
                emparejar(Token.Tipo.CADENA, "declarasiones");
                OTRADECLARACION();
                emparejar(Token.Tipo.PUNTO_Y_COMA, "declarasiones");
            }

            else
            {

            }
        }
        public void OTRADECLARACION()
        {
            if (tokenActual.GetTIPO() == Token.Tipo.COMA)
            {
                emparejar(Token.Tipo.COMA, "declarasiones");
                emparejar(Token.Tipo.CADENA, "declarasiones");
                if (tokenActual.GetTIPO() == Token.Tipo.COMA)
                {
                    OTRADECLARACION();
                }
                else if (tokenActual.GetTIPO() == Token.Tipo.IGUAL)
                {
                    emparejar(Token.Tipo.IGUAL, "declarasiones");
                    DATO("declarasiones");
                    if (tokenActual.GetTIPO() == Token.Tipo.COMA)
                    {
                        OTRADECLARACION();
                    }
                }

            }
            else if (tokenActual.GetTIPO() == Token.Tipo.IGUAL)
            {
                emparejar(Token.Tipo.IGUAL, "declarasiones");
                DATO("declarasiones");
                if (tokenActual.GetTIPO() == Token.Tipo.COMA)
                {
                    OTRADECLARACION();
                }
            }

            else
            {
            }

        }
        public void DATO(String traduccion)
        {
            if (tokenActual.GetTIPO() == Token.Tipo.CADENA_STRING)
            {
                emparejar(Token.Tipo.CADENA_STRING, traduccion);
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.CARACTER)
            {
                emparejar(Token.Tipo.CARACTER, traduccion);
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.NUMERO)
            {
                emparejar(Token.Tipo.NUMERO, traduccion);
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.BOOL)
            {
                emparejar(Token.Tipo.BOOL, traduccion);
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.CADENA)
            {
                emparejar(Token.Tipo.CADENA, traduccion);
            }
            else
            {
            }
            OTRODATO(traduccion);
        }
        public void OTRODATO(String dato)
        {
            if (tokenActual.GetTIPO() == Token.Tipo.PR_AB || tokenActual.GetTIPO() == Token.Tipo.PR_CR ||
                tokenActual.GetTIPO() == Token.Tipo.MENOS || tokenActual.GetTIPO() == Token.Tipo.MAS ||
                    tokenActual.GetTIPO() == Token.Tipo.MULT || tokenActual.GetTIPO() == Token.Tipo.DIV)
            {
                OPERADOR(dato);
                DATO(dato);
            }

        }
        public void ASIGNACION()
        {
            if (tokenActual.GetTIPO() == Token.Tipo.IGUAL)
            {
                emparejar(Token.Tipo.IGUAL, "asignasion");
                DATO("asignasion");
                if (tokenActual.GetTIPO() == Token.Tipo.MENOS || tokenActual.GetTIPO() == Token.Tipo.MAS ||
                    tokenActual.GetTIPO() == Token.Tipo.MULT || tokenActual.GetTIPO() == Token.Tipo.DIV)
                {
                    OPERADOR("asignasion");
                    DATO("asignasion");
                }
                emparejar(Token.Tipo.PUNTO_Y_COMA, "asignasion");
            }
            else
            {

            }
        }

        public void emparejar(Token.Tipo tipoToken, String tipoTrad)
        {
            if (tokenActual.GetTIPO() != tipoToken)
            {
                Console.WriteLine("Error se esperaba " + GetTipoError(tipoToken) + "----" + tokenActual.Imprimir());
                agregarError(tokenActual.GetFila(), tokenActual.GetColumna(), tokenActual.GetValor(), "Error se esperaba: " + GetTipoError(tipoToken));

            }

            if (controlToken < listaTok.Count - 1)
            {
                traducir(tipoTrad, tipoToken);
                controlToken += 1;
                tokenActual = listaTok.ElementAt(controlToken);

            }
        }
        public String GetTipoError(Token.Tipo tipoToken)
        {
            switch (tipoToken)
            {
                case Token.Tipo.ID:
                    return "Identificador";
                case Token.Tipo.CADENA:
                    return "Cadena";
                case Token.Tipo.NUMERO:
                    return "Numero";
                case Token.Tipo.SIGNO_DOS_PUNTOS:
                    return "Signo dos puntos";
                case Token.Tipo.LLAVE_ABIERTA:
                    return "Llave abierta";
                case Token.Tipo.LLAVE_CIERRA:
                    return "Llave cierra";
                case Token.Tipo.COR_ABIERTA:
                    return "Corchete abierto";
                case Token.Tipo.COR_CIERRA:
                    return "Corchete cerrado";
                case Token.Tipo.PUNTO_Y_COMA:
                    return "Punto y coma";
                case Token.Tipo.CARACTER:
                    return "Caracter";
                case Token.Tipo.CADENA_STRING:
                    return "Cadena tipo string";
                case Token.Tipo.DIAGONALINV:
                    return "DiagonalInv";
                case Token.Tipo.COMA:
                    return "Coma";
                case Token.Tipo.SUMA:
                    return "Suma";
                case Token.Tipo.RESTA:
                    return "Resta";
                case Token.Tipo.MULT:
                    return "Multiplicacion";
                case Token.Tipo.PUNTO:
                    return "Punto";
                case Token.Tipo.IGUAL:
                    return "Igual";
                case Token.Tipo.DIV:
                    return "Divicion";
                case Token.Tipo.PR_AB:
                    return "Parentecis abierto";
                case Token.Tipo.PR_CR:
                    return "Parentecis cerrado";
                case Token.Tipo.MAYOR:
                    return "Mayor que";
                case Token.Tipo.MENOR:
                    return "Menor que";
                case Token.Tipo.MAS:
                    return "Signo mas";
                case Token.Tipo.MENOS:
                    return "Signo menos";
                case Token.Tipo.BOOL:
                    return "Asignacion Bool";
                case Token.Tipo.COMENTARIO:
                    return "Comentario";
                case Token.Tipo.COMENTARIO_LARGO:
                    return "Comentario de varias lineas";
                default:
                    return "Desconocido";
            }
        }
        public void traducirAsignacion(Token token)
        {
            Token tokenAnt = listaTok.ElementAt(controlToken - 1);
            if (token.GetId() < 12)
            {
                return;
            }
            else if (token.GetTIPO() == Token.Tipo.CADENA)
            {
                if (tokenAnt.GetTIPO() == Token.Tipo.PUNTO_Y_COMA || tokenAnt.GetTIPO() == Token.Tipo.LLAVE_ABIERTA)
                {
                    for (int i = 0; i < tabulaciones; i++)
                    {
                        cadenaPyton += '\t';
                    }
                }

                cadenaPyton += token.GetValor();
            }
            else if (token.GetTIPO() == Token.Tipo.IGUAL)
            {
                cadenaPyton += token.GetValor();
            }
            else if (token.GetTIPO() == Token.Tipo.CADENA_STRING)
            {
                cadenaPyton += token.GetValor();
            }
            else if (token.GetTIPO() == Token.Tipo.NUMERO)
            {
                cadenaPyton += token.GetValor();
            }
            else if (token.GetTIPO() == Token.Tipo.CARACTER)
            {
                cadenaPyton += token.GetValor();
            }
            else if (token.GetTIPO() == Token.Tipo.BOOL)
            {
                cadenaPyton += token.GetValor();
            }
            else if (token.GetTIPO() == Token.Tipo.CADENA)
            {
                cadenaPyton += token.GetValor();
            }
            else if (token.GetTIPO() == Token.Tipo.MAS)
            {
                cadenaPyton += token.GetValor();
            }
            else if (token.GetTIPO() == Token.Tipo.MENOS)
            {
                cadenaPyton += token.GetValor();
            }
            else if (token.GetTIPO() == Token.Tipo.MULT)
            {
                cadenaPyton += token.GetValor();
            }
            else if (token.GetTIPO() == Token.Tipo.DIV)
            {
                cadenaPyton += token.GetValor();
            }
            else if (token.GetTIPO() == Token.Tipo.PR_AB)
            {
                cadenaPyton += token.GetValor();
            }
            else if (token.GetTIPO() == Token.Tipo.PR_CR)
            {
                cadenaPyton += token.GetValor();
            }
            else if (token.GetTIPO() == Token.Tipo.PUNTO_Y_COMA)
            {
                cadenaPyton += '\n';
            }


        }
        public void traducirDeclaracion()
        {
            Token tokenAnt = listaTok.ElementAt(controlToken - 1);
            if (tokenActual.GetId() < 12)
            {
                return;
            }
            else if ((tokenActual.GetTIPO() == Token.Tipo.IGUAL) && (tokenAnt.GetTIPO() == Token.Tipo.CADENA))
            {
                for (int i = 0; i < tabulaciones; i++)
                {
                    cadenaPyton += '\t';
                }
                cadenaPyton += tokenAnt.GetValor();
                cadenaPyton += tokenActual.GetValor();
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.CADENA && (tokenAnt.GetTIPO() == Token.Tipo.MAS))
            {
                cadenaPyton += tokenActual.GetValor();
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.MAS)
            {
                cadenaPyton += tokenActual.GetValor();
            }
            else if (((tokenAnt.GetTIPO() == Token.Tipo.NUMERO) || (tokenAnt.GetTIPO() == Token.Tipo.CADENA_STRING) ||
                                  (tokenAnt.GetTIPO() == Token.Tipo.CARACTER) || (tokenAnt.GetTIPO() == Token.Tipo.BOOL)
                                  && (tokenActual.GetTIPO() == Token.Tipo.COMA || tokenActual.GetTIPO() == Token.Tipo.PUNTO_Y_COMA)))
            {
                cadenaPyton += '\n';
            }
            else if (((tokenActual.GetTIPO() == Token.Tipo.NUMERO) || (tokenActual.GetTIPO() == Token.Tipo.CADENA_STRING) ||
                      (tokenActual.GetTIPO() == Token.Tipo.CARACTER) || (tokenActual.GetTIPO() == Token.Tipo.BOOL)
                      && (tokenAnt.GetTIPO() == Token.Tipo.IGUAL)))
            {
                if (tokenActual.GetValor().Equals("true"))
                {
                    cadenaPyton += "True";
                }
                else if (tokenActual.GetValor().Equals("false"))
                {
                    cadenaPyton += "False";
                }
                else
                {
                    cadenaPyton += tokenActual.GetValor();
                }
            }
        }
        public void traducirIFWhile()
        {
            Token tokenAnt = listaTok.ElementAt(controlToken - 1);
            if (tokenActual.GetTIPO() == Token.Tipo.ID)
            {
                if (tokenAnt.GetTIPO() != Token.Tipo.ID)
                {
                    for (int i = 0; i < tabulaciones; i++)
                    {
                        cadenaPyton += '\t';
                    }
                }

                cadenaPyton += tokenActual.GetValor() + " ";
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.MAYOR)
            {
                cadenaPyton += tokenActual.GetValor();
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.MENOR)
            {
                cadenaPyton += tokenActual.GetValor();
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.IGUAL)
            {
                cadenaPyton += tokenActual.GetValor();
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.EXCLAMASION)
            {
                cadenaPyton += tokenActual.GetValor();
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.NUMERO)
            {
                cadenaPyton += tokenActual.GetValor();
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.CADENA)
            {
                cadenaPyton += tokenActual.GetValor();
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.CADENA_STRING)
            {
                cadenaPyton += tokenActual.GetValor();
            }

            else if (tokenActual.GetTIPO() == Token.Tipo.PR_CR)
            {
                cadenaPyton += ":" + '\n';
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.LLAVE_ABIERTA)
            {
                tabulaciones++;
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.LLAVE_CIERRA)
            {
                tabulaciones--;
            }

        }
        public void traducirELSE()
        {
            Token tokenAnt = listaTok.ElementAt(controlToken + 1);
            if (tokenActual.GetTIPO() == Token.Tipo.ID)
            {

                for (int i = 0; i < tabulaciones; i++)
                {
                    cadenaPyton += '\t';
                }
                if (tokenAnt.GetTIPO() == Token.Tipo.ID)
                {
                    cadenaPyton += "el";
                }
                else
                {
                    cadenaPyton += tokenActual.GetValor() + " ";

                }
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.LLAVE_ABIERTA)
            {
                cadenaPyton += ':';
                cadenaPyton += '\n';
                tabulaciones++;
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.LLAVE_CIERRA)
            {
                tabulaciones--;
            }
        }
        public void traducirFor()
        {
            Token tokenAnt = listaTok.ElementAt(controlToken + 1);
            if (tokenActual.GetTIPO() == Token.Tipo.ID && tokenActual.GetValor() == "for")
            {
                if (tokenAnt.GetTIPO() != Token.Tipo.ID)
                {
                    for (int i = 0; i < tabulaciones; i++)
                    {
                        cadenaPyton += '\t';
                    }
                }

                cadenaPyton += tokenActual.GetValor() + " ";
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.CADENA)
            {
                if (varEnFor == 0)
                {
                    cadenaPyton += tokenActual.GetValor() + " in range(";
                    varEnFor++;
                }
                else if (tokenAnt.GetTIPO() == Token.Tipo.PUNTO_Y_COMA)
                {
                    cadenaPyton += ',' + tokenActual.GetValor() + ')';
                }

            }
            else if (tokenActual.GetTIPO() == Token.Tipo.NUMERO)
            {
                if (varEnFor == 1)
                {
                    cadenaPyton += tokenActual.GetValor();
                    varEnFor++;
                }
                else
                {
                    cadenaPyton += ',' + tokenActual.GetValor() + ')';
                }
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.PR_CR)
            {
                cadenaPyton += ":" + '\n';
                varEnFor = 0;
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.LLAVE_ABIERTA)
            {
                tabulaciones++;
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.LLAVE_CIERRA)
            {
                tabulaciones--;
            }

        }
        public void traducirConsole()
        {
            Token tokenAnt = listaTok.ElementAt(controlToken - 1);

            if (tokenActual.GetValor() == "Console.WriteLine")
            {
                if (tokenAnt.GetTIPO() == Token.Tipo.PUNTO_Y_COMA || tokenAnt.GetTIPO() == Token.Tipo.LLAVE_ABIERTA)
                {
                    for (int i = 0; i < tabulaciones; i++)
                    {
                        cadenaPyton += '\t';
                    }
                }
                else if (tokenActual.GetTIPO() == Token.Tipo.PUNTO_Y_COMA)
                {
                    cadenaPyton += '\n';
                }

                cadenaPyton += "print";
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.CADENA)
            {
                cadenaPyton += tokenActual.GetValor();
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.PUNTO_Y_COMA)
            {
                cadenaPyton += '\n';
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.CADENA_STRING)
            {
                cadenaPyton += tokenActual.GetValor();
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.NUMERO)
            {
                cadenaPyton += tokenActual.GetValor();
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.CARACTER)
            {
                cadenaPyton += tokenActual.GetValor();
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.BOOL)
            {
                cadenaPyton += tokenActual.GetValor();
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.CADENA)
            {
                cadenaPyton += tokenActual.GetValor();
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.MAS)
            {
                cadenaPyton += tokenActual.GetValor();
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.PR_AB)
            {
                cadenaPyton += tokenActual.GetValor();
            }
            else if (tokenActual.GetTIPO() == Token.Tipo.PR_CR)
            {
                cadenaPyton += tokenActual.GetValor();
            }
        }
        public void traducir(String tipoTrad, Token.Tipo tipoToken)
        {
            switch (tipoTrad)
            {
                case "console":
                    traducirConsole();
                    break;
                case "asignasion":
                    traducirAsignacion(tokenActual);
                    break;
                case "declarasiones":
                    traducirDeclaracion();
                    break;
                case "if":
                    traducirIFWhile();
                    break;
                case "while":
                    traducirIFWhile();
                    break;
                case "for":
                    traducirFor();
                    break;
                case "else":
                    traducirELSE();
                    break;
            }

        }
        public void agregarError(int fila, int columna, String error, String correcto)
        {
            listaErrorS.AddLast(new ErrorSint(contadorErr, fila, columna, error, correcto));
            contadorErr++;
        }
        public LinkedList<ErrorSint> GetListaErrorSint()
        {
            return listaErrorS;
        }
    }
}
