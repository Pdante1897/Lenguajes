using System;

namespace PracticaL
{
    public class Token
    {
        public enum Tipo
        {
            PALABRA_RESERVADA,
            CADENA,
            LLAVE_ABIERTA,
            LLAVE_CIERRA,
            CORCHETE_ABIERTA,
            CORCHETE_CIERRA,
            SIGNO_DOS_PUNTOS,
            NUMERO,
            SIGNO_COMILLAS,
            DESCONOCIDO,
            PARENTECIS_ABRE,
            PARENTECIS_CIERRA,
            MAYOR,
            MENOR,
            PUNTO_Y_COMA

        }
        private int id;
        private Tipo tipoToken;
        private String valor;

        public Token(int id, Tipo tipoToken, String valor)
        {
            this.id = id;
            this.tipoToken = tipoToken;
            this.valor = valor;
        }

        public String GetValor()
        {
            return valor;
        }
        public int GetId()
        {
            return id;
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
                case Tipo.SIGNO_COMILLAS:
                    return "Comillas";
                case Tipo.CORCHETE_ABIERTA:
                    return "Corchete abierto";
                case Tipo.CORCHETE_CIERRA:
                    return "Corchete cerrado";
                case Tipo.PARENTECIS_ABRE:
                    return "Parentecis abierto";
                case Tipo.PARENTECIS_CIERRA:
                    return "Parentecis cerrado";
                case Tipo.MAYOR:
                    return "Mayor que";
                case Tipo.MENOR:
                    return "Menor que";
                case Tipo.PUNTO_Y_COMA:
                    return "Punto y coma";
                case Tipo.DESCONOCIDO:
                    return "Desconocido";
                default:
                    return "Desconocido";




            }
        }
    }
}
