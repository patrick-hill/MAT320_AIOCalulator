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
            // grab method, function, ranges, & tolerance
            String method = methodComboBox.SelectedItem.ToString();
            String function = functionTextBox.Text;
            String functionDer = functionDerTextBox.Text;
            String ranges = rangesTextBox.Text;
            String tolerance = toleranceComboBox.SelectedItem.ToString();

            calc.Calculate(method, function, functionDer, ranges, tolerance);
        }

        private void clearLogBtn_Click(object sender, EventArgs e)
        {
            calc.log = "";
            outputTextBox.Text = calc.log;
        }
    }
}
