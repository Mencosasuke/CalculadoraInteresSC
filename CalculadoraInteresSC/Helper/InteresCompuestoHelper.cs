using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculadoraInteresSC.Helper
{
    class InteresCompuestoHelper
    {

        /// <summary>
        /// Instancia de clase dataHelper para manipulación de datos
        /// </summary>
        private DataHelper dataHelper = new DataHelper();

        /// <summary>
        /// Calcula el valor del interes utilizando una tasa de interes efectiva
        /// </summary>
        /// <param name="P">Valor actual</param>
        /// <param name="i">Tasa de interes</param>
        /// <param name="n">Periodo de tiempo</param>
        /// <returns></returns>
        public String CalcularInteresTasaEfectiva(decimal P, decimal i, decimal n)
        {
            double resultado = Convert.ToDouble(P) * (Math.Pow((1 + Convert.ToDouble(i)), Convert.ToDouble(n)) - 1);
            return resultado.ToString("n0");
        }

        /// <summary>
        /// Calcula el valor del interes utilizando una tasa de interes nominal
        /// </summary>
        /// <param name="P">Valor actual</param>
        /// <param name="i">Tasa de interes</param>
        /// <param name="n">Periodo de tiempo</param>
        /// <param name="m">Numero de capitalizaciones</param>
        /// <returns></returns>
        public String CalcularInteresTasaNominal(decimal P, decimal i, decimal n, decimal m)
        {
            double resultado = Convert.ToDouble(P) * (Math.Pow(1 + (Convert.ToDouble(i) / Convert.ToDouble(m)), (Convert.ToDouble(n) * Convert.ToDouble(m))) - 1);
            return resultado.ToString("n0");
        }

        /// <summary>
        /// Calcula el valor del monton utilizando una tasa de interes efectiva
        /// </summary>
        /// <param name="P">Valor actual</param>
        /// <param name="i">Tasa de interes</param>
        /// <param name="n">Periodo de tiempo</param>
        /// <returns></returns>
        public String CalcularMontoTasaEfectiva(decimal P, decimal i, decimal n)
        {
            double resultado = Convert.ToDouble(P) * Math.Pow((1 + Convert.ToDouble(i)), Convert.ToDouble(n));
            return resultado.ToString("n0");
        }

        /// <summary>
        /// Calcula el valor del monton utilizando una tasa de interes efectiva
        /// </summary>
        /// <param name="P">Valor actual</param>
        /// <param name="i">Tasa de interes</param>
        /// <param name="n">Periodo de tiempo</param>
        /// <param name="m">Numero de capitalizaciones</param>
        /// <returns></returns>
        public String CalcularMontoTasaNominal(decimal P, decimal i, decimal n, decimal m)
        {
            double resultado = Convert.ToDouble(P) * Math.Pow((1 + (Convert.ToDouble(i) / Convert.ToDouble(m))), (Convert.ToDouble(m) * Convert.ToDouble(n)));
            return resultado.ToString("n0");
        }

        /// <summary>
        /// Calcula el valor actual utilizando una tasa de interes efectiva
        /// </summary>
        /// <param name="I">Interes acumulado</param>
        /// <param name="S">Monto</param>
        /// <param name="i">Tasa de interes</param>
        /// <param name="n">Periodo de tiempo</param>
        /// <returns></returns>
        public String CalcularValorActualTasaEfectiva(decimal I, decimal S, decimal i, decimal n)
        {
            double resultado = 0;

            if (I > 0)
            {
                resultado = Convert.ToDouble(I) / (Math.Pow((1 + Convert.ToDouble(i)), Convert.ToDouble(n)) - 1);
            }
            else
            {
                resultado = Convert.ToDouble(S) * Math.Pow((1 + Convert.ToDouble(i)), -(Convert.ToDouble(n)));
            }

            return resultado.ToString("n0");
        }

        /// <summary>
        /// Calcula el valor actual utilizando una tasa de interes efectiva
        /// </summary>
        /// <param name="I">Interes acumulado</param>
        /// <param name="S">Monto</param>
        /// <param name="i">Tasa de interes</param>
        /// <param name="n">Periodo de tiempo</param>
        /// <param name="m">Numero de capitalizaciones</param>
        /// <returns></returns>
        public String CalcularValorActualTasaNominal(decimal I, decimal S, decimal i, decimal n, decimal m)
        {
            double resultado = 0;

            if (I > 0)
            {
                resultado = Convert.ToDouble(I) / (Math.Pow((1 + (Convert.ToDouble(i) / Convert.ToDouble(m))), (Convert.ToDouble(m) * Convert.ToDouble(n))) - 1);
            }
            else
            {
                resultado = Convert.ToDouble(S) * Math.Pow((1 + (Convert.ToDouble(i) / Convert.ToDouble(m))), (-(Convert.ToDouble(m)) * Convert.ToDouble(n)));
            }

            return resultado.ToString("n0");
        }

        /// <summary>
        /// Calcula el valor de la tasa de interes con una tasa efectiva
        /// </summary>
        /// <param name="I">Interes acumulado</param>
        /// <param name="S">Monto</param>
        /// <param name="P">Valor Actual</param>
        /// <param name="n">Periodo de tiempo</param>
        /// <returns></returns>
        public String CalcularTasaInteresTasaEfectiva(decimal I, decimal S, decimal P, decimal n)
        {
            double resultado = 0;

            if (I > 0)
            {
                resultado = Math.Pow(((Convert.ToDouble(I) / Convert.ToDouble(P)) + 1), (1 / Convert.ToDouble(n))) - 1;
            }
            else
            {
                resultado = Math.Pow((Convert.ToDouble(S) / Convert.ToDouble(P)), (1 / Convert.ToDouble(n))) - 1;
            }

            resultado = resultado * 100;

            return resultado.ToString("n2");
        }

        /// <summary>
        /// Calcula el valor de la tasa de interes con una tasa nomial
        /// </summary>
        /// <param name="I">Interes acumulado</param>
        /// <param name="S">Monto</param>
        /// <param name="P">Valor Actual</param>
        /// <param name="n">Periodo de tiempo</param>
        /// <param name="m">Numero de capitalizaciones</param>
        /// <returns></returns>
        public String CalcularTasaInteresTasaNominal(decimal I, decimal S, decimal P, decimal n, decimal m)
        {
            double resultado = 0;

            if (I > 0)
            {
                resultado = Convert.ToDouble(m) * (Math.Pow(((Convert.ToDouble(I) / Convert.ToDouble(P)) + 1), (1 / (Convert.ToDouble(m) * Convert.ToDouble(n)))) - 1);
            }
            else
            {
                resultado = Convert.ToDouble(m) * (Math.Pow((Convert.ToDouble(S) / Convert.ToDouble(P)), (1 / (Convert.ToDouble(m) * Convert.ToDouble(n)))) - 1);
            }

            resultado = resultado * 100;

            return resultado.ToString("n2");
        }

        /// <summary>
        /// Calcula el valor del período de tiempo para una tasa de interes efectiva
        /// </summary>
        /// <param name="I">Interes acumulado</param>
        /// <param name="S">Monto</param>
        /// <param name="P">Valor actual</param>
        /// <param name="i">Tasa de interes</param>
        /// <param name="metodo">Metodo para calculo de fecha</param>
        /// <returns></returns>
        public String CalcularPeriodoTiempoTasaEfectiva(decimal I, decimal S, decimal P, decimal i, int metodo)
        {
            double resultado = 0;

            if (I > 0)
            {
                resultado = Math.Log((Convert.ToDouble(I) / Convert.ToDouble(P)) + 1) / Math.Log(1 + Convert.ToDouble(i));
            }
            else
            {
                resultado = Math.Log(Convert.ToDouble(S) / Convert.ToDouble(P)) / Math.Log(1 + Convert.ToDouble(i));
            }

            return dataHelper.ConvertirPeriodoEnAños(Convert.ToDecimal(resultado), metodo);
        }

        /// <summary>
        /// Calcula el valor del período de tiempo para una tasa de interes nominal
        /// </summary>
        /// <param name="I">Interes acumulado</param>
        /// <param name="S">Monto</param>
        /// <param name="P">Valor actual</param>
        /// <param name="i">Tasa de interes</param>
        /// <param name="m">Numero de capitalizaciones</param>
        /// <param name="metodo">Metodo para calculo de fecha</param>
        /// <returns></returns>
        public String CalcularPeriodoTiempoTasaNominal(decimal I, decimal S, decimal P, decimal i, decimal m, int metodo)
        {
            double resultado = 0;

            if (I > 0)
            {
                resultado = Math.Log((Convert.ToDouble(I) / Convert.ToDouble(P)) + 1) / (Convert.ToDouble(m) * Math.Log(1 + (Convert.ToDouble(i) / Convert.ToDouble(m))));
            }
            else
            {
                resultado = Math.Log(Convert.ToDouble(S) / Convert.ToDouble(P)) / (Convert.ToDouble(m) * Math.Log(1 + (Convert.ToDouble(i) / Convert.ToDouble(m))));
            }

            return dataHelper.ConvertirPeriodoEnAños(Convert.ToDecimal(resultado), metodo);
        }

    }
}
