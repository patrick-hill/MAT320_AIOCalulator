using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NumericalCalculator.CalcObjects;

namespace NumericalCalculator.Methods
{
    class PowerMethodEigenValue : BaseMethod
    {
        private double[] x = new double[10];

        public void Evaluate(Matrix m)
        {
            int i, j, k, n = m.GetColumns();
            double[,] a = new double[10, 10];
            double[] y = new double[10];
            double[] z = new double[10];
            double d, Z;

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    a[i, j] = m.getMatrix()[i, j];
                    x[i] = 1;
                }
            }


            k = 0;
            do
            {
                for (i = 0; i < n; i++)
                {
                    y[i] = 0;
                    for (j = 0; j < n; j++)
                    {
                        y[i] = y[i] + a[i, j] * x[j];
                    }
                    z[i] = Math.Abs(y[i]);
                }


                Z = z[0];
                j = 0;
                for (i = 1; i < n; i++)
                {
                    if (z[i] >= Z)
                    {
                        Z = z[i];
                        j = i;
                    }
                }

                if (Z == y[j])
                    d = Z;
                else
                    d = -Z;

                for (i = 0; i < n; i++)
                {
                    x[i] = y[i] / d;
                }
                addToLog("EigenVector, iteration: " + k + "\r\n");
                printVector(x,n);

                k = k + 1;
            }
            while (k < 50);
            addToLog("Largest Eigen value is: " + d);
        }

        public double[] GetEigenVector()
        {
            return x;
        }

        private void printVector(double[] a,int n)
        {
            string result = "";
            for (int i = 0; i < n; i++)
            {
                result += Math.Round(a[i],4) + "\r\n";
            }
            result += "-----------------------------\r\n";
            addToLog(result);
        }
    }
}
