using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCalc;

namespace NumericalCalculator.Methods
{
    class Newton : BaseMethod
    {
        public void Evaluate(Expression exp, Expression derExp, double a, double b, double tolerance)
        {
            addToLog("Starting Newton Method");

            double current = a;
            double previous = 0;

            while (true)
            {
                current = NeutonsEquation(exp, derExp, current);
                if (Math.Max(current, previous) - Math.Min(current, previous) < tolerance)
                    break;
                previous = current;
                //Debug.WriteLine("hit");
            }

            //setLog(log);
        }

        public double NeutonsEquation(Expression exp, Expression derExp, double x)
        {
            exp.Parameters["x"] = x;
            double expX = double.Parse(exp.Evaluate().ToString());
            derExp.Parameters["x"] = x;
            double derExpX = double.Parse(derExp.Evaluate().ToString());
            double result = (x - ((expX) / (derExpX)));
            log += x + " - (" + expX + " / " + derExpX + ")" + " = " + result + "\r\n";
            return result;
        }
    }
}
