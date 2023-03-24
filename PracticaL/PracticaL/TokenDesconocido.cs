using System;

namespace PracticaL
{
    public class TokenDesconocido
    {

        private int id;
        private int fila;
        private int columna;
        private String tipoToken;
        private String valor;

        public TokenDesconocido(int id, int fila, int columna, String tipoToken, String valor)
        {
            this.id = id;
            this.fila = fila;
            this.columna = columna;
            this.tipoToken = tipoToken;
            this.valor = valor;
        }
        public string GetTipo()
        {
            return null;
        }
        public String GetValor()
        {
            return valor;
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
        public String GetTipoToken()
        {
            return "Desconocido";
        }
    }
}
