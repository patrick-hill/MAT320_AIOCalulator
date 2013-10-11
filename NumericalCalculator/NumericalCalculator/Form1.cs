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
            calc = new Calculator(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // grab method, function, ranges, & tolerance
            String method = methodComboBox.SelectedItem.ToString();
            String function = functionTextBox.Text;
            String functionDer = functionDerTextBox.Text;
            String ranges = rangesTextBox.Text;
            String tolerance = toleranceComboBox.SelectedItem.ToString();

            switch (method)
            {
                case "Bisection":
                    calc.bisect(function, ranges, tolerance);
                    Console.WriteLine("a");
                    break;
                case "Regula Falsi":
                    Debug.WriteLine("Regula Falsi");
                    calc.RegulaFalsi(function, ranges, tolerance);
                    break;
                case "Newtons Method":
                    Console.WriteLine("Newtons Method");
                    calc.NeutonsMethod(function, functionDer, ranges, tolerance);
                    break;
            }
            //Bisection
            //Regula Falsi
            //Newtons Method
        }
    }
}
