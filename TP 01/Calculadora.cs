using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lippi.Franco.TP01
{
    class Calculadora
    {
        #region Metodos

        public static double operar(Numero NumeroA, Numero NumeroB, string Operacion)
        {
            double numA, numB;

            double retorno = 0;

            numA = NumeroA.getNumero();

            numB = NumeroB.getNumero();

            switch (Operacion)
            {
                case "*":
                    retorno = numA * numB;
                    break;

                case "/":
                    if (numB != 0)
                        retorno = numA / numB;
                    break;

                case "+":
                    retorno = numA + numB;
                    break;

                case "-":
                    retorno = numA - numB;
                    break;

            }

            return retorno;
        }

        // Validamos el operador (+ por defecto)

        public static string validaOperador(string Operador)
        {
            string retorno;

            if (Operador.Equals("*") || Operador.Equals("-") || Operador.Equals("/"))
            {
                retorno = Operador;
            }
            else
            {
                retorno = "+";
            }

            return retorno;
        }
        
        #endregion
    }
}
