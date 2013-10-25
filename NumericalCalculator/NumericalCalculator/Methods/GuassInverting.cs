using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NumericalCalculator.CalcObjects;

namespace NumericalCalculator.Methods
{
    class GuassInverting : BaseMethod
    {

        public Matrix evaluate(Matrix m)
        {
            int i, j, k, n = m.GetColumns();
            double[,] a = new double[10, 10];

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    a[i, j] = m.getMatrix()[i, j];
                }
            }

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    if (i == j)
                        a[i, n + j] = 1;
                    else
                        a[i, n + j] = 0;
                }
            }

            for (k = 0; k < n; k++)
            {
                for (i = 0; i < n; i++)
                {
                    if (i != k)
                    {
                        for (j = k + 1; j < 2 * n; j++)
                        {
                            a[i, j] = a[i, j] - (a[i, k] / a[k, k]) * a[k, j];
                            printStep(a, n);
                        }
                    }
                }
            }

            for (i = 0; i < n; i++)
            {
                if (a[i, i] == 0)
                {
                    addToLog("inverse doesn't exist");
                    break;
                }
            }

            printStep(a, n);
            return createMatrix(a,n);
        }

        private void printStep(double[,] a, int n)
        {
            double[,] copy = new double[a.GetLength(0), a.GetLength(1)];
            Array.Copy(a, copy, a.Length);
            string result = "--------------------------\r\n";
            for (int i = 0; i < n; i++)
            {
                for (int j = n; j < 2 * n; j++)
                {
                    copy[i, j] = (copy[i, j] / copy[i, i]);
                    result += Math.Round(copy[i, j], 3) + "\t";
                }
                result += "\r\n";
            }
            addToLog(result + "\r\n");
        }

        private Matrix createMatrix(double[,] d, int n)
        {
            Matrix m = new Matrix(n,n);
            for (int i = 0; i < n; i++)
            {
                for (int j = n; j < 2 * n; j++)
                {
                    m.AddCell(i, j/2, d[i, j]);
                }
            }

            return m;
        }
    }
}
