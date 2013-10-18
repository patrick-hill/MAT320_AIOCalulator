using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace NumericalCalculator
{
    public partial class MAT320_AIO_Calulator : Form
    {
        private Calculator calc;

        public MAT320_AIO_Calulator()
        {
            InitializeComponent();
            methodComboBox.SelectedIndex = 3;
            toleranceComboBox.SelectedIndex = 0;
            calc = new Calculator(this);
        }

        private void CalculateBtn_Click(object sender, EventArgs e)
        {
            int tab = tabControl1.SelectedIndex;
            String[] args = null;

            if (tab == 0)
            {
                // grab method, function, ranges, & tolerance
                String method = methodComboBox.SelectedItem.ToString();
                String function = functionTextBox.Text;
                String functionDer = functionDerTextBox.Text;
                String ranges = rangesTextBox.Text;
                String tolerance = toleranceComboBox.SelectedItem.ToString();

                args = new String[] { method, function, functionDer, ranges, tolerance };
            }
            else if (tab == 1)
            {
                String method = t2comboBoxMethod.SelectedItem.ToString();
                String maxtrixStr = t2MatrixInpu.Text;

                args = new String[] { method, maxtrixStr };
            }
            
            calc.Calculate(tab, args);
        }

        private void clearLogBtn_Click(object sender, EventArgs e)
        {
            calc.log = "";
            outputTextBox.Text = calc.log;
        }
    }
}
