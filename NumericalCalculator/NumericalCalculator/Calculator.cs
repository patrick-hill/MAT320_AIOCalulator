using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCalc;
using System.Collections;
using System.Diagnostics;
using NumericalCalculator.Methods;

namespace NumericalCalculator
{
    class Calculator
    {
        String log = "";
        private MAT320_AIO_Calulator gui;

        public Calculator(MAT320_AIO_Calulator gui)
        {
            this.gui = gui;
        }
        
        public void Calculate(String method, String function, String functionDer, String range, String _tolerance)
        {
            // Parse Inputs
            /// Add Power & Exp checks here ///
            Expression exp = new Expression(function);
            Expression expDer = null;
            if(functionDer != null || functionDer != "")
                expDer = new Expression(functionDer);

            String[] ranges = range.Split(',');
            double a = double.Parse(ranges[0]);
            double b = double.Parse(ranges[1]);
            double tolerance = double.Parse(_tolerance);

            // Find & run method
            switch (method)
            {
                case "Bisection":
                    Bisection bis = new Bisection();
                    bis.Evaluate(exp, a, b, tolerance);
                    setLog(bis.log);
                    break;
                case "Regula functionAlsi":
                    RegulafunctionAlsi rf = new RegulafunctionAlsi();
                    rf.Evaluate(exp, a, b, tolerance);
                    setLog(rf.log);
                    break;
                case "Newtons Method":
                    Newton nt = new Newton();
                    nt.Evaluate(exp, expDer, a, b, tolerance);
                    setLog(nt.log);
                    break;
            }
        }


        void setLog(String log)
        {
            gui.outputTextBox.Text = log;
        }

        //public void NeutonsMethod(String function, String derivative, String range, String _tolerance)
        //{
        //    log = "Calculator started." + "\r\n";
        //    Debug.WriteLine(_tolerance);
        //    Expression exp = new Expression(function);
        //    Expression derExp = new Expression(derivative);
        //    String[] ranges = range.Split(',');
        //    double a = double.Parse(ranges[0]);
        //    double b = double.Parse(ranges[1]);
        //    double tolerance = double.Parse(_tolerance);
        //    double current = a;
        //    double previous = 0;

        //    while (true)
        //    {
        //        current = NeutonsEquation(exp, derExp, current);
        //        if (Math.Max(current, previous) - Math.Min(current, previous) < tolerance)
        //            break;
        //        previous = current;
        //        Debug.WriteLine("hit");
        //    }

        //    setLog(log);
        //}

        //public double NeutonsEquation(Expression exp, Expression derExp, double x)
        //{
        //    exp.Parameters["x"] = x;
        //    double expX = double.Parse(exp.Evaluate().ToString());
        //    derExp.Parameters["x"] = x;
        //    double derExpX = double.Parse(derExp.Evaluate().ToString());
        //    double result = (x - ((expX) / (derExpX)));
        //    log += x + " - (" + expX + " / " + derExpX + ")" + " = " + result + "\r\n";
        //    return result;
        //}

        //public void RegulafunctionAlsi(String function, String range, String _tolerance)
        //{
        //    log = "Calculator started." + "\r\n";
        //    Debug.WriteLine(_tolerance);
        //    Expression exp = new Expression(function);
        //    String[] ranges = range.Split(',');
        //    double a = double.Parse(ranges[0]);
        //    double b = double.Parse(ranges[1]);
        //    double tolerance = double.Parse(_tolerance);
        //    double current = 0;
        //    double previous = a;

        //    int xNum = 0;
        //    while (true)
        //    {
        //        current = RegulafunctionAlsiEquation(exp, previous, b, xNum ++);
        //        if (Math.Max(current,previous)-Math.Min(current,previous) < tolerance)
        //            break;
        //        previous = current;
        //        Debug.WriteLine("hit");
        //    }

        //    Debug.WriteLine("Answer: " + current);
        //    log += "Answer: " + current;
        //    setLog(log);
        //}

