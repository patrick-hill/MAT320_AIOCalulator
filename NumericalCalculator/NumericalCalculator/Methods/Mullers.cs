using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCalc;

namespace NumericalCalculator.Methods
{
    class Mullers : BaseMethod
    {
        int iteration = 0;

        public void Evaluate(Expression exp, double a, double b, double tolerance)
        {
            addToLog("Starting Muller's Method");
            double[]
                x = new double[200],
                functionX = new double[200],
                d = new double[200],
                g = new double[2],
                h = new double[200],
                c = new double[200];



            x[0] = a;
            x[2] = b;
            // Step 1
            x[1] = (x[0] + x[2]) / 2;

            // Step 2
            functionX[0] = evaluate(exp, x[0]);
            functionX[1] = evaluate(exp, x[1]);
            functionX[2] = evaluate(exp, x[2]);

            // Step 3
            d[0] = x[1] - x[0];
            d[1] = x[2] - x[1];

            // Step 4
            g[0] = (functionX[1] - functionX[0]) / d[0];
            g[1] = (functionX[2] - functionX[1]) / d[1];

            // Step 5
            // Set i = 0

            /// loops this part
            int i = 0;
            while (true)
            {
                if (i >= 200)
                    addToLog("Iteration threshold reached, STOPPING!");
                // Step 6
                h[i] = (g[i+1] - g[i]) / (d[i+1] + d[i]);

                // Step 7
                c[i] = g[i+1] + (d[i+1] * h[i]);

                // Step 8
                // sign of root is same as sign of c
                if(c[i]>0)
                    d[i+1] = (2*functionX[i+1]) / (c[i] + Math.Sqrt( Math.Pow(c[i],2) - (4*functionX[i+2] * h[i]) ) );
                else
                    d[i+1] = (2*functionX[i+1]) / (c[i] - Math.Sqrt( Math.Pow(c[i],2) - (4*functionX[i+2] * h[i]) ) );

                // Step 9
                x[i + 3] = x[i + 2] + d[i + 2];

                // Step 10
                functionX[i + 3] = (functionX[i+3] - functionX[i+2]) / d[i+2];
                g[i+2] = (functionX[i+3] - functionX[i+2]) / d[i+2];

                /// Repeate steps 6 through 10 until tolerance is reached
                // Step 11
                i++;

                bool wthinTolerance = inTolerance(d[i - 1], d[i], tolerance);
                if (wthinTolerance)
                    break;
            }
            
            


        }
    }


}
