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
            int i, j, k, m, n = a.GetLength(0); // get rows

            double[] x = new double[10], c = new double[10];
            double[,] b = new double[10, 10], u = new double[10, 10];

            addToLog("Starting System of Equations via Crout's Method");

            for (i = 0; i < n; i++)
                b[i, 0] = a[i, 0];
            for (j = 1; j < n + 1; j++)
                u[0, j] = a[0, j] / b[0, 0];

            for (m = 1; m < n; m++)
            {
                for (i = m; i < n; i++)
                {
                    for (k = 0; k < m; k++)
                    {
                        a[i, m] = a[i, m] - b[i, k] * u[k, m];
                        addToLog("a["+i+","+m+"]=" + a[i,m]);
                    }
                    b[i, m] = a[i, m];
                    addToLog("b[" + i + "," + m + "]=" + b[i, m]);
                }
                for (j = m + 1; j < n + 1; j++)
                {
                    for (k = 0; k < m; k++)
                    {
                        a[m, j] = a[m, j] - b[m, k] * u[k, j];
                        addToLog("a[" + m + "," + j + "]=" + a[m, j]);
                    }
                    u[m, j] = a[m, j] / b[m, m];
                    addToLog("u[" + m + "," + j + "]=" + u[m, j]);
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
            /// Print X
            addToLog("X values are:" + newLine);
            for (i = 0; i < x.Length; i++)
            {
                addToLog("x[" + i + "]=" + x[i]);
            }
        }
    }
}
