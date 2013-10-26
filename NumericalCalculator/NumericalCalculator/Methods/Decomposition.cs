using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumericalCalculator.Methods
{
    class Decomposition : BaseMethod
    {
        public void solve(double[,] ma, double[,] RHS)
        {
            int size = ma.GetLength(0);
            // RHS is really a single column
            double[,] a = ma;
            double[,] l = new double[10, 10], u = new double[10, 10];
            double[] y = new double[10], b = new double[10], x = new double[10];
            int k = 0, i = 0, jk = 0;

            for (i = 0; i < 10; i++)
                for (k = 0; k < 10; k++)
                {
                    u[k, i] = 0;
                    l[k, i] = 0;
                    if(i<a.GetLength(0) && k<a.GetLength(1))
                        a[k, i] = 0;
                }
            k = 0;
            for (i = 0; i < RHS.Length; i++)
            {
                b[k] = RHS[0,i];
            }
            i = 0;
            for (i = 0; i < size; i++)
            {
                u[0, i] = a[0, i];
                l[i, i] = 1;
            }
            k = 0;
            for (k = 1; k < size; k++)
            {
                l[k, 1] = a[k, 1] / u[0, 0];
            }
            jk = 1;
            for (i = k; i < size; i++)
            {
                u[jk, i] = a[jk, i] - l[i - 1, jk] * u[jk - 1, i];
            }

            for (i = k + 1; i < size; i++)
            {
                l[i, jk] = (a[i, jk] - l[i, jk - 1] * u[jk - 1, i]) / u[jk, jk];
            }
            jk = 2;
            for (i = k; i < size; i++)
            {
                u[jk, i] = a[jk, i] - l[i - 1, jk] * u[jk - 1, i] - l[i - 2, jk] * u[jk - 2, i];
            }
            for (i = k + 1; i < size; i++)
            {
                l[i, jk] = (a[i, jk] - l[i, jk - 1] * u[jk - 1, i] - l[i, jk - 2] * u[jk - 2, i]) / u[jk, jk];
            }
            jk = 3;
            for (i = k; i < size; i++)
            {
                u[jk, i] = a[jk, i] - l[i - 1, jk] * u[jk - 1, i] - l[i - 2, jk] * u[jk - 2, i] - l[i - 3, jk] * u[jk - 3, i];
            }
            // turned the hard coded section below into a dynamic system
            for (i = 0; i < y.Length; i++)
            {
                if (i == 0) y[i] = b[i];
                if (i == 1) y[i] = b[i] - l[i, 0] * y[0];
                if (i == 2) y[i] = b[i] - l[i, 0] * y[0] - l[i, i - 1] * y[i - 1];
                if (i == 3) y[i] = b[i] - y[0] - l[i, 1] * y[1] - l[i,2] * y[2];
            }
            // calculate x's
            for (i = y.Length-1; i > -1; i--)
            {
                if (i == 3) x[i] = y[i] / u[i, i];
                if (i == 2) x[i] = (y[2] - u[2, 3] * x[3]) / u[2, 2];
                if (i == 1) x[i] = (y[i] - u[i, 3] * x[3] - u[i, 2] * x[2]) / u[i, i];
                if (i == 0) x[i] = (y[i] - u[i, 3] * x[3] - u[i, 2] * x[2] - u[i, 1] * x[1]) / u[i, i];
            }
            //y[0] = b[0];
            //y[1] = (b[1] - l[1, 0] * y[0]);
            //y[2] = (b[2] - l[2, 0] * y[0] - l[2, 1] * y[1]);
            //y[3] = b[3] - l[3, 0] * y[0] - l[3, 1] * y[1] - l[3, 2] * y[2];
            //x[3] = y[3] / u[3, 3];
            //x[2] = (y[2] - u[2, 3] * x[3]) / u[2, 2];
            //x[1] = (y[1] - u[1, 3] * x[3] - u[1, 2] * x[2]) / u[1, 1];
            //x[0] = (y[0] - u[0, 3] * x[3] - u[0, 2] * x[2] - u[0, 1] * x[1]) / u[0, 0];
            addToLog(newLine + "L Matrix is:" + newLine);
            for (i = 0; i < size; i++)
            {
                for (k = 0; k < size; k++)
                {
                    addToLog(l[i, k] + tab);
                }
            }
            addToLog(newLine + "U Matrix is:" + newLine);

            for (i = 0; i < size; i++)
            {
                for (k = 0; k < size; k++)
                {
                    addToLog(u[i, k] + tab);
                }
            }
            for (i = 0; i < size; i++)
            {
                addToLog("The vale of x sub " + i + " is: " + b[i]);
                //Printf(“ The value of x sub “ number “ is “ number) i, xl[i];
            }
        }
    }
}
