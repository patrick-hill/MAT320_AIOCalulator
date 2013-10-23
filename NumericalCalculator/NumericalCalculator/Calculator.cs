using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCalc;
using System.Collections;
using System.Diagnostics;
using NumericalCalculator.Methods;
using NumericalCalculator.CalcObjects;

namespace NumericalCalculator
{
    class Calculator
    {
        public String log = "";
        private MAT320_AIO_Calulator gui;
        private String[] args;

        public Calculator(MAT320_AIO_Calulator gui)
        {
            this.gui = gui;
        }
        
        //public void Calculate(String method, String function, String functionDer, String range, String _tolerance)
        public void Calculate(int tab, String[] args)
        {
            this.args = args;

            if (tab == 0)
                doMethods();
            else if(tab ==1)
                doMatrix();
        }
        
        public void doMethods()
        {
            String method = args[0];
            String function = args[1];
            String functionDer = args[2];
            String range = args[3];
            String _tolerance = args[4];

            /// Parse out e and exponenets for NCalc
            function = parseSpecialCases(function);
            functionDer = parseSpecialCases(functionDer);

            Expression exp = new Expression(function);
            Expression expDer = null;
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
                case "Regula Falsi":
                    RegulaFalsi rf = new RegulaFalsi();
                    rf.Evaluate(exp, a, b, tolerance);
                    setLog(rf.log);
                    break;
                case "Newtons Method":
                    if (functionDer.Equals(""))
                    {
                        log += "ERROR: DERIVATION NEEDED!" + "\r\n";
                        setLog(log);
                        break;
                    }
                    Newton nt = new Newton();
                    nt.Evaluate(exp, expDer, a, b, tolerance);
                    setLog(nt.log);
                    break;
                case "Mullers Method":
                    Mullers m = new Mullers();
                    m.Evaluate2(exp, a, b, tolerance);
                    setLog(m.log);
                    break;
            }
        }

        public void doMatrix()
        {
            Matrix matrix = processMatrix(args[1]);

            switch (args[0])
            {
                case "Gauss-Jordan Inverting":
                    GuassInverting gi = new GuassInverting();
                    gi.evaluate(matrix);
                    setLog(gi.log);
                    break;
                case "Gauss Elimination (Back Substitution)":
                    GuassElimintationLinearEquationSolver g = new GuassElimintationLinearEquationSolver(matrix.getMatrix());
                    g.Solve();
                    for (int i = 0; i < g.m.GetLength(0); i++)
                    {
                        g.log += "x(i" + i + ") = " + g.m[i, g.m.GetLength(1)-1] + "\r\n";
                        
                    }
                    setLog(g.log);
                    break;
                case "LU Decomposition":
                    SuperMatrix sM = new SuperMatrix(matrix.GetRows(), matrix.GetColumns());
                    SuperMatrix A = SuperMatrix.Parse(args[1]);
                    SuperMatrix PLU = A.GetP() * A.L * A.U;
                    A.log += "\r\n" + "SOLUTION FOUND!!!" + "\r\n" + PLU.ToString();
                    setLog(A.log);
                    break;
            }

            //log += "Matrix Printout" + "\r\n";
            //log += matrix.Print();
            //setLog(log);
        }

        public Matrix processMatrix(String s)
        {
            String[] rows = s.Split('\n');
            String[] column = rows[0].Split(' ');

            double[,] mstr = new double[rows.Length, column.Length];
            Matrix m = new Matrix(rows.Length, column.Length);

            for (int i = 0; i < rows.Length; i++)
            {
                column = rows[i].Split(' ');

                for (int j = 0; j < column.Length; j++)
                {
                    if (!column.Equals("") || !column.Equals("\n") || !column.Equals(null))
                    {
                        m.AddCell(i, j, double.Parse(column[j]));
                        mstr[i, j] = double.Parse(column[j]);
                    }
                }
            }

            return m;
        }

        public String parseSpecialCases(String func)
        {
            if (func == null) return null;

            char[] types = new char[2] { 'e', '^' };

            for (int i = 0; i < types.Length; i++)
            {
                func = FunctionReplacement(types[i], func);
            }
            return func;
        }

        private String FunctionReplacement(char type, String func)
        {
            // Examples:
            // x - e^-x + 0 && x - e^5 + 0
            // 4^-x && x^-2x + 5
            if (func.Contains(type))
            {
                /// Replaces each type occurance with needed format
                while (func.Contains(type))
                {
                    // substring needed sub-function
                    String subFunc = getSubstringFunction(type, func);

                    // get exponent
                    String exponent = getSubFunctionExponent(subFunc);
                    
                    String expBase = "";
                    if(type.Equals('^'))
                        expBase = getSubFunctionExpBase(subFunc);

                    // Build & Substitue new substring
                    String newSubFunc = replaceSubFunction(type, subFunc, exponent, expBase);
                    func = func.Replace(subFunc, newSubFunc);

                    // log
                    log += "Replaced: " + subFunc + "\t" + " with: " + newSubFunc + "\r\n";
                    //setLog(log);
                }
            }
            return func;
        }

        private String getSubstringFunction(char type, String func)
        {
            int startIndex = func.IndexOf(type);
            int endIndex = startIndex;

            // Find start/end indices
            while (startIndex >= 0 && !func[startIndex].Equals(' '))
                startIndex--;
            startIndex++; // moves from space
            while (endIndex < func.Length && !func[endIndex].Equals(' '))
                endIndex++;
            endIndex--; // moves from space
            return func.Substring(startIndex, (endIndex - startIndex) + 1);
        }

        private String getSubFunctionExponent(string func)
        {
            int expIndex = func.IndexOf('^') + 1;
            return func.Substring(expIndex);
        }

        private String getSubFunctionExpBase(string func)
        {
            int expIndex = func.IndexOf('^');
            return func.Substring(0, expIndex);
        }

        private String replaceSubFunction(char type, String function, String exponent, String expBase)
        {
            if (type.Equals('e'))
                function = "Exp(" + exponent + ")";
            else
            {
                function = "Pow(" + expBase + "," + exponent + ")";
            }
            return function;
        }

        void setLog(String log)
        {
            gui.outputTextBox.Text = log;
        }
    }
}
