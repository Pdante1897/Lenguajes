using System;

namespace Proyecto1L
{
    public class Error
    {
        private int id;
        private String valor;
        private String descripcion;
        private int fila;
        private int columna;

        public Error(int id, String valor, String descripcion, int fila, int columna)
        {
            this.id = id;
            this.valor = valor;
            this.descripcion = descripcion;
            this.fila = fila;
            this.columna = columna;
        }
        public int GetId()
        {
            return id;
        }
        public String GetValor()
        {
            return valor;
        }
        public String GetDescripcion()
        {
            return descripcion;
        }
        public int GetFila()
        {
            return fila;
        }
        public int GetColumna()
        {
            return columna;
        }
    }
}
