using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumericalCalculator.CalcObjects
{
    // Wrapper class to add the augmented data w/o having to redo the Matrix class.
    class MatrixAugmented : Matrix
    {
        private double[,] mAug;

        public MatrixAugmented(int r, int c) : base(r,c)
        {
            // extra column for augmented data
            mAug = new double[r + 1, c + 1];
        }

        public void addAugment(int r, int c)
        {
            
        }
    }
}
