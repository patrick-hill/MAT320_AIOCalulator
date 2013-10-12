using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCalc;

namespace NumericalCalculator.Methods
{
    class RegulaFalsi_aw : BaseMethod
    {
        public void Evaluate(Expression exp, double a, double b, double tolerance)
        {
            addToLog("Starting Regula Falsi Method");
            double current = 0;
            double previous = a;
            int xNum = 0;

            while (true)
            {
                current = RegulafunctionAlsiEquation(exp, previous, b, xNum++);
                if (Math.Max(current, previous) - Math.Min(current, previous) < tolerance)
                    break;
                previous = current;
            }
            addToLog("Answer: " + current);
        }

        public double RegulafunctionAlsiEquation(Expression exp, double a, double b, int xNum)
        {
            //exp.Parameters["x"] = a;
            //double functionA = exp.Evaluate();
            double functionA = evaluate(exp, a);
            //exp.Parameters["x"] = b;
            //double functionB = double.Parse(exp.Evaluate().ToString());
            double functionB = evaluate(exp, b);
            double result = ((a * functionB) - (b * functionA)) / (functionB - functionA);
            log += "x: " + xNum + " = ((" + a + " * " + functionB + ")" + " - (" + b + " * " + functionA + ")) / (" + functionB + " - " + functionA + ") = " + result + "\r\n";
            return result;
        }
    }
}
