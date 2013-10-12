using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCalc;

namespace NumericalCalculator.Methods
{
    public class BaseMethod
    {
        public String log = "";
        public String newLine = "\r\n";
        public String tab = "\t";

        public void addToLog(String s)
        {
            log += s + newLine;
        }

        public double evaluate(Expression exp, double value)
        {
            exp.Parameters["x"] = value;
            Object EvaluatedExpression = exp.Evaluate();
            double result = double.Parse(EvaluatedExpression.ToString());

            addToLog("Evaluating: x=" + RoundToSignificantDigits(value, 4) + tab
                + "Result: " + RoundToSignificantDigits(result, 4));

            return result;
        }

        public bool inTolerance(double tolerance, double x, double y)
        {
            bool inTolerance = (Math.Max(x, y) - Math.Min(x, y)) <= tolerance;
            
            addToLog("Tolerance Check: "
                + tab + RoundToSignificantDigits(Math.Max(x, y), 6)
                + " - "
                + RoundToSignificantDigits(Math.Min(x, y), 6) + " = "
                + RoundToSignificantDigits((Math.Max(x, y) - Math.Min(x, y)), 4) + tab
                + "Tolerance Passed? " + inTolerance.ToString().ToUpper());

            return inTolerance;
        }

        public double RoundToSignificantDigits(double d, int digits)
        {
            if (d == 0)
                return 0;

            double scale = Math.Pow(10, Math.Floor(Math.Log10(Math.Abs(d))) + 1);
            return scale * Math.Round(d / scale, digits);
        }
    }
}
