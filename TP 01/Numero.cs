using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lippi.Franco.TP01
{
    class Numero
    {
        #region Atributos

        // Atributo

        private double numero;

        #endregion
        
        #region Constructores

        // Constructor

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string numero)
        {
            this.setNumero(numero);
        }

        #endregion

        #region Metodos

        // Devuelve el valor del numero.

        public double getNumero()
        {
            return this.numero;
        }

        private void setNumero(string numero)
        {
            this.numero = Numero.validaNumero(numero);
        }

        /// Valida el valor y lo devuelve

        private static double validaNumero(string numeroCadena)
        {

            double retorno = 0.0;

            double auxiliar;

            if (double.TryParse(numeroCadena, out auxiliar))
                retorno = auxiliar;

            return retorno;
        }

        #endregion
    }
}
