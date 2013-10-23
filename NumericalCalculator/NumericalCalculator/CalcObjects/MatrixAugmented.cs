using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumericalCalculator.CalcObjects
{
    /// <summary>
    /// Wrapper class to add the augmented data w/o having to redo the Matrix class.
    /// </summary>
    class MatrixAugmented : Matrix
    {
        private double[,] mAug;

        /// <summary>
        /// Creates a Matrix w/ augmented data on far right column
        /// </summary>
        /// <param name="r"> Number of rows</param>
        /// <param name="c"> Number of columns</param>
        public MatrixAugmented(int r, int c) : base(r,c)
        {
            mAug = new double[r + 1, c + 1];
        }

        public double[,] getMatrix()
        {
            return matrix;
        }

        public void addAugmentedCell(int row, int col)
        {

        }
    }
}
