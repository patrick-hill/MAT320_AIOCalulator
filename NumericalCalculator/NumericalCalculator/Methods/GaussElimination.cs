using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NumericalCalculator.CalcObjects;

namespace NumericalCalculator.Methods
{
    class GaussElimination : BaseMethod
    {
        double[,] originalMatrix;
        double[,] identityMatrix;
        String steps;

        public void Evaluate(Matrix matrix)
        {
            double[,] result = HardCalculation(matrix.getMatrix(), matrix.GetRows(), matrix.GetColumns());
        }

        public double[,] HardCalculation(double[,] matrix, int rowSize, int columnSize)
        {
            originalMatrix = matrix;
            identityMatrix = setupIdentity(rowSize, columnSize);

            int curRow = 0;
            int curColumn = 0;

            //calls changeBottomZeros to reduce the array into row echelon form
            while (curRow < rowSize - 1)
            {
                changeBottomZeros(rowSize, columnSize, curRow, curColumn);
                curRow++;
                curColumn++;
            }

            return identityMatrix;
        }

        public double[,] setupIdentity(int rows, int columns)
        {
            double[,] identityMatrix = new double[rows, columns];

            int row = 0;
            int column = 0;
            //sets up the 1's on the array for row echelon form
            while (row < rows && column < columns)
            {
                identityMatrix[row, column] = 1;
                row += 1;
                column += 1;
            }

            //sets up the 0's on the rest of the array for reduced row echelon form
            for (row = 0; row < rows; row++)
            {
                for (column = 0; column < columns; column++)
                {
                    if (identityMatrix[row, column] != 1)
                    {
                        identityMatrix[row, column] = 0;
                    }
                }
            }

            return identityMatrix;
        }

        public void changeBottomZeros(int rowSize, int columnSize, int startRow, int startColumn)
        {
            double multiplier;

            //attempts to change the first number to 1 if possible
            if (originalMatrix[startRow, startColumn] != 1)
            {
                if (originalMatrix[startRow, startColumn] == 0)
                {

                }
                else
                {
                    multiplier = 1 / originalMatrix[startRow, startColumn];

                    for (int i = startColumn; i < columnSize; i++)
                    {
                        originalMatrix[startRow, i] = originalMatrix[startRow, i] * multiplier;
                        identityMatrix[startRow, i] = identityMatrix[startRow, i] * multiplier;
                    }
                }
            }
            bool bottomZeros = false;
            int row = startRow + 1;
            int column = startColumn;

            //loop to get the bottom left to zeros (row echelon form)
            while (!bottomZeros)
            {
                if (originalMatrix[row, column] != 0)
                {
                    multiplier = originalMatrix[row, column];
                    for (int i = startColumn; i < columnSize; i++)
                    {
                        originalMatrix[row, i] = originalMatrix[row, i] - (multiplier * originalMatrix[startRow, i]);
                        identityMatrix[row, i] = identityMatrix[row, i] - (multiplier * identityMatrix[startRow, i]);
                    }
                }

                //loops through to print steps
                for (int i = 0; i < columnSize; i++)
                {
                    for (int a = 0; a < columnSize; a++)
                    {
                        steps += originalMatrix[i, a] + " ";
                    }
                    for (int a = 0; a < columnSize; a++)
                    {
                        steps += identityMatrix[i, a] + " ";
                    }

                    steps += "\n";
                }
                steps += "-----------------\n";
                row++;

                if (row == rowSize)
                {
                    bottomZeros = true;
                }
            }
        }
    }
}
