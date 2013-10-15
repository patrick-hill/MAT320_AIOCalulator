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
            double x0, x1, x2, functionX0, functionX1, functionX2;

            x0 = a;
            x2 = b;
            // Step 1
            x1 = (x0 + x2) / 2;

            // Step 2
            functionX0 = evaluate(exp, x0);
            functionX1 = evaluate(exp, x1);
            functionX2 = evaluate(exp, x2);



        }
    }


}
