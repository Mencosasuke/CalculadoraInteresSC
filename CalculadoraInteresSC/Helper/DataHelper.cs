using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculadoraInteresSC.Helper
{
    class DataHelper
    {
        /// <summary>
        /// Valores para calculo de días según metodo del calculo, ordinario o exacto.
        /// </summary>
        private int[] calculoDias = { 30, 31 };

        /// <summary>
        /// Calcula la cantidad en años, meses y días para un valor de tiempo dado en años.
        /// </summary>
        /// <param name="valor">Cantidad de tiempo en años</param>
        /// <param name="metodo">Metodo de calculor de tiempo. 0 hace referencia al metodo ordinario y 1 al exacto</param>
        /// <returns>String del equivalente en años, meses y días</returns>
        public String ConvertirPeriodoEnAños(decimal valor, int metodo)
        {
            int año = 0, mes = 0, dia = 0;
            
            int enteroAux = 0;
            decimal decimalAux = 0;
            decimal valorAux = 0;

            enteroAux = Int32.Parse(valor.ToString().Split('.')[0]);
            decimalAux = valor - enteroAux;

            año = enteroAux;

            valorAux = decimalAux * 12;

            enteroAux = Int32.Parse(valorAux.ToString().Split('.')[0]);
            decimalAux = valorAux - enteroAux;

            mes = enteroAux;

            valorAux = decimalAux * calculoDias[metodo];

            dia = (int)valorAux;

            return String.Format("{0} años, {1} meses y {2} días.", año, mes, dia);
        }
    }
}
