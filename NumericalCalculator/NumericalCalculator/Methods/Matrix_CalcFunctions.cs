using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NumericalCalculator.CalcObjects;

namespace MatrixCalculator_MAT210
{
    public class CalcFunctions

    {

        public Matrix DoAddition(Matrix matrixA, Matrix matrixB)
        {
            Matrix finalAdditionMatrix;
            int aRows = matrixA.GetRows();
            int aColumns = matrixA.GetColumns();
            int bRows = matrixB.GetRows();
            int bColumns = matrixB.GetColumns();

            if (aRows == bRows && aColumns == bColumns)
            {
                finalAdditionMatrix = new Matrix(aRows, aColumns);

                for (int row = 0; row < matrixA.GetRows(); row++)
                {
                    for (int column = 0; column < matrixA.GetColumns(); column++)
                    {
                        double aValue = matrixA.GetCell(row, column);
                        double bValue = matrixB.GetCell(row, column);
                        double finalValue = aValue + bValue;

                        finalAdditionMatrix.AddCell(row, column, finalValue);
                    }
                }
            }
            else
                finalAdditionMatrix = null;

            return finalAdditionMatrix;
        }

        public Matrix DoMultiplication(Matrix mx1, Matrix mx2, double value)
        {
            Matrix ans;

            // Determines if this is Matrix by Matrix or not.
            if (value == 0)
            {
                // Tranposing the second Matrix simplifies process.
                mx2 = DoTranpose(mx2);

                ans = new Matrix(mx1.GetRows(), mx1.GetRows());
                Console.WriteLine("Product Matrix Size is: " + ans.GetRows() + "x" + ans.GetColumns());

                for (int a = 0; a < mx1.GetRows(); a++)             // 2
                {
                    for (int b = 0; b < mx1.GetRows(); b++)         // 2
                    {
                        for (int i = 0; i < mx1.GetColumns(); i++)  // 3
                        {
                            Console.WriteLine(
                                "Adding " + ans.GetCell(a, b) + "\t to " + mx1.GetCell(a, i) +
                                "\t multiplied by " + mx2.GetCell(b, i));
                            ans.AddCell(a, b, ans.GetCell(a, b) + mx1.GetCell(a, i) * mx2.GetCell(b, i));
                        }
                    }
                }
            }

            else
            {
                for (int i = 0; i < mx1.GetRows(); i++)
                {
                    for (int j = 0; j < mx1.GetColumns(); j++)
                    {
                        Console.WriteLine("Multiplying " + mx1.GetCell(i, j) + "\t by " + value);
                        mx1.AddCell(i, j, value * mx1.GetCell(i, j));
                    }
                }
                ans = mx1;
            }

            return ans;
        }

        public void Inverse()
        {

        }

        public Matrix DoTranpose(Matrix m1)
        {
            int aRows = m1.GetRows();
            int aColumns = m1.GetColumns();

            Matrix m2 = new Matrix(aColumns, aRows);

            for (int i = 0; i < aRows; i++)
            {
                for (int j = 0; j < aColumns; j++)
                {
                    //double value = m1.GetCell(i, j);
                    m2.AddCell(j, i, m1.GetCell(i, j));
                }
            }

            return m2;
        }
    }
}
