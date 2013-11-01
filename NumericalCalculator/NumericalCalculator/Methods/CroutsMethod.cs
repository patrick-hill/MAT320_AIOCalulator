using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumericalCalculator.Methods
{
    public class CroutsMethod : BaseMethod
    {
        public void solve(double[,] ma)
        {
            double[,] a = ma;
            int rows = a.GetLength(0);
            int columns = a.GetLength(1);
            int i, j, k, m, n = a.GetLength(0); // get rows

            double[] x = new double[10], c = new double[10];
            double[,] b = new double[10, 10], u = new double[10, 10];

            addToLog("Starting System of Equations via Crout's Method");

            for (j = 0; j < n; j++)
                u[0, j] = a[0, j];
            for (i = 0; i < n; i++)
                b[i, 0] = a[i, 0];
            printLU(a, b, u, rows, columns);
            for (j = 1; j < n + 1; j++)
                u[0, j] = a[0, j] / b[0, 0];

            printLU(a, b, u, rows, columns);

            for (m = 1; m < n; m++)
            {
                for (i = m; i < n; i++)
                {
                    for (k = 0; k < m; k++)
                    {
                        a[i, m] = a[i, m] - b[i, k] * u[k, m];
                        //addToLog("a["+i+","+m+"]=" + a[i,m]);
                    }
                    b[i, m] = a[i, m];
                    //addToLog("b[" + i + "," + m + "]=" + b[i, m]);
                }
                for (j = m + 1; j < n + 1; j++)
                {
                    for (k = 0; k < m; k++)
                    {
                        a[m, j] = a[m, j] - b[m, k] * u[k, j];
                        //addToLog("a[" + m + "," + j + "]=" + a[m, j]);
                    }
                    u[m, j] = a[m, j] / b[m, m];
                    //addToLog("u[" + m + "," + j + "]=" + u[m, j]);
                }
            }

            for (k = 0; k < n; k++)
            {
                i = (n - k - 1);
                x[i] = u[i, n];
                for (j = i + 1; j < n; j++)
                {
                    x[i] = x[i] - u[i, j] * x[j];
                    addToLog("x[" + i + "]=" + x[i]);
                }
            }
            printLU(a, b, u, rows, columns);

            /// Print X
            addToLog("X values are:" + newLine);
            for (i = 0; i < n; i++)
            {
                addToLog("x[" + i + "]=" + x[i]);
            }
        }

        public void printMatrix(double[,] x, string name, int rows, int columns)
        {
            string result = "";
            addToLog(name + " Matrix");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result += Math.Round(x[i, j], 3) + "\t";
                }
                result += "\r\n";
            }

            addToLog(result);
        }

        public void printU(double[,] u, int rows, int columns)
        {
            string result = "";
            addToLog("U" + " Matrix");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 1; j < columns + 1; j++)
                {
                    result += Math.Round(u[i, j], 3) + "\t";
                }
                result += "\r\n";
            }

            addToLog(result);
        }

        public void printLU(double[,] a, double[,] l, double[,] u, int rows, int columns)
        {
            printMatrix(a, "A", rows, columns);
            printMatrix(l, "L",rows, columns);
            //printU(u, rows, columns);
            printMatrix(u, "U", rows, columns);
        }
    }
}
