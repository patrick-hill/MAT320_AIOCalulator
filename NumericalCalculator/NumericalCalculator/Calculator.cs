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
            log += "Calculator Starting..." + "\r\n";
            setLog(log);
            // Rules
            // a & b must have opposite signs
            // c = (a+b)/2
            // f(c) replaces negative f(a) or f(b)
            Expression exp = new Expression(function);

            String[] ranges = range.Split(',');
            float a = float.Parse(ranges[0]);
            float b = float.Parse(ranges[1]);
            float c = (a + b) / 2;
            float tolerance = float.Parse(_tolerance);
            float newC; // for tolerance comparisons

            // Opposing sign check
            //if ((a < 0 && b < 0) || a > 0 && b > 0)
            //{
            //    log += "INVALID INPUT: A & B must have opposing signs !!!";
            //    log += "Stopping current operation";
            //    // set log to outputTextBox
            //    throw new Exception("Invalid ranges");
            //}

            // Calculate F(a,b,c) until tolerance is reached
            while (true)
            {
                a = evaluate(exp, a);
                b = evaluate(exp, b);
                // c replaces negative a/b function
                newC = evaluate(exp, c);
                if (a < b)
                    a = newC;
                else
                    b = newC;
                // check tolerance
                if (inTolerance(tolerance, c, newC))
                    break;
                c = newC;
            }
            // if here, we've found our root :)

            Console.WriteLine("Found Root: " + newC);
        }

        float evaluate(Expression exp, float var)
        {
            exp.Parameters["x"] = var;
            Object result = exp.Evaluate();

            log += exp.ToString() + "\t" + "x=" + var + "\r\n";
            log += "Result: " + result.ToString() + "\r\n";
            setLog(log);

            return float.Parse(result.ToString());
        }

        bool inTolerance(float tolerance, float x, float y)
        {
            log += "Checking tolerance: \t" + "Old: " + x + "\t" + "New: " + y + "\r\n";
            setLog(log);
            return x - y < tolerance || y - x < tolerance;
        }

        void setLog(String log)
        {
            gui.outputTextBox.Text = log;
        }
    }
}
