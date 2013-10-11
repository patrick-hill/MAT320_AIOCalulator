using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCalc;
using System.Collections;
using System.Diagnostics;

namespace NumericalCalculator
{
    class Calculator
    {
        String log = "Calculator started." + "\r\n";
        private MAT320_AIO_Calulator gui;

        public Calculator(MAT320_AIO_Calulator gui)
        {
            this.gui = gui;
        }

        public void RegulaFalsi(String function, String range, String _tolerance)
        {
            log = "Calculator started." + "\r\n";
            Debug.WriteLine(_tolerance);
            Expression exp = new Expression(function);
            String[] ranges = range.Split(',');
            float a = float.Parse(ranges[0]);
            float b = float.Parse(ranges[1]);
            float tolerance = float.Parse(_tolerance);
            float current = 0;
            float previous = a;

            int xNum = 0;
            while (true)
            {
                current = RegulaFalsiEquation(exp, previous, b, xNum ++);
                if (Math.Max(current,previous)-Math.Min(current,previous) < tolerance)
                    break;
                previous = current;
                Debug.WriteLine("hit");
            }

            Debug.WriteLine("Answer: " + current);
            log += "Answer: " + current;
            setLog(log);
        }

        public float RegulaFalsiEquation(Expression exp, float a, float b, int xNum)
        {
            exp.Parameters["x"] = a;
            float functionA = float.Parse(exp.Evaluate().ToString());
            exp.Parameters["x"] = b;
            float functionB = float.Parse(exp.Evaluate().ToString());
            float result = ((a * functionB) - (b * functionA)) / (functionB - functionA);
            log += "x: " + xNum + " = ((" + a + " * " + functionB + ")" + " - (" + b + " * " + functionA + ")) / (" + functionB + " - " + functionA + ") = " + result + "\r\n";
            return result;
        }

        public void bisect(String function, String range, String _tolerance)
        {
            setLog(log);
            // Rules
            // a & b must have opposite signs
            // c = (a+b)/2
            // f(c) replaces negative f(a) or f(b)
            Expression exp = new Expression(function);

            String[] ranges = range.Split(',');
            double a = double.Parse(ranges[0]);
            double b = double.Parse(ranges[1]);
            double c = (a + b) / 2;
            double tolerance = double.Parse(_tolerance);
            double cNew; // for tolerance comparisons

            double fa, fb, fc;
            // Calculate F(a,b,c) until tolerance is reached
            while (true)
            {
                // Functions
                fa = evaluate(exp, a);
                fb = evaluate(exp, b);
                // fc replaces negative fa/fb function
                fc = evaluate(exp, c);
                if (fa < fb)
                    a = c;
                else
                    b = c;
                // calc. new c
                cNew = (a + b) / 2;

                // check tolerance
                if (inTolerance(tolerance, c, newC))
                bool withinTolerance = inTolerance(tolerance, c, cNew);
                if (withinTolerance)
                    break;
                c = cNew;
            }
            // if here, we've found our root :)
            log += "FOUND ROOT, FOUND ROOT, FOUND ROOT, FOUND ROOT !!!!!!!!!!!!!" + "\r\n";
            setLog(log);
        }

        double evaluate(Expression exp, double var)
        {
            exp.Parameters["x"] = var;
            Object result = exp.Evaluate();

            log += "\t" + "x=" + var + "\r\n";
            log += "Result: " + result.ToString() + "\r\n";
            setLog(log);
            
            return double.Parse(result.ToString());
        }

        bool inTolerance(double tolerance, double x, double y)
        {
            bool inTolerance = (Math.Max(x, y) - Math.Min(x, y)) <= tolerance;
            log += "Checking tolerance: \t" + "Old: " + x + "\t" + "New: " + y + "\r\n";
            log += "InTolerance? " + inTolerance + "\r\n";
            setLog(log);
            return inTolerance;
        }

        void setLog(String log)
        {
            gui.outputTextBox.Text = log;
        }
    }
}
