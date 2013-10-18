using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NumericalCalculator.CalcObjects;
using NCalc;

namespace NumericalCalculator.Methods
{
    class GaussElimination_Mine : BaseMethod
    {
        Matrix m;
        public void Evaluate(Matrix m)
        {
            this.m = m;
            // need all zeros on bottom until we can solve for a single var, then # of zeros for that row -1 is needed for row above to solve next, repeat

            int zerosNeeded = m.GetRows() - 2 - 1; // 1 for augmented & 2 #'s to solve
            zeroBottom(zerosNeeded);
        }

        public void zeroBottom(int zSize)
        {
            // do column by column, row by row
            for (int curCol = 0; curCol < m.GetColumns(); curCol++)
            {   // skip row 0
                for (int curRow = 1; curRow < m.GetRows(); curRow++)
                {   // while we are not zero'd out
                    while (m.GetCell(curRow, curCol) != 0)
                    {
                        //String s = m.GetCell(curRow, curCol) + " / " + 
                        //Expression exp = new Expression();

                        double divisor = m.GetCell(curRow + 1, curCol);
                        double multiplier = m.GetCell(curCol, curCol) / divisor;
                        // apply the divisor to the whole row
                        for (int j = 0; j < m.GetRows(); j++)
                        {
                            m.AddCell(curCol, j, ((multiplier * m.GetCell(curCol, 0)) / divisor));
                            // add log
                        }
                    }
                }
            }
            
        }
    }
}
