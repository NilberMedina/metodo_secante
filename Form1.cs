using System;
using System.Windows.Forms;
using NCalc;

namespace metodo_secante
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double EvaluarFuncion(string funcion, double x)
        {
            try
            {
                var expression = new Expression(funcion);
                expression.Parameters["x"] = x;
                expression.Parameters["X"] = x;

                // Agregar soporte para la función pow(base, exponente)
                expression.EvaluateFunction += (name, args) =>
                {
                    switch (name.ToLower())
                    {
                        case "pow":
                            if (args.Parameters.Length == 2)
                            {
                                double baseValue = Convert.ToDouble(args.Parameters[0].Evaluate());
                                double exponent = Convert.ToDouble(args.Parameters[1].Evaluate());
                                args.Result = Math.Pow(baseValue, exponent);
                            }
                            else
                            {
                                throw new ArgumentException("La función pow requiere exactamente 2 parámetros: pow(base, exponente)");
                            }
                            break;
                        case "log10":
                            args.Result = Math.Log10(Convert.ToDouble(args.Parameters[0].Evaluate()));
                            break;
                        case "ln":
                            args.Result = Math.Log(Convert.ToDouble(args.Parameters[0].Evaluate()));
                            break;
                    }
                };

                return Convert.ToDouble(expression.Evaluate());
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error al evaluar la función: {ex.Message}");
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que todos los campos estén llenos
                if (string.IsNullOrWhiteSpace(txtFuncion.Text))
                {
                    MessageBox.Show("Por favor, ingrese la función.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFuncion.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtX0.Text))
                {
                    MessageBox.Show("Por favor, ingrese el valor de X0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtX0.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtX1.Text))
                {
                    MessageBox.Show("Por favor, ingrese el valor de X1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtX1.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTolerancia.Text))
                {
                    MessageBox.Show("Por favor, ingrese la tolerancia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTolerancia.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMaxIteraciones.Text))
                {
                    MessageBox.Show("Por favor, ingrese el máximo de iteraciones.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaxIteraciones.Focus();
                    return;
                }

                // Obtener los valores
                string funcion = txtFuncion.Text;
                double x0 = double.Parse(txtX0.Text);
                double x1 = double.Parse(txtX1.Text);
                double tolerancia = double.Parse(txtTolerancia.Text);
                int maxIteraciones = int.Parse(txtMaxIteraciones.Text);

                // Validar que x0 y x1 sean diferentes
                if (Math.Abs(x0 - x1) < 1e-10)
                {
                    MessageBox.Show("X0 y X1 deben ser valores diferentes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que la tolerancia sea positiva
                if (tolerancia <= 0)
                {
                    MessageBox.Show("La tolerancia debe ser un valor positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que las iteraciones sean positivas
                if (maxIteraciones <= 0)
                {
                    MessageBox.Show("El máximo de iteraciones debe ser un número positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Probar que la función se puede evaluar
                try
                {
                    EvaluarFuncion(funcion, x0);
                    EvaluarFuncion(funcion, x1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al evaluar la función: {ex.Message}\n\n" +
                                  "Verifique la sintaxis de la función.\n" +
                                  "Use 'x' como variable y funciones como:\n" +
                                  "• Sin(x), Cos(x), Tan(x), Log(x), Exp(x), Sqrt(x), Abs(x)\n" +
                                  "• pow(base, exponente) - Ejemplo: pow(x, 2) para x²\n" +
                                  "• log10(x), ln(x)\n" +
                                  "• Operadores: +, -, *, /, ^ (potencia)",
                                  "Error en la función", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Aplicar el método de la secante
                string salida = "MÉTODO DE LA SECANTE\n";
                salida += new string('=', 50) + "\n";
                salida += $"Función: f(x) = {funcion}\n";
                salida += $"Valores iniciales: x0 = {x0}, x1 = {x1}\n";
                salida += $"Tolerancia: {tolerancia}\n";
                salida += $"Máximo de iteraciones: {maxIteraciones}\n\n";

                int iter = 0;
                double error = double.MaxValue;
                double x2 = x1;

                salida += "ITERACIONES:\n";
                salida += new string('-', 80) + "\n";
                salida += "Iter\t\tX0\t\tX1\t\tX2\t\tf(X2)\t\tError\n";
                salida += new string('-', 80) + "\n";

                do
                {
                    double fx0 = EvaluarFuncion(funcion, x0);
                    double fx1 = EvaluarFuncion(funcion, x1);

                    // Verificar división por cero
                    if (Math.Abs(fx1 - fx0) < 1e-15)
                    {
                        salida += $"\n*** ADVERTENCIA: División por cero en iteración {iter + 1} ***\n";
                        salida += "f(x1) - f(x0) ≈ 0, no se puede continuar.\n";
                        break;
                    }

                    // Calcular nuevo punto
                    x2 = x1 - fx1 * (x1 - x0) / (fx1 - fx0);
                    double fx2 = EvaluarFuncion(funcion, x2);
                    error = Math.Abs(x2 - x1);

                    // Mostrar iteración
                    salida += $"{iter + 1}\t\t{x0:F6}\t{x1:F6}\t{x2:F6}\t{fx2:F6}\t{error:E3}\n";

                    // Actualizar valores
                    x0 = x1;
                    x1 = x2;
                    iter++;

                    // Verificar condiciones de parada
                    if (error <= tolerancia)
                    {
                        salida += $"\n*** CONVERGENCIA ALCANZADA ***\n";
                        salida += $"Se encontró la raíz con la tolerancia especificada.\n";
                        break;
                    }

                    if (iter >= maxIteraciones)
                    {
                        salida += $"\n*** MÁXIMO DE ITERACIONES ALCANZADO ***\n";
                        salida += $"No se alcanzó la convergencia en {maxIteraciones} iteraciones.\n";
                        break;
                    }

                } while (true);

                // Resultados finales
                salida += new string('=', 50) + "\n";
                salida += "RESULTADOS FINALES:\n";
                salida += new string('=', 50) + "\n";
                salida += $"Raíz aproximada: x = {x2:F10}\n";
                salida += $"f({x2:F10}) = {EvaluarFuncion(funcion, x2):E6}\n";
                salida += $"Error final: {error:E6}\n";
                salida += $"Iteraciones realizadas: {iter}\n";

                if (error <= tolerancia)
                {
                    salida += $"Estado: ✓ CONVERGIÓ\n";
                }
                else
                {
                    salida += $"Estado: ⚠ NO CONVERGIÓ\n";
                }

                txtResultado.Text = salida;
            }
            catch (FormatException)
            {
                MessageBox.Show("Error en el formato de los números. Verifique que todos los valores numéricos estén correctos.",
                              "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}