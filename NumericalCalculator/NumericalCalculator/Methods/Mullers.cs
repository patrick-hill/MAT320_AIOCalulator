using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCalc;

namespace NumericalCalculator.Methods
{
    class Mullers : BaseMethod
    {
        const int MAX_ITERATION_SIZE = 210;
        int iteration = 0;

        public void Evaluate(Expression exp, double a, double b, double tolerance)
        {
            addToLog("Starting Muller's Method");
            double[]
                x = new double[MAX_ITERATION_SIZE],
                fx = new double[MAX_ITERATION_SIZE],
                d = new double[MAX_ITERATION_SIZE],
                g = new double[MAX_ITERATION_SIZE],
                h = new double[MAX_ITERATION_SIZE],
                c = new double[MAX_ITERATION_SIZE];
            
            x[0] = a;
            x[2] = b;
            // Step 1
            x[1] = (x[0] + x[2]) / 2;

            // Step 2
            fx[0] = evaluate(exp, x[0]);
            fx[1] = evaluate(exp, x[1]);
            fx[2] = evaluate(exp, x[2]);

            // Step 3
            d[0] = x[1] - x[0];
            d[1] = x[2] - x[1];

            // Step 4
            g[0] = (fx[1] - fx[0]) / d[0];
            g[1] = (fx[2] - fx[1]) / d[1];

            addToLog(newLine + "Step 1-5 Info" + newLine
                + "x0= " + RoundDigit(x[0], 4) + tab + "x1= " + RoundDigit(x[1], 4) + tab + "x2= " + RoundDigit(x[2], 4) + newLine
                + "f0= " + RoundDigit(fx[0], 4) + tab + "f1=" + RoundDigit(fx[1], 4) + tab + "f3= " + RoundDigit(fx[2], 4) + newLine
                + "d0= " + RoundDigit(d[0], 4) + tab + "d1= " + RoundDigit(d[1], 4) + newLine
                + "g0= " + RoundDigit(g[0], 4) + tab + "g1= " + RoundDigit(g[1], 4));

            // Step 5
            // Set i = 0

            /// loop this part
            int i = 0;
            int iteration = 0;
            while (true)
            {
                if (i >= 200)
                {
                    addToLog("Iteration threshold reached, STOPPING!");
                    break;
                }
                iteration++;
                addToLog(newLine + "Iteration " + iteration);

                // Step 6
                h[i] = (g[i+1] - g[i]) / (d[i+1] + d[i]);
                addToLog("h" + i + "= " + RoundDigit(h[i], 4));

                // Step 7
                c[i] = g[i+1] + (d[i+1] * h[i]);
                addToLog("c" + i + "= " + RoundDigit(c[i], 4));

                // Step 8
                // sign of root is same as sign of c
                if (c[i] > double.MinValue)
                {
                    //if (i == 2)
                    //{
                    //    double one = 2 * fx[i + 2];
                    //    double two = c[i];
                    //    double three = Math.Pow(c[i], 2);
                    //    double four = 4 * fx[i + 2] * h[i];
                    //    double five = Math.Sqrt(three) - Math.Sqrt(four);
                    //    double six = one / (two + five);
                    //    addToLog("1= " + one + "2= " + two + "3= " + three + "4= " + four + "5= " + five + "6= " + six);
                    //}
                    d[i + 2] = (2 * fx[i + 2]) / (c[i] + (Math.Sqrt(Math.Pow(c[i], 2)) - Math.Sqrt((4 * fx[i + 2] * h[i]))));
                }
                else
                    d[i + 2] = (2 * fx[i + 2]) / (c[i] - (Math.Sqrt(Math.Pow(c[i], 2)) - Math.Sqrt((4 * fx[i + 2] * h[i]))));
                addToLog("d"+(i+2)+"= " + RoundDigit(d[i+2], 4));

                // Step 9
                x[i + 3] = x[i + 2] + d[i + 2];
                addToLog("x"+(i+3) + "= " + RoundDigit(x[i+3], 4));

                // Step 10
                fx[i + 3] = evaluate(exp, x[i+3]);
                g[i + 2] = (fx[i + 3] - fx[i + 2]) / d[i + 2];
                addToLog("f" + (i + 3) + "= " + RoundDigit(fx[i + 3], 4) + newLine
                    + "g" + (i + 2) + "= " + RoundDigit(g[i + 2], 4));

                bool withinTolerance = false;
                if(iteration > 0) // first iteration, shit is the same.... wtf
                    withinTolerance = inTolerance(tolerance, d[i + 2], d[i + 1]);
                if (withinTolerance)
                    break;


                /// Repeate steps 6 through 10 until tolerance is reached
                // Step 11
                i++;

                
            }
        }
    }


}
