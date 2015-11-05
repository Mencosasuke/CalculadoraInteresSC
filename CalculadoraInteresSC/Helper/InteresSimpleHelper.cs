using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculadoraInteresSC.Helper
{
    class InteresSimpleHelper
    {

        /// <summary>
        /// Instancia de clase dataHelper para manipulación de datos
        /// </summary>
        private DataHelper dataHelper = new DataHelper();

        /// <summary>
        /// Obtiene el valor del Interes en funcion del valor actual P.
        /// </summary>
        /// <param name="P">Valor actual</param>
        /// <param name="i">Tasa de interes</param>
        /// <param name="n">Período de tiempo</param>
        /// <returns></returns>
        public String CalcularInteres(decimal P, decimal i, decimal n)
        {
            decimal resultado = P * i * n;
            return resultado.ToString("n0");
        }

        /// <summary>
        /// Calcula el valor del monto
        /// </summary>
        /// <param name="P">Valor actual</param>
        /// <param name="n">Período de tiempo</param>
        /// <param name="i">Tasa de interes</param>
        /// <returns></returns>
        public String CalcularMonto(decimal P, decimal n, decimal i)
        {
            decimal resultado = P * (1 + (n * i));
            return resultado.ToString("n0");
        }

        /// <summary>
        /// Calcula el valor actual P en función del Interes
        /// </summary>
        /// <param name="I">Interes acumulado</param>
        /// <param name="i">Tasa de interes</param>
        /// <param name="n">Período de tiempo</param>
        /// <returns></returns>
        public String CalcularValorActualEnFuncionDeI(decimal I, decimal i, decimal n)
        {
            decimal resultado = I / ( i * n);
            return resultado.ToString("n0");
        }

        /// <summary>
        /// Calcula el valor actual P en funcion del monto
        /// </summary>
        /// <param name="S">Monto al final de la operacion</param>
        /// <param name="n">Periodo de tiempo</param>
        /// <param name="i">Tasa de interés</param>
        /// <returns></returns>
        public String CalcularValorActualEnFuncionDeS(decimal S, decimal n, decimal i)
        {
            decimal resultado = S / (1 + (n * i));
            return resultado.ToString("n0");
        }

        /// <summary>
        /// Calcula la tasa de interes en función del Interes
        /// </summary>
        /// <param name="I">Interes acumulado</param>
        /// <param name="P">Valor Actual</param>
        /// <param name="n">Período de tiempo</param>
        /// <returns></returns>
        public String CalcularTasaInteresEnFuncionDeI(decimal I, decimal P, decimal n)
        {
            decimal resultado = I / (P * n);
            resultado = resultado * 100;
            return resultado.ToString("n2");
        }

        /// <summary>
        /// Calcula la tasa de interes en función del monto
        /// </summary>
        /// <param name="S">Monto al final de la operacion</param>
        /// <param name="P">Valor actual</param>
        /// <param name="n">Período de tiempo</param>
        /// <returns></returns>
        public String CalcularTasaInteresEnFuncionDeS(decimal S, decimal P, decimal n)
        {
            decimal resultado = ((S / P) - 1) / n;
            resultado = resultado * 100;
            return resultado.ToString("n2");
        }

        /// <summary>
        /// Calcula el periodo de tiempo en función del interes
        /// </summary>
        /// <param name="I">Interes acumulado</param>
        /// <param name="P">Valor Actual</param>
        /// <param name="i">Tasa de interes</param>
        /// <param name="metodo">Metodo para calculo de fecha</param>
        /// <returns></returns>
        public String CalcularPeriodoEnFuncionDeI(decimal I, decimal P, decimal i, int metodo)
        {
            decimal resultado = I / (P * i);
            return dataHelper.ConvertirPeriodoEnAños(resultado, metodo);
        }

        /// <summary>
        /// Calcula el período de tiempo en función del monton
        /// </summary>
        /// <param name="S">Monto al final de la operacion</param>
        /// <param name="P">Valor actual</param>
        /// <param name="i">Tasa de interés</param>
        /// <param name="metodo">Metodo para calculo de fecha</param>
        /// <returns></returns>
        public String CalcularPeriodoEnFuncionDeS(decimal S, decimal P, decimal i, int metodo)
        {
            decimal resultado = ((S / P) - 1) / i;
            return dataHelper.ConvertirPeriodoEnAños(resultado, metodo);
        }
    }
}
