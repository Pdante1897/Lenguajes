using System;

namespace Proyecto2L
{
    public class ErrorSint
    {
        public int id;
        public int fila;
        public int columna;
        public String error;
        public String correcto;
        public ErrorSint(int id, int fila, int columna, String error, String correcto)
        {
            this.id = id;
            this.fila = fila;
            this.columna = columna;
            this.error = error;
            this.correcto = correcto;
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

        public String GetError()
        {
            return error;
        }
        public String GetCorrecto()
        {
            return correcto;
        }

    }

}
