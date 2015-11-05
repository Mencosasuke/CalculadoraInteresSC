using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CalculadoraInteresSC.Helper;
using System.Text.RegularExpressions;

namespace CalculadoraInteresSC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Instancia del helper para realizar los calculos del interes simple
        /// </summary>
        InteresSimpleHelper interesSimple = new InteresSimpleHelper();

        /// <summary>
        /// Instancia del helper para realizar los calculos del interes compuesto
        /// </summary>
        InteresCompuestoHelper interesCompuesto = new InteresCompuestoHelper();

        /// <summary>
        /// Valor que identificara el metodo usado para calcular el período de tiempo (ordinario o exacto)
        /// </summary>
        private int metodoCalculo = 0;

        /// <summary>
        /// Valor que identificara la moneda que se desea utilizar
        /// </summary>
        private String moneda = "Q.";

        private decimal P = 0, n = 0, i = 0, I = 0, S = 0, m = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Realiza los calculos correspondientes al interes simple
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalcularIS_Click(object sender, RoutedEventArgs e)
        {
            P = 0;
            n = 0;
            i = 0;
            I = 0;
            S = 0;

            if (ValidarCampoLleno(txtIsP.Text))
            {
                P = decimal.Parse(txtIsP.Text);
            }

            if (ValidarCampoLleno(txtIsn.Text))
            {
                n = decimal.Parse(txtIsn.Text);
            }

            if (ValidarCampoLleno(txtIsi.Text))
            {
                i = decimal.Parse(txtIsi.Text);
            }

            if (ValidarCampoLleno(txtIsI.Text))
            {
                I = decimal.Parse(txtIsI.Text);
            }

            if (ValidarCampoLleno(txtIsS.Text))
            {
                S = decimal.Parse(txtIsS.Text);
            }

            switch (this.cbValorBuscadoIS.SelectedIndex)
            {
                case 0:
                    // Calculo del valor P - Valor Actual
                    if (ValidarValor(i, "Tasa de Interes") && ValidarValor(n, "Período de Tiempo"))
                    {
                        if ((I == 0) && (S == 0))
                        {
                            MessageBox.Show("Cualquiera de los campos Interes Acumulado o Monto deben ser mayor a 0.00");
                        }
                        else
                        {
                            if (I > 0)
                            {
                                MessageBox.Show(moneda + interesSimple.CalcularValorActualEnFuncionDeI(I, i, n) + ".00");
                            }
                            else
                            {
                                MessageBox.Show(moneda + interesSimple.CalcularValorActualEnFuncionDeS(S, n, i) + ".00");
                            }
                        }
                    }
                    break;
                case 1:
                    // Calculo del valor i - Tasa de Interés
                    if (ValidarValor(P, "Valor Actual") && ValidarValor(n, "Período de Tiempo"))
                    {
                        if ((I == 0) && (S == 0))
                        {
                            MessageBox.Show("Cualquiera de los campos Interes Acumulado o Monto deben ser mayor a 0.00");
                        }
                        else
                        {
                            if (I > 0)
                            {
                                MessageBox.Show(interesSimple.CalcularTasaInteresEnFuncionDeI(I, P, n) + "%");
                            }
                            else
                            {
                                MessageBox.Show(interesSimple.CalcularTasaInteresEnFuncionDeS(S, P, n) + "%");
                            }
                        }
                    }
                    break;
                case 2:
                    // Calculo del valor n - Período de Tiempo
                    if (ValidarValor(P, "Valor Actual") && ValidarValor(i, "Tasa de Interes"))
                    {
                        if ((I == 0) && (S == 0))
                        {
                            MessageBox.Show("Cualquiera de los campos Interes Acumulado o Monto deben ser mayor a 0.00");
                        }
                        else
                        {
                            if (I > 0)
                            {
                                MessageBox.Show(interesSimple.CalcularPeriodoEnFuncionDeI(I, P, i, metodoCalculo));
                            }
                            else
                            {
                                MessageBox.Show(interesSimple.CalcularPeriodoEnFuncionDeS(S, P, i, metodoCalculo));
                            }
                        }
                    }
                    break;
                case 3:
                    // Calculo del valor I - Interes
                    if (ValidarValor(P, "Valor Actual") && ValidarValor(i, "Tasa de Interes") && ValidarValor(n, "Período de Tiempo"))
                    {
                        MessageBox.Show(moneda + interesSimple.CalcularInteres(P, i, n) + ".00");
                    }
                    break;
                case 4:
                    // Calculo de valor S - Monto
                    if (ValidarValor(P, "Valor Actual") && ValidarValor(i, "Tasa de Interes") && ValidarValor(n, "Período de Tiempo"))
                    {
                        MessageBox.Show(moneda + interesSimple.CalcularMonto(P, n, i) + ".00");
                    }
                    break;
            }
        }

        /// <summary>
        /// Realiza los calculos correspondientes al interes compuesto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalcularIC_Click(object sender, RoutedEventArgs e)
        {
            P = 0;
            n = 0;
            i = 0;
            I = 0;
            S = 0;
            m = 0;

            if (ValidarCampoLleno(txtIcP.Text))
            {
                P = decimal.Parse(txtIcP.Text);
            }

            if (ValidarCampoLleno(txtIcn.Text))
            {
                n = decimal.Parse(txtIcn.Text);
            }

            if (ValidarCampoLleno(txtIci.Text))
            {
                i = decimal.Parse(txtIci.Text);
            }

            if (ValidarCampoLleno(txtIcI.Text))
            {
                I = decimal.Parse(txtIcI.Text);
            }

            if (ValidarCampoLleno(txtIcS.Text))
            {
                S = decimal.Parse(txtIcS.Text);
            }

            if (ValidarCampoLleno(txtIcm.Text))
            {
                m = decimal.Parse(txtIcm.Text);
            }

            switch (this.cbValorBuscadoIC.SelectedIndex)
            {
                case 0:
                    // Calculo del valor P - Valor Actual
                    if (ValidarValor(i, "Tasa de Interes") && ValidarValor(n, "Período de Tiempo"))
                    {
                        if ((I == 0) && (S == 0))
                        {
                            MessageBox.Show("Cualquiera de los campos Interes Acumulado o Monto deben ser mayor a 0.00");
                        }
                        else
                        {
                            if (m > 1)
                            {
                                if (ValidarValor(m, "Número de Capitalizaciones"))
                                {
                                    MessageBox.Show(moneda + interesCompuesto.CalcularValorActualTasaNominal(I, S, i, n, m) + ".00");
                                }
                            }
                            else
                            {
                                MessageBox.Show(moneda + interesCompuesto.CalcularValorActualTasaEfectiva(I, S, i, n) + ".00");
                            }
                        }
                    }
                    break;
                case 1:
                    // Calculo del valor i - Tasa de Interés
                    if (ValidarValor(P, "Valor Actual") && ValidarValor(n, "Período de Tiempo"))
                    {
                        if ((I == 0) && (S == 0))
                        {
                            MessageBox.Show("Cualquiera de los campos Interes Acumulado o Monto deben ser mayor a 0.00");
                        }
                        else
                        {
                            if (m > 1)
                            {
                                if (ValidarValor(m, "Número de Capitalizaciones"))
                                {
                                    MessageBox.Show(interesCompuesto.CalcularTasaInteresTasaNominal(I, S, P, n, m) + "%");
                                }
                            }
                            else
                            {
                                MessageBox.Show(interesCompuesto.CalcularTasaInteresTasaEfectiva(I, S, P, n) + "%");
                            }
                        }
                    }
                    break;
                case 2:
                    // Calculo del valor n - Período de Tiempo
                    if (ValidarValor(P, "Valor Actual") && ValidarValor(i, "Tasa de Interes"))
                    {
                        if ((I == 0) && (S == 0))
                        {
                            MessageBox.Show("Cualquiera de los campos Interes Acumulado o Monto deben ser mayor a 0.00");
                        }
                        else
                        {
                            if (m > 1)
                            {
                                if (ValidarValor(m, "Número de Capitalizaciones"))
                                {
                                    MessageBox.Show(interesCompuesto.CalcularPeriodoTiempoTasaNominal(I, S, P, i, m, metodoCalculo));
                                }
                            }
                            else
                            {
                                MessageBox.Show(interesCompuesto.CalcularPeriodoTiempoTasaEfectiva(I, S, P, i, metodoCalculo));
                            }
                        }
                    }
                    break;
                case 3:
                    // Calculo del valor I - Interes
                    if (ValidarValor(P, "Valor Actual") && ValidarValor(i, "Tasa de Interes") && ValidarValor(n, "Período de Tiempo"))
                    {
                        if (m > 1)
                        {
                            if (ValidarValor(m, "Número de Capitalizaciones"))
                            {
                                MessageBox.Show(moneda + interesCompuesto.CalcularInteresTasaNominal(P, i, n, m) + ".00");
                            }
                        }
                        else
                        {
                            MessageBox.Show(moneda + interesCompuesto.CalcularInteresTasaEfectiva(P, i, n) + ".00");
                        }

                    }
                    break;
                case 4:
                    // Calculo de valor S - Monto
                    if (ValidarValor(P, "Valor Actual") && ValidarValor(i, "Tasa de Interes") && ValidarValor(n, "Período de Tiempo"))
                    {
                        if (m > 1)
                        {
                            if (ValidarValor(m, "Número de Capitalizaciones"))
                            {
                                MessageBox.Show(moneda + interesCompuesto.CalcularMontoTasaNominal(P, i, n, m) + ".00");
                            }
                        }
                        else
                        {
                            MessageBox.Show(moneda + interesCompuesto.CalcularMontoTasaEfectiva(P, i, n) + ".00");
                        }
                    }
                    break;
            }

        }

        /// <summary>
        /// Valida si la cadena proporcionada no está vacía
        /// </summary>
        /// <param name="cadena">Cadena a validar</param>
        /// <returns></returns>
        public bool ValidarCampoLleno(String cadena)
        {
            return (cadena.Trim().Length > 0);
        }

        /// <summary>
        /// Valida si el valor ingresado es mayor a 0, de lo contrario, notifica al usuario y detiene el calculo del valor buscado
        /// </summary>
        /// <param name="valor">Valor que se quiere validar</param>
        /// <param name="mensaje">Elemento que se está validando</param>
        /// <returns></returns>
        public bool ValidarValor(decimal valor, String mensaje)
        {
            if(valor > 0)
            {
                return true;
            }

            MessageBox.Show(String.Format("El campo {0} debe ser mayor a 0.00", mensaje));

            return false;
        }

        /// <summary>
        /// Valida que los datos ingresados a los textbox sean solo números.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// Limpia los textbox correspondientes al tab de interes simple
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiarCamposIS_Click(object sender, RoutedEventArgs e)
        {
            txtIsP.Text = String.Empty;
            txtIsi.Text = String.Empty;
            txtIsn.Text = String.Empty;
            txtIsI.Text = String.Empty;
            txtIsS.Text = String.Empty;
        }

        /// <summary>
        /// Limpia los textbox correspondientes al tab de interes compuesto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiarCamposIC_Click(object sender, RoutedEventArgs e)
        {
            txtIcP.Text = String.Empty;
            txtIci.Text = String.Empty;
            txtIcn.Text = String.Empty;
            txtIcI.Text = String.Empty;
            txtIcS.Text = String.Empty;
            txtIcm.Text = String.Empty;
        }

        /// <summary>
        /// Cambia el valor de la moneda según la opción seleccionada en el combobox correspondiente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbMoneda_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbMoneda.SelectedIndex)
            {
                case 0:
                    moneda = "Q.";
                    break;
                case 1:
                    moneda = "$.";
                    break;
                case 2:
                    moneda = "€.";
                    break;
            }
        }

        /// <summary>
        /// Cambia el método de calculo del tiempo (ordinario o exacto) según la opción seleccionada en el combobox correspondiente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbMetodo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            metodoCalculo = cbMetodo.SelectedIndex;
        }
    }
}
