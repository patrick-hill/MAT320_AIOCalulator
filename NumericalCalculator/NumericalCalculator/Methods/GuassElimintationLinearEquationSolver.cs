using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NumericalCalculator.CalcObjects;

namespace NumericalCalculator.Methods
{
    public class GuassElimintationLinearEquationSolver : BaseMethod
    {
        public double[,] m;

        public GuassElimintationLinearEquationSolver(double[,] m)
        {
            this.m = m;
        }

        public bool Solve()
        {
            double[,] M = m;

            addToLog("Starting Gauss Elimination w/ Back Substitution...");
            // input checks
            int rowCount = M.GetUpperBound(0) + 1;
            if (M == null || M.Length != rowCount * (rowCount + 1))
                throw new ArgumentException("The algorithm must be provided with a (n x n+1) matrix.");
            if (rowCount < 1)
                throw new ArgumentException("The matrix must at least have one row.");

            // pivoting
            for (int col = 0; col + 1 < rowCount; col++) if (M[col, col] == 0)
                // check for zero coefficients
                {
                    addToLog("Checking for coefficients of Zero");
                    // find non-zero coefficient
                    int swapRow = col + 1;
                    for (; swapRow < rowCount; swapRow++) if (M[swapRow, col] != 0) break;

                    if (M[swapRow, col] != 0) // found a non-zero coefficient?
                    {
                        // yes, then swap it with the above
                        addToLog("Found coefficient of zero, swapping with previous row...");
                        double[] tmp = new double[rowCount + 1];
                        for (int i = 0; i < rowCount + 1; i++)
                        { tmp[i] = M[swapRow, i]; M[swapRow, i] = M[col, i]; M[col, i] = tmp[i]; }
                    }
                    else
                    {
                        addToLog("NO SOLUTION");
                        return false; // no, then the matrix has no unique solution
                    }
                }
            /// Printout for above
            Matrix pivot = MakeMatrix();
            addToLog("Printout - After row manipulation" + newLine + pivot.Print());

            // elimination
            for (int sourceRow = 0; sourceRow + 1 < rowCount; sourceRow++)
            {
                for (int destRow = sourceRow + 1; destRow < rowCount; destRow++)
                {
                    double df = M[sourceRow, sourceRow];
                    double sf = M[destRow, sourceRow];
                    for (int i = 0; i < rowCount + 1; i++)
                    {
                        M[destRow, i] = M[destRow, i] * df - M[sourceRow, i] * sf;
                        //addToLog("R:" + destRow + " C:" + i + " = " + M[destRow, i] + " * " + df + " -  " + M[sourceRow, i] + " * " + sf);
                    }
                }
            }
            /// Printout for above
            Matrix elimination = MakeMatrix();
            addToLog("Printout - Before row Eliminations" + newLine + elimination.Print());

            // back-insertion
            //Matrix perInsertion = MakeMatrix();
            //addToLog("Printout - Before Back Insertion" + newLine + preElimination.Print());
            for (int row = rowCount - 1; row >= 0; row--)
            {
                double f = M[row, row];
                if (f == 0) return false;

                for (int i = 0; i < rowCount + 1; i++) M[row, i] /= f;
                for (int destRow = 0; destRow < row; destRow++)
                {
                    M[destRow, rowCount] -= M[destRow, row] * M[row, rowCount]; M[destRow, row] = 0;
                    addToLog("R:" + M[destRow, rowCount] + " = " + M[destRow, rowCount] + " - " + M[destRow, row] + " * " + M[row, rowCount]);
                }
            }
            addToLog("SOLUTION FOUND!");
            return true;
        }

        public Matrix MakeMatrix()
        {
            Matrix matrix = new Matrix(m.GetLength(0), m.GetLength(1));
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    matrix.AddCell(i, j, m[i, j]);
                }
            }
            return matrix;
        }
    }
}
