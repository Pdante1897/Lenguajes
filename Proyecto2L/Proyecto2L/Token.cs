using System;

namespace Proyecto2L
{
    public class Token
    {
        public enum Tipo
        {
            ID,
            NUMERO,
            CADENA,
            COR_ABIERTA,
            COR_CIERRA,
            LLAVE_ABIERTA,
            LLAVE_CIERRA,
            PUNTO_Y_COMA,
            SIGNO_DOS_PUNTOS,
            CARACTER,
            CADENA_STRING,
            COMA,
            DIAGONALINV,
            DIV,
            MULT,
            SUMA,
            RESTA,
            PUNTO,
            IGUAL,
            PR_AB,
            PR_CR,
            MAYOR,
            MENOR,
            MAS,
            MENOS,
            BOOL,
            COMENTARIO,
            COMENTARIO_LARGO,
            ULTIMO,
            EXCLAMASION
        }
        private int id;
        private Tipo tipoToken;
        private String valor;
        private int fila;
        private int columna;

        public Token(int id, Tipo tipoToken, String valor, int fila, int columna)
        {
            this.id = id;
            this.tipoToken = tipoToken;
            this.valor = valor;
            this.fila = fila;
            this.columna = columna;
        }
        public int GetId()
        {
            return id;
        }
        public int GetFila()
        {
            return fila;
        }
        public int GetColumna()
        {
            return columna;
        }

        public String GetValor()
        {
            return valor;
        }
        public Tipo GetTIPO()
        {
            return tipoToken;
        }
        public String GetTipo()
        {
            switch (tipoToken)
            {
                case Tipo.EXCLAMASION:
                    return "Exclamasion";
                case Tipo.ID:
                    return "Identificador";
                case Tipo.CADENA:
                    return "Cadena";
                case Tipo.NUMERO:
                    return "Numero";
                case Tipo.SIGNO_DOS_PUNTOS:
                    return "Signo dos puntos";
                case Tipo.LLAVE_ABIERTA:
                    return "Llave abierta";
                case Tipo.LLAVE_CIERRA:
                    return "Llave cierra";
                case Tipo.COR_ABIERTA:
                    return "Corchete abierto";
                case Tipo.COR_CIERRA:
                    return "Corchete cerrado";
                case Tipo.PUNTO_Y_COMA:
                    return "Punto y coma";
                case Tipo.CARACTER:
                    return "Caracter";
                case Tipo.CADENA_STRING:
                    return "Cadena tipo string";
                case Tipo.DIAGONALINV:
                    return "DiagonalInv";
                case Tipo.COMA:
                    return "Coma";
                case Tipo.SUMA:
                    return "Suma";
                case Tipo.RESTA:
                    return "Resta";
                case Tipo.MULT:
                    return "Multiplicacion";
                case Tipo.PUNTO:
                    return "Punto";
                case Tipo.IGUAL:
                    return "Igual";
                case Tipo.DIV:
                    return "Divicion";
                case Tipo.PR_AB:
                    return "Parentecis abierto";
                case Tipo.PR_CR:
                    return "Parentecis cerrado";
                case Tipo.MAYOR:
                    return "Mayor que";
                case Tipo.MENOR:
                    return "Menor que";
                case Tipo.MAS:
                    return "Signo mas";
                case Tipo.MENOS:
                    return "Signo menos";
                case Tipo.BOOL:
                    return "Asignacion Bool";
                case Tipo.COMENTARIO:
                    return "Comentario";
                case Tipo.COMENTARIO_LARGO:
                    return "Comentario de varias lineas";
                default:
                    return "Desconocido";
            }
        }
        public String Imprimir()
        {
            return "Id " + GetId() + " ---Valor " + GetValor() + " ---Fila " + GetFila() + " ---Columna " + GetColumna() + " ---Tipo " + GetTipo() + " ";
        }
    }
}
