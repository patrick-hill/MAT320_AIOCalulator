﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCalc;

namespace NumericalCalculator.Methods
{
    class RegulaFalsiOLD : BaseMethod
    {
        //public void RegulafunctionAlsi(String function, String range, String _tolerance)
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
                //Debug.WriteLine("hit");
            }

            //Debug.WriteLine("Answer: " + current);
            addToLog("Answer: " + current);
            //log += "Answer: " + current;
            //setLog(log);
        }

        public double RegulafunctionAlsiEquation(Expression exp, double a, double b, int xNum)
        {
            exp.Parameters["e"] = Math.E;
            exp.Parameters["x"] = a;
            double functionA = double.Parse(exp.Evaluate().ToString());
            exp.Parameters["e"] = Math.E;
            exp.Parameters["x"] = b;
            double functionB = double.Parse(exp.Evaluate().ToString());
            double result = ((a * functionB) - (b * functionA)) / (functionB - functionA);
            log += "x: " + xNum + " = ((" + a + " * " + functionB + ")" + " - (" + b + " * " + functionA + ")) / (" + functionB + " - " + functionA + ") = " + result + "\r\n";
            return result;
        }
    }
}