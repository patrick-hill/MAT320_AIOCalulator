using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NumericalCalculator.CalcObjects;

namespace NumericalCalculator.Methods
{
    class Decomposition : BaseMethod
    {
        double[,] matrix;

        public Decomposition(double[,] m)
        {
            this.matrix = m;
        }

        public void solve()
        {
            double[,] a = matrix,
                l = new double[10, 10],
                u = new double[10, 10];
            double[] y = new double[10], b = new double[10], x = new double[10];

            int ns = a.GetLength(0), k = 0, i = 0, jk = 0;

            // these are the RHS values
            for (k = 0; k < ns; k++)
            {
                b[k] = a[k, ns];
            }

            //sets up first row of u  AND  diagonal 1's in L
            for (i = 0; i < ns; i++)
            {
                u[0, i] = a[0, i];
                l[i, i] = 1;
            }

            // first column of l (ell)
            for (k = 1; k < ns; k++)
            {
                l[k, 0] = a[k, 0] / u[0, 0];  //changed from original
            }


            jk = 1;  //jk is a row incrementer
            //second row u
            for (i = jk; i < ns; i++)    //changed to jk as per original
            {
                u[jk, i] = a[jk, i] - l[jk, jk - 1] * u[jk - 1, i];
            }

            //second column l (ell)
            for (i = 2; i < ns; i++)
            {
                l[i, jk] = (a[i, jk] - l[i, jk - 1] * u[jk - 1, jk]) / u[jk, jk];
            }



            jk = 2;
            for (i = 2; i < ns; i++)
            {
                u[jk, i] = a[jk, i] - l[jk, 0] * u[0, i] - l[2, 1] * u[1, i];
            }



            // last l (ell)
            for (i = 3; i < ns; i++)
            {
                l[i, jk] = (a[i, jk] - l[i, jk - 2] * u[0, i - 1] - l[i, jk - 1] * u[jk - 1, i - 1]) / u[jk, jk];
            }


            //last u
            jk = 3;
            for (i = 3; i < ns; i++)
            {
                u[jk, i] = a[jk, i] - l[jk, 0] * u[0, jk] - l[jk, 1] * u[jk - 2, i] - l[jk, i - 1] * u[jk - 1, i];
            }



            y[0] = b[0];
            y[1] = (b[1] - l[1, 0] * y[0]);
            y[2] = (b[2] - l[2, 0] * y[0] - l[2, 1] * y[1]);

            y[3] = b[3] - l[3, 0] * y[0] - l[3, 1] * y[1] - l[3, 2] * y[2];

            if (ns > 3)
            {
                x[3] = y[3] / u[3, 3];
                x[2] = (y[2] - u[2, 3] * x[3]) / u[2, 2];
                x[1] = (y[1] - u[1, 3] * x[3] - u[1, 2] * x[2]) / u[1, 1];
                x[0] = (y[0] - u[0, 3] * x[3] - u[0, 2] * x[2] - u[0, 1] * x[1]) / u[0, 0];
            }
            else
            {
                x[2] = y[2] / u[2, 2];
                x[1] = (y[1] - u[1, 2] * x[2]) / u[1, 1];
                x[0] = (y[0] - u[0, 2] * x[2] - u[0, 1] * x[1]) / u[0, 0];
            }

            string matrixRow = "";

            //Original Matrix
            for (i = 0; i < ns; i++)
            {
                for (k = 0; k < ns; k++)
                {
                    matrixRow += a[i, k] + "\t";
                }
                matrixRow += "\t\t" + b[i] + "\r\n";
            }
            addToLog("Original Matrix");
            addToLog(matrixRow);
            matrixRow = "";

            //Final L Matrix
            for (i = 0; i < ns; i++)
            {
                for (k = 0; k < ns; k++)
                {
                    matrixRow += l[i, k] + "\t";
                }
                matrixRow += "\r\n";
            }
            addToLog("Final L Matrix");
            addToLog(matrixRow);
            matrixRow = "";

            //Final U Matrix
            for (i = 0; i < ns; i++)
            {
                for (k = 0; k < ns; k++)
                {
                    matrixRow += u[i, k] + "\t";
                }
                matrixRow += "\r\n";
            }
            addToLog("Final U Matrix");
            addToLog(matrixRow);
            matrixRow = "";

            for (i = 0; i < ns; i++)
            {
                addToLog("x" + i + " = " + x[i]);
            }

        }

    }
}
