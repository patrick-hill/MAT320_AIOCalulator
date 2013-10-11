namespace NumericalCalculator
{
    partial class MAT320_AIO_Calulator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.methodComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.functionTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rangesTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toleranceComboBox = new System.Windows.Forms.ComboBox();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.functionDerTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // methodComboBox
            // 
            this.methodComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.methodComboBox.FormattingEnabled = true;
            this.methodComboBox.Items.AddRange(new object[] {
            "Bisection",
            "Regula Falsi",
            "Newtons Method"});
            this.methodComboBox.Location = new System.Drawing.Point(9, 36);
            this.methodComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.methodComboBox.Name = "methodComboBox";
            this.methodComboBox.Size = new System.Drawing.Size(132, 21);
            this.methodComboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Method Selection";
            // 
            // functionTextBox
            // 
            this.functionTextBox.Location = new System.Drawing.Point(208, 36);
            this.functionTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.functionTextBox.Name = "functionTextBox";
            this.functionTextBox.Size = new System.Drawing.Size(140, 20);
            this.functionTextBox.TabIndex = 1;
            this.functionTextBox.Text = "Pow(x, 4)-x-10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Function";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(405, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ranges(Comma Delimited)";
            // 
            // rangesTextBox
            // 
            this.rangesTextBox.Location = new System.Drawing.Point(407, 37);
            this.rangesTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rangesTextBox.Name = "rangesTextBox";
            this.rangesTextBox.Size = new System.Drawing.Size(140, 20);
            this.rangesTextBox.TabIndex = 2;
            this.rangesTextBox.Text = "1,2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(610, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tolerance Selection";
            // 
            // toleranceComboBox
            // 
            this.toleranceComboBox.FormattingEnabled = true;
            this.toleranceComboBox.Items.AddRange(new object[] {
            ".0005",
            ".005",
            ".001",
            ".01",
            "0"});
            this.toleranceComboBox.Location = new System.Drawing.Point(612, 37);
            this.toleranceComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.toleranceComboBox.Name = "toleranceComboBox";
            this.toleranceComboBox.Size = new System.Drawing.Size(132, 21);
            this.toleranceComboBox.TabIndex = 3;
            // 
            // outputTextBox
            // 
            this.outputTextBox.AcceptsReturn = true;
            this.outputTextBox.AcceptsTab = true;
            this.outputTextBox.Location = new System.Drawing.Point(11, 232);
            this.outputTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.Size = new System.Drawing.Size(413, 337);
            this.outputTextBox.TabIndex = 8;
            this.outputTextBox.WordWrap = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(177, 206);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Output";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(636, 150);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 19);
            this.button1.TabIndex = 10;
            this.button1.Text = "Calculate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // functionDerTextBox
            // 
            this.functionDerTextBox.Location = new System.Drawing.Point(208, 87);
            this.functionDerTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.functionDerTextBox.Name = "functionDerTextBox";
            this.functionDerTextBox.Size = new System.Drawing.Size(140, 20);
            this.functionDerTextBox.TabIndex = 11;
            this.functionDerTextBox.Text = "Pow(x, 4)-x-10";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(205, 72);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Function Derivative";
            // 
            // MAT320_AIO_Calulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 578);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.functionDerTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.toleranceComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rangesTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.functionTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.methodComboBox);
            this.Name = "MAT320_AIO_Calulator";
            this.Text = "MAT320 AIO Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox methodComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox functionTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox rangesTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox toleranceComboBox;
        public System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox functionDerTextBox;
        private System.Windows.Forms.Label label6;

    }
}

