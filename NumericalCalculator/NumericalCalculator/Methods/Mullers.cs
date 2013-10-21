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
                h[i] = (g[i + 1] - g[i]) / (d[i + 1] + d[i]);
                addToLog("h" + i + "= " + RoundDigit(h[i], 4));

                // Step 7
                c[i] = g[i + 1] + (d[i + 1] * h[i]);
                addToLog("c" + i + "= " + RoundDigit(c[i], 4));

                // Step 8
                // sign of root is same as sign of c
                if (c[i] > double.MinValue)
                    d[i + 2] = (2 * fx[i + 2]) / (c[i] + (Math.Sqrt(Math.Pow(c[i], 2)) - 4 * fx[i + 2] * h[i]));
                else
                    d[i + 2] = (2 * fx[i + 2]) / (c[i] - (Math.Sqrt(Math.Pow(c[i], 2)) - 4 * fx[i + 2] * h[i]));
                addToLog("d" + (i + 2) + "= " + RoundDigit(d[i + 2], 4));

                // Step 9
                x[i + 3] = x[i + 2] + d[i + 2];
                addToLog("x" + (i + 3) + "= " + RoundDigit(x[i + 3], 4));

                // Step 10
                fx[i + 3] = evaluate(exp, x[i + 3]);
                g[i + 2] = (fx[i + 3] - fx[i + 2]) / d[i + 2];
                addToLog("f" + (i + 3) + "= " + RoundDigit(fx[i + 3], 4) + newLine
                    + "g" + (i + 2) + "= " + RoundDigit(g[i + 2], 4));

                bool withinTolerance = false;
                if (iteration > 0) // first iteration, shit is the same.... wtf
                    withinTolerance = inTolerance(tolerance, d[i + 2], d[i + 1]);
                if (withinTolerance)
                    break;


                /// Repeate steps 6 through 10 until tolerance is reached
                // Step 11
                i++;
            }
            addToLog("ROOT FOUND: " + x[i + 2]);
        }

        public void Evaluate2(Expression exp, double a, double b, double tolerance)
        {
            double x1, x2, x3, x4_1, x4_2, fx1, fx2, fx3,
   h1, h2, h3_1, h3_2, h4, D, d1, d2, a1, a2, a0;
            int i = 1;
            x1 = a;
            x2 = (a + b) / 2;
            x3 = b;
            fx1 = evaluate(exp, x1);
            fx2 = evaluate(exp, x2);
            fx3 = a0 = evaluate(exp, x3);
            h1 = x1 - x3;
            h2 = x2 - x3;

            d1 = fx1 - fx3;
            d2 = fx2 - fx3;

            D = h1 * h2 * (h1 - h2);

            a1 = (d2 * h1 * h1 - d1 * h2 * h2) / D;
            a2 = (d1 * h2 - d2 * h1) / D;

            h3_1 = -((2 * a0) / (a1 + Math.Sqrt(Math.Abs(a1 * a1 - (4 * a2 * a0)))));
            h3_2 = -((2 * a0) / (a1 - Math.Sqrt(Math.Abs(a1 * a1 - (4 * a2 * a0)))));

            if ((a1 + Math.Sqrt(Math.Abs(a1 * a1 - (4 * a2 * a0)))) >
                   ((a1 - Math.Sqrt(Math.Abs(a1 * a1 - (4 * a2 * a0))))))
            {
                h4 = h3_1;
            }
            else
            {
                h4 = h3_2;
            }
            x4_1 = x3 + h4;

            x1 = x2;
            x2 = x3;
            x3 = x4_1;

            do
            {
                fx1 = evaluate(exp, x1);
                fx2 = evaluate(exp, x2);
                fx3 = a0 = evaluate(exp, x3);

                h1 = x1 - x3;
                h2 = x2 - x3;

                d1 = fx1 - fx3;
                d2 = fx2 - fx3;

                D = h1 * h2 * (h1 - h2);

                a1 = (d2 * h1 * h1 - d1 * h2 * h2) / D;
                a2 = (d1 * h2 - d2 * h1) / D;

                h3_1 = -((2 * a0) / (a1 + Math.Sqrt(Math.Abs(a1 * a1 - (4 * a2 * a0)))));
                h3_2 = -((2 * a0) / (a1 - Math.Sqrt(Math.Abs(a1 * a1 - (4 * a2 * a0)))));

                if ((a1 + Math.Sqrt(Math.Abs(a1 * a1 - (4 * a2 * a0)))) >
                      (a1 - Math.Sqrt(Math.Abs(a1 * a1 - (4 * a2 * a0)))))
                {
                    h4 = h3_1;
                }
                else
                {
                    h4 = h3_2;
                }
                x4_2 = x3 + h4;
                if (Math.Abs(x4_1 - x4_2) < tolerance)
                {
                    addToLog("ROOT FOUND: " + x4_2);
                    i = 0;
                }
                else
                {
                    x4_1 = x4_2;
                    x1 = x2;
                    x2 = x3;
                    x3 = x4_1;
                    addToLog("x1 = " + x1);
                    addToLog("x2 = " + x2);
                    addToLog("x3 = " + x3);
                }
            } while (i != 0);
        }
    }


}
