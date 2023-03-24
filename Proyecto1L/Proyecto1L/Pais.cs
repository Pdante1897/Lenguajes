using System;

namespace Proyecto1L
{
    public class Pais
    {
        public String continente;
        public String pais;
        public int saturacionConti;
        public int saturacionPais;
        public String ruta;
        public String poblacion;
        public Pais()
        {
        }
        public Pais(String continente, String pais, int saturacionPais, String ruta, String poblacion)
        {
            this.continente = continente;
            this.pais = pais;
            this.saturacionPais = saturacionPais;
            this.ruta = ruta;
            this.poblacion = poblacion;
        }
        public void SetRuta(String ruta)
        {
            this.ruta = ruta;
        }
        public String GetRuta()
        {
            return ruta;
        }
        public void SetSatConti(int saturacionConti)
        {
            this.saturacionConti = saturacionConti;
        }
        public String GetContinente()
        {
            return continente;
        }
        public String GetPais()
        {
            return pais;
        }
        public int GetSaturacionP()
        {
            return saturacionPais;
        }
        public int GetSaturacionG()
        {
            return saturacionConti;
        }
        public String imprimir()
        {
            return pais + "  " + saturacionPais + "  " + continente + "  " + saturacionConti + "  " + ruta;
        }
    }

}