        //public double RegulafunctionAlsiEquation(Expression exp, double a, double b, int xNum)
        //{
        //    exp.Parameters["e"] = Math.E;
        //    exp.Parameters["x"] = a;
        //    double functionA = double.Parse(exp.Evaluate().ToString());
        //    exp.Parameters["e"] = Math.E;
        //    exp.Parameters["x"] = b;
        //    double functionB = double.Parse(exp.Evaluate().ToString());
        //    double result = ((a * functionB) - (b * functionA)) / (functionB - functionA);
        //    log += "x: " + xNum + " = ((" + a + " * " + functionB + ")" + " - (" + b + " * " + functionA + ")) / (" + functionB + " - " + functionA + ") = " + result + "\r\n";
        //    return result;
        //}

        //public void bisect(String function, String range, String _tolerance)
        //{
        //    setLog(log);
        //    // Rules
        //    // a & b must have opposite signs
        //    // c = (a+b)/2
        //    // f(c) replaces negative f(a) or f(b)
        //    Expression exp = new Expression(function);

        //    String[] ranges = range.Split(',');
        //    double a = double.Parse(ranges[0]);
        //    double b = double.Parse(ranges[1]);
        //    double c = (a + b) / 2;
        //    double tolerance = double.Parse(_tolerance);
        //    double cNew; // for tolerance comparisons

        //    double functionA, fb, fc;
        //    // Calculate F(a,b,c) until tolerance is reached
        //    while (true)
        //    {
        //        // Functions
        //        functionA = evaluate(exp, a);
        //        fb = evaluate(exp, b);
        //        // fc replaces negative functionA/fb function
        //        fc = evaluate(exp, c);

        //        /// This is the spot that is giving me trouble.
        //        /// I tried swapping c with a/b that had the same sign and that didnt work
        //        ///     but neither does swapping it with the opposite sign so im not sure whats
        //        ///     going on here ///
                
        //        /// It has to be one or the other from below.... ///

        //        log += "\r\n\r\n";
        //        log += "F(a): " + functionA.ToString() + "\t" + "F(b): " + fb.ToString() + "\t" + "F(c): " + fc.ToString() + "\r\n";
        //        log += "Before Swap:" + "\t" + "A: " + a + "\t" + "B: " + a + "\t" + "C: " + c + "\r\n";

        //        // Swap C with function of same sign
        //        if (fc < 0 && functionA < 0)
        //            a = c;
        //        else
        //            b = c;

        //        log += "After Swap:" + "\t" + "A: " + a + "\t" + "B: " + a + "\t" + "C: " + c + "\r\n";
        //        // Swap C with function of opposite sign
        //        //if (fc > 0 && functionA < 0)
        //        //    a = c;
        //        //else
        //        //    b = c;
                        
        //        // calc. new c
        //        cNew = (a + b) / 2;

        //        // check tolerance
        //        bool withinTolerance = inTolerance(tolerance, c, cNew);
        //        if (withinTolerance)
        //            break;
        //        c = cNew;
        //    }
        //    // if here, we've found our root :)
        //    log += "FOUND ROOT, FOUND ROOT, FOUND ROOT, FOUND ROOT !!!!!!!!!!!!!" + "\r\n";
        //    setLog(log);
        //}

        //double evaluate(Expression exp, double var)
        //{
        //    exp.Parameters["x"] = var;
        //    Object result = exp.Evaluate();

        //    log += exp.ToString() + "\t" + "x=" + var + "\r\n";
        //    log += "Result: " + result.ToString() + "\r\n";
        //    setLog(log);

        //    return double.Parse(result.ToString());
        //}

        //bool inTolerance(double tolerance, double x, double y)
        //{
        //    bool inTolerance = (Math.Max(x, y) - Math.Min(x, y)) <= tolerance;
        //    log += "Checking tolerance: \t" + "Old: " + x + "\t" + "New: " + y + "\r\n";
        //    log += "InTolerance? " + inTolerance + "\r\n";
        //    setLog(log);
        //    return inTolerance;
        //}
    }
}
