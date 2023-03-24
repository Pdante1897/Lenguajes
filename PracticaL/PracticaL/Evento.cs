using System;

namespace PracticaL
{
    public class Evento
    {
        private String dia;
        private String mes;
        private String anio;
        private String descripcion;
        private String path;

        public Evento()
        {
        }
        public Evento(string anio, string mes, string dia)
        {
            this.dia = dia;
            this.mes = mes;
            this.anio = anio;
        }
        public String GetDia()
        {
            return dia;
        }
        public String GetMes()
        {
            return mes;
        }
        public String GetAnio()
        {
            return anio;
        }
        public String GetDescripcion()
        {
            return descripcion;
        }
        public String GetPath()
        {
            return path;
        }
        public void SetDescripcion(String descripcion)
        {
            this.descripcion = descripcion;
        }
        public void SetPath(String path)
        {
            this.path = path;
        }

        public new string ToString()
        {
            return "Anio: " + anio + "Mes: " + mes + "Dia: " + dia + "Descripcion: " + descripcion + "Path: " + path;
        }
    }
}
