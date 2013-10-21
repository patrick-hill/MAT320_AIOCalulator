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
        string steps;

        //public void Evaluate(Matrix matrix)
        //{
        //    double[,] result = HardCalculation(matrix.getMatrix(), matrix.GetRows(), matrix.GetColumns());


        //}

        public void Evaluate(String args)
        {
            Matrix matrix = createMatrix(args);
            double[,] matrixArray = HardCalculation(matrix.getMatrix(), matrix.GetRows(), matrix.GetColumns());

            double[] results = new double[matrix.GetColumns() - 1];
        }

        public void Evaluate2(String args)
        {
            Matrix matrix = createMatrix(args);
            int i, j, k, n;
            double[,] a = new double[10, 10];
            double[] c = new double[10];
            double[] x = new double[10];
            printf("\nenter the number of elements: ");
            a = matrix.getMatrix();
            for (k = 0; k < n - 1; i++)
            {
                for (i = k + 1; i < n; i++)
                {
                    for (j = k + 1; j < n; j++)
                    {
                        a[i,j] = a[i,j] - (a[i,k] / a[k,k]) * a[k,j];
                        c[i] = c[i] - (a[i,k] / a[k,k]) * c[k];
                    }
                }
                x[n - 1] = c[n - 1] / a[n - 1,n - 1];
                printf("x[%d]=%f\n", n - 1, x[n - 1]);
                for (k = 0; k < n - 1; k++)
                {
                    i = n - k - 2;
                    for (j = i + 1; j < n; j++)
                        c[i] = c[i] - (a[i][j] * x[j]);
                    x[i] = c[i] / a[i][i];
                    printf("x[%d]=%f\n", i, x[i]);
                }
            }
        }

        public double[] EvaluateVariables(double[,] matrixArray)
        {
            int count = 1;
            int row = matrixArray.GetLength(0) - 1;
            int column = matrixArray.Length - 2;
            double[] variables = new double[column];

            for (int i = row; i >= 0; i--)
            {

            }

            return variables;
        }

        public Matrix createMatrix(String arg)
        {
            string[] argArray = arg.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            Matrix matrix = new Matrix(argArray.Length, argArray[0].Split(',').Length);
            int row = 0;
            int column = 0;
            foreach (string rowString in argArray)
            {
                string[] rowArray = rowString.Split(',');
                for (int i = 0; i < rowArray.Length; i++)
                {
                    if (column >= matrix.GetColumns())
                        break;
                    matrix.AddCell(row, column, double.Parse(rowArray[column]));
                    column++;
                }

                row++;
                column = 0;

                if (row >= matrix.GetRows())
                    break;
            }
            return matrix;
        }

        public double[,] HardCalculation(double[,] matrix, int rows, int columns)
        {
            originalMatrix = matrix;
            identityMatrix = setupIdentity(rows, columns);

            int row = 0;
            int column = 0;

            //calls changeBottomZeros to reduce the array into row echelon form
            while (row < rows - 1)
            {
                changeBottomZeros(rows, columns, row, column);
                row++;
                column++;
            }

            return originalMatrix;
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

        public void changeBottomZeros(int rows, int columns, int startRow, int startColumn)
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

                    for (int i = startColumn; i < columns; i++)
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
                    for (int i = startColumn; i < columns; i++)
                    {
                        originalMatrix[row, i] = originalMatrix[row, i] - (multiplier * originalMatrix[startRow, i]);
                        identityMatrix[row, i] = identityMatrix[row, i] - (multiplier * identityMatrix[startRow, i]);
                    }
                }

                //loops through to print steps
                for (int i = 0; i < rows; i++)
                {
                    for (int a = 0; a < columns; a++)
                    {
                        steps += originalMatrix[i, a] + " ";
                    }
                    for (int a = 0; a < columns; a++)
                    {
                        steps += identityMatrix[i, a] + " ";
                    }

                    steps += "\n";
                }
                steps += "-----------------\n";
                row++;

                if (row == rows)
                {
                    bottomZeros = true;
                }
            }
        }
    }
}
