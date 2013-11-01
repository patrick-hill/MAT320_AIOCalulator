using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NumericalCalculator.CalcObjects;

namespace NumericalCalculator.Methods
{
    class GaussElimination : BaseMethod
    {
        public double[,] m;

        public GaussElimination(double[,] m)
        {
            this.m = m;
        }

        public void Solve2()
        {
            int i, j, k, n = m.GetLength(0);

            double[,] a = m;

            for (k = 0; k < n; k++)
            {
                for (i = 0; i < n; i++)
                {
                    if (i != k)
                    {
                        for (j = k + 1; j < n + 1; j++)
                        {
                            a[i, j] = a[i, j] - (a[i, k] / a[k, k]) * a[k, j];
                        }
                    }
                }
            }
            for (i = 0; i < n; i++)
            {
                a[i, n] = a[i, n] / a[i, i];
            }
            string lines = "";
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n + 1; j++)
                {
                    if (i != j && j < n)
                        a[i, j] = 0;
                    lines += Math.Round(a[i, j],3) + "\t";
                }
                lines += ("\r\n");
            }
            addToLog(lines + "\r\n");

            for (i = 0; i < n; i++)
            {
                addToLog("x[" + i + "]= " + Math.Round(a[i,n]));
            }
        }
    }
}