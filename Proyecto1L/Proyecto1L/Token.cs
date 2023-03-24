using System;

namespace Proyecto1L
{
    public class Token
    {
        public enum Tipo
        {
            PALABRA_RESERVADA,
            NUMERO,
            CADENA,
            LLAVE_ABIERTA,
            LLAVE_CIERRA,
            PUNTO_Y_COMA,
            SIGNO_DOS_PUNTOS,
            PORCIENTO
        }
        private int id;
        private Tipo tipoToken;
        private String valor;
        private int fila;
        private int columna;
        private String color;

        public Token(int id, Tipo tipoToken, String valor, int fila, int columna, String color)
        {
            this.id = id;
            this.tipoToken = tipoToken;
            this.valor = valor;
            this.fila = fila;
            this.columna = columna;
            this.color = color;

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
        public String GetColor()
        {
            return color;
        }
        public String GetValor()
        {
            return valor;
        }
        public String GetTipo()
        {
            switch (tipoToken)
            {
                case Tipo.PALABRA_RESERVADA:
                    return "Palabra reservada";
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
                case Tipo.PUNTO_Y_COMA:
                    return "Punto y coma";
                case Tipo.PORCIENTO:
                    return "Signo de Porcentaje";
                default:
                    return "Desconocido";
            }
        }
    }
}

