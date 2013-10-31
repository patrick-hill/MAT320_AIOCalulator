using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumericalCalculator.CalcObjects
{
    public class Matrix
    {
        protected string name = null;
        protected double[,] matrix;
        protected int matrixRow, matrixColumn;

        public Matrix() { }
        public Matrix(int row, int column)
        {
            matrixRow = row;
            matrixColumn = column;
            matrix = new double[matrixRow, matrixColumn];
        }

        public void AddCell(int row, int column, double value)
        {
            matrix[row, column] = value;
        }

        public double GetCell(int row, int column)
        {
            return matrix[row, column];
        }

        public int GetRows()
        {
            return matrixRow;
        }

        public int GetColumns()
        {
            return matrixColumn;
        }

        public double[,] getMatrix()
        {
            return matrix;
        }

        public void SetName(String str)
        {
            name = str;
        }

        public String GetName()
        {
            return name;
        }

        public override String ToString()
        {
            if (name.Equals(null))
                name = "none";
            return name;
        }

        public String Print()
        {
            String s = null;
            for (int i = 0; i < matrixRow; i++)
            {
                for (int j = 0; j < matrixColumn; j++)
                {
                    s += matrix[i, j];
                    s += " ";
                }
                s += "\r\n";
            }

            return s;
        }

        public String PrettyPrint()
        {
            String s = null;
            for (int i = 0; i < matrixRow; i++)
            {
                for (int j = 0; j < matrixColumn; j++)
                {
                    s += RoundDigit(matrix[i, j], 4);
                    s += "\t";
                }
                s += "\r\n";
            }

            return s;
        }

        public Matrix MakeMatrixFromArray(double[,] array)
        {
            Matrix matrix = new Matrix(array.GetLength(0), array.GetLength(1));
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    matrix.AddCell(i, j, array[i, j]);
                }
            }
            return matrix;
        }

        public double RoundDigit(double d, int digits)
        {
            if (d == 0)
                return 0;

            double scale = Math.Pow(10, Math.Floor(Math.Log10(Math.Abs(d))) + 1);
            return scale * Math.Round(d / scale, digits);
        }
    }
}
