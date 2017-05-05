using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Metodos2017 {
    enum TipoEcuacion {
        Polinomio,
        Logaritmo,
        Exponencial
    };

    public partial class Ventana : Form {
        char[] exponentes = {
            '\x2070',   //x^0
            '\xB9',     //x^1
            '\xB2',     //x^2   
            '\xB3',     //x^3
            '\x2074',   //x^4
            '\x2075',   //x^5
            '\x2076',   //x^6
            '\x2077',   //x^7
            '\x2078',   //x^8
            '\x2079',   //x^9
        };

        public Ventana() {
            InitializeComponent();
            chart.Series.Clear();
        }

        private void buttonAjustar_Click(object sender, EventArgs e) {
            double[,] valores, // Arreglo que contiene los valores introducidos
                matrizA, // Arreglo que contiene los valores de la matriz A  
                matrizB, // Arreglo que contiene los valoers de la matriz B
                matrizATranspuesta, // Arreglo que contiene A transpuesta
                matrizAModificada, // Arreglo que contiene los valores de la matriz Amod            
                matrizBModificada; // Arreglo que contiene los valores de la matriz Bmod 

            double[] matrizResultados, // Arreglo que contiene los resultados del ajuste polinomial
                    logaritmoResultados,
                    exponencialResultados,
                    valoresX;

            string resultado = "";

            try {
                valores = sacarValores(textBoxValoresAjuste.Lines);
            } catch (Exception) {
                mostrarError("Favor de introducir los datos correctamente.");
                return;
            }

            try {
                if (short.Parse(textBoxGradoCurva.Text) > valores.GetLength(0) - 1) {
                    mostrarError("El grado máximo para la ecuación es " +
                           (valores.GetLength(0) - 1));
                    return;
                } else if (short.Parse(textBoxGradoCurva.Text) > 9) {
                    mostrarError("El grado máximo del programa es 9");
                    return;
                }
            } catch (Exception) {
                mostrarError("Favor de introducir el grado correctamente.");
                return;
            }

            valoresX = new double[valores.GetLength(0)];
            for (int i = 0; i < valores.GetLength(0); i++) valoresX[i] = valores[i, 0];

            if (valoresX.Length != valoresX.Distinct().Count()) {
                mostrarError("No se permiten valores duplicados en el eje x."); // Hay valores duplicados de x
                return; // Cancelar la función
            }

            // Llenar la matriz A
            matrizA = new double[valores.GetLength(0), short.Parse(textBoxGradoCurva.Text) + 1];
            for (int i = 0; i < matrizA.GetLength(0); i++) {
                for (int j = 0; j < matrizA.GetLength(1); j++) {
                    matrizA[i, j] = Math.Pow(valores[i, 0], j);
                }
            }

            // Llenar la matriz B
            matrizB = new double[valores.GetLength(0), 1];
            for (int i = 0; i < matrizB.GetLength(0); i++) {
                matrizB[i, 0] = valores[i, 1];
            }

            
            matrizATranspuesta = transponer(matrizA);

            matrizAModificada = multiplicarMatriz(matrizATranspuesta, matrizA);
            matrizBModificada = multiplicarMatriz(matrizATranspuesta, matrizB);

            matrizResultados = gaussJordan(matrizAModificada, matrizBModificada);

            for (int i = matrizResultados.Length - 1; i >= 0; i--) {
                if (i != matrizResultados.Length - 1) {
                    resultado += matrizResultados[i] >= 0 ? " + " : " ";
                }
                resultado += String.Format("{0:0.######}", matrizResultados[i]);
                if(i >= 1) {
                    resultado += "x";
                    if (i >= 2) {
                        resultado += exponentes[i];
                    }
                }
            }

            double rCuadrada = calcularRCuadrada(TipoEcuacion.Polinomio, matrizResultados, valores);

            labelPolinomialResult.Text = resultado + string.Format("\nR\xB2: {0:0.######}", rCuadrada);

            logaritmoResultados = calcularLogaritmo(valores);

            rCuadrada = calcularRCuadrada(TipoEcuacion.Logaritmo, logaritmoResultados, valores);

            labelLogarithmicResult.Text = string.Format("{0:0.######} + {1:0.######} ln x\nR\xB2: {2:0.######}", logaritmoResultados[0], logaritmoResultados[1], rCuadrada);

            exponencialResultados = calcularExponencial(valores);

            rCuadrada = calcularRCuadrada(TipoEcuacion.Exponencial, exponencialResultados, valores);

            labelExponencialResultado.Text = string.Format("{0:0.######} * e^({1:0.######}x)\nR\xB2: {2:0.######}", exponencialResultados[0], exponencialResultados[1], rCuadrada);
            
            llenarGrafica(valores, matrizResultados, logaritmoResultados, exponencialResultados);
        }

        private void ponerPuntos() {
            chart.Series.Clear();

            Series puntos = new Series {
                Name = "puntos",
                Color = Color.DarkRed,
                MarkerSize = 10,
                IsVisibleInLegend = false,
                IsXValueIndexed = false,
                ChartType = SeriesChartType.Point
            };

            string[] textoValores = textBoxValoresAjuste.Lines;

            textoValores = textoValores.Where(item => item != "").ToArray();

            double[,] valores = new double[textoValores.Length, 2];

            for (int i = 0; i < textoValores.Length; i++) {
                try {
                    string puntoActual = textoValores[i].Trim();
                    string[] puntoSeparado = puntoActual.Split(',');
                    for (int j = 0; j < 2; j++) {
                        valores[i, j] = double.Parse(puntoSeparado[j]);
                    }
                    puntos.Points.AddXY(valores[i, 0], valores[i, 1]);
                } catch {
                     
                }
                
            }

            chart.Series.Add(puntos);

            chart.Invalidate();
        }

        private void llenarGrafica(double[,] valores, double[] coeficientesPolinomio, double[] coeficientesLogaritmo, double[] coeficientesExponencial) {
            double[] valoresX = new double[valores.GetLength(0)];
            double step;

            for (int i = 0; i < valores.GetLength(0); i++) valoresX[i] = valores[i, 0];

            Array.Sort(valoresX);

            Series puntos = new Series {
                Name = "Puntos",
                Color = Color.DarkRed,
                MarkerSize = 10,
                IsVisibleInLegend = false,
                IsXValueIndexed = false,
                ChartType = SeriesChartType.Point
            };

            Series polimonio = new Series {
                Name = "Polinomio",
                Color = Color.DarkSeaGreen,
                BorderWidth = 3,
                IsVisibleInLegend = true,
                IsXValueIndexed = false,
                ChartType = SeriesChartType.Line
            };

            Series logaritmo = new Series {
                Name = "Logaritmo",
                Color = Color.DarkBlue,
                BorderWidth = 3,
                IsVisibleInLegend = true,
                IsXValueIndexed = false,
                ChartType = SeriesChartType.Line
            };

            Series exponencial = new Series {
                Name = "Exponencial",
                Color = Color.Red,
                BorderWidth = 3,
                IsVisibleInLegend = true,
                IsXValueIndexed = false,
                ChartType = SeriesChartType.Line
            };

            chart.Series.Clear();

            chart.Series.Add(puntos);
            chart.Series.Add(polimonio);
            chart.Series.Add(logaritmo);
            chart.Series.Add(exponencial);

            for (int i = 0; i < valoresX.Length; i++) {
                if(valores[i , 0] > 0)
                    puntos.Points.AddXY(valores[i, 0], valores[i, 1]);
            }

            step = (valoresX[valoresX.Length - 1] - valoresX[0]) / 100;


            for (double i = valoresX[0]; i < valoresX[valoresX.Length - 1]; i+= step) {
                if (i > 0) { 
                    polimonio.Points.AddXY(i, evaluarPolinomio(coeficientesPolinomio, i));
                    logaritmo.Points.AddXY(i, evaluarLogaritmo(coeficientesLogaritmo, i));
                    exponencial.Points.AddXY(i, evaluarExponencial(coeficientesExponencial, i));
                }
            }

            chart.Invalidate();
        }

        private double evaluarPolinomio(double[] coeficientes, double x) {
            double y = 0;
            for (int j = 0; j < coeficientes.Length; j++) {
                y += coeficientes[j] * Math.Pow(x, j);
            }
            return y;
        }

        private double evaluarLogaritmo(double[] coeficientes, double x) {
            return coeficientes[0] + coeficientes[1] * Math.Log(x);
        }

        private double evaluarExponencial(double[] coeficientes, double x) {
            return coeficientes[0] * Math.Exp(coeficientes[1] * x);
        }

        private double calcularRCuadrada(TipoEcuacion tipoEcuacion, double[] coeficientes, double[,] valores) {
            double yPromedio = 0, sumaY = 0, sumaPx = 0, n;

            n = valores.GetLength(0);

            if (tipoEcuacion == TipoEcuacion.Logaritmo) {
                for (int i = 0; i < valores.GetLength(0); i++) {
                    if (valores[i, 0] <= 0) n--;
                }
            }

            for (int i = 0; i < valores.GetLength(0); i++) {
                if (tipoEcuacion != TipoEcuacion.Logaritmo || valores[i,0] > 0) { 
                    yPromedio += valores[i, 1];
                }
            }

            yPromedio /= n;

            for (int i = 0; i < valores.GetLength(0); i++) {
                double px = 0;
                if (tipoEcuacion == TipoEcuacion.Polinomio) { // Evaluar Polinomio
                    px = evaluarPolinomio(coeficientes, valores[i, 0]);
                } else if (tipoEcuacion == TipoEcuacion.Logaritmo) { // Evaluar logaritmo
                    if (valores[i, 0] <= 0) { // Saltear si es menor a 0
                        continue;
                    } else {
                        px = evaluarLogaritmo(coeficientes, valores[i, 0]);
                    }
                } else {
                    px = evaluarExponencial(coeficientes, valores[i, 0]);
                }
                sumaY += Math.Pow(valores[i, 1] - yPromedio, 2);
                sumaPx += Math.Pow(valores[i, 1] - px, 2);
            }

            return (sumaY - sumaPx) / sumaY;
        }

        private double[] gaussJordan(double[,] SEL, double[,] vectorColumna) {
            double[] resultados = new double[SEL.GetLength(0)];
            double[,] ecuaciones;

            // Fusionar SEL y vectorColumna en una sola matriz
            ecuaciones = new double[SEL.GetLength(0), SEL.GetLength(1) + 1];
            for (int i = 0; i < SEL.GetLength(0); i++) {
                for (int j = 0; j < SEL.GetLength(1); j++) {
                    ecuaciones[i, j] = SEL[i, j];
                }
                ecuaciones[i, SEL.GetLength(1)] = vectorColumna[i, 0];
            }

            // Hacer gauss jordan
            for (int i = 0; i < ecuaciones.GetLength(0); i++) {
                double pivot = ecuaciones[i, i];

                for (int j = 0; j < ecuaciones.GetLength(1); j++) {
                    ecuaciones[i, j] /= pivot;
                }

                for (int j = 0; j < ecuaciones.GetLength(0); j++) {
                    if (i != j) { // Saltearse el renglón pivote
                        double constanteMult = -ecuaciones[j, i];
                        for (int k = 0; k < ecuaciones.GetLength(1); k++) {
                            double valor = ecuaciones[j, k],
                                multiplicacion = constanteMult * ecuaciones[i, k];
                            ecuaciones[j, k] = valor + multiplicacion;
                        }
                    }
                }
            }

            for (int i = 0; i < ecuaciones.GetLength(0); i++) resultados[i] = ecuaciones[i, SEL.GetLength(1)];
            return resultados;
        }

        private double[,] sacarValores(string[] textoValores) {
            /*
             *  3,2
             *  5,4
             *  8,10
             *  10,12
             */

            // Eliminar lineas vacías
            textoValores = textoValores.Where(item => item != "").ToArray();

            double[,] valores = new double[textoValores.Length, 2];

            for (int i = 0; i < textoValores.Length; i++) {
                string puntoActual = textoValores[i].Trim();
                string[] puntoSeparado = puntoActual.Split(',');
                /*
                 * 3
                 * 2
                 */
                for (int j = 0; j < 2; j++) {
                    valores[i, j] = double.Parse(puntoSeparado[j]);
                }
            }

            return valores;

        }

        private void mostrarError(string errorMessage) {
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private double[,] transponer(double[,] matrizOriginal) {
            double[,] transpuesta = new double[matrizOriginal.GetLength(1), matrizOriginal.GetLength(0)];
            for (int i = 0; i < matrizOriginal.GetLength(0); i++) {
                for (int j = 0; j < matrizOriginal.GetLength(1); j++) {
                    transpuesta[j, i] = matrizOriginal[i, j];
                }
            }
            return transpuesta;
        }

        private double[,] multiplicarMatriz(double[,] A, double[,] B) {
            double[,] resultado = new double[A.GetLength(0), B.GetLength(1)];

            for (int i = 0; i < A.GetLength(0); i++) {
                for (int j = 0; j < B.GetLength(1); j++) {
                    double suma = 0;
                    for (int k = 0; k < A.GetLength(1); k++) {
                        suma += A[i, k] * B[k, j];
                    }
                    resultado[i, j] = suma;
                }
            }

            return resultado;
        }

        private double[] calcularLogaritmo(double[,] valores) {
            double[] ab = new double[2];
            double n = valores.GetLength(0),
                   ylnxSum = 0,
                   ySum = 0,
                   lnxSum = 0,
                   lnxSqSum = 0;

            for (int i = 0; i < valores.GetLength(0); i++) {
                if (valores[i, 0] <= 0) {
                    n -= 1;
                } else {
                    double lnx = Math.Log(valores[i, 0]);
                    ylnxSum += valores[i, 1] * lnx;
                    ySum += valores[i, 1];
                    lnxSum += lnx;
                    lnxSqSum += Math.Pow(lnx, 2);
                }
            }

            ab[1] = (n * ylnxSum - ySum * lnxSum) / (n * lnxSqSum - lnxSum * lnxSum);
            ab[0] = (ySum - ab[1] * lnxSum) / (n);

            return ab;
        }

        private void textBoxValoresAjuste_KeyPress(object sender, KeyPressEventArgs e) {
            bool isValid = char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar);
            if (!isValid) {
                if (e.KeyChar != '-'
                    && e.KeyChar != '.'
                    && e.KeyChar != ',') {
                    e.Handled = true;
                }
            }
        }

        private double[] calcularExponencial(double[,] valores) {
            double[] ab = new double[2];
            double xSqySum = 0,
                   ylnySum = 0,
                   xySum = 0,
                   xylnySum = 0,
                   ySum = 0;

            for (int i = 0; i < valores.GetLength(0); i++) {
                double x = valores[i, 0],
                    y = valores[i, 1];

                xSqySum += y * Math.Pow(x, 2);
                ylnySum += Math.Log(y) * y;
                xySum += x * y;
                xylnySum += Math.Log(y) * x * y;
                ySum += y;

            }

            ab[0] = Math.Exp((xSqySum * ylnySum - xySum * xylnySum) / (ySum * xSqySum - Math.Pow(xySum, 2)));
            ab[1] = (ySum * xylnySum - xySum * ylnySum) / (ySum * xSqySum - Math.Pow(xySum, 2));

            return ab;
        }

        private void textBoxValoresAjuste_KeyUp(object sender, KeyEventArgs e) {
            ponerPuntos();
        }

        private void p(object sender, EventArgs e) {

        }
    }
}
