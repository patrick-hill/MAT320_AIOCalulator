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
            this.clearLogBtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Methods = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.t2MatrixInpu = new System.Windows.Forms.TextBox();
            this.t2comboBoxMethod = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.Methods.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // methodComboBox
            // 
            this.methodComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.methodComboBox.FormattingEnabled = true;
            this.methodComboBox.Items.AddRange(new object[] {
            "Bisection",
            "Regula Falsi",
            "Newtons Method",
            "Mullers Method"});
            this.methodComboBox.Location = new System.Drawing.Point(17, 25);
            this.methodComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.methodComboBox.Name = "methodComboBox";
            this.methodComboBox.Size = new System.Drawing.Size(141, 21);
            this.methodComboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Method Selection";
            // 
            // functionTextBox
            // 
            this.functionTextBox.Location = new System.Drawing.Point(18, 73);
            this.functionTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.functionTextBox.Name = "functionTextBox";
            this.functionTextBox.Size = new System.Drawing.Size(140, 20);
            this.functionTextBox.TabIndex = 1;
            this.functionTextBox.Text = "x^3 - 2*x-5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Function";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 153);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ranges(Comma Delimited)";
            // 
            // rangesTextBox
            // 
            this.rangesTextBox.Location = new System.Drawing.Point(18, 169);
            this.rangesTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.rangesTextBox.Name = "rangesTextBox";
            this.rangesTextBox.Size = new System.Drawing.Size(140, 20);
            this.rangesTextBox.TabIndex = 3;
            this.rangesTextBox.Text = "-1,-2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 195);
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
            ".005",
            ".001",
            ".01",
            "0"});
            this.toleranceComboBox.Location = new System.Drawing.Point(18, 210);
            this.toleranceComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.toleranceComboBox.Name = "toleranceComboBox";
            this.toleranceComboBox.Size = new System.Drawing.Size(140, 21);
            this.toleranceComboBox.TabIndex = 4;
            // 
            // outputTextBox
            // 
            this.outputTextBox.AcceptsReturn = true;
            this.outputTextBox.AcceptsTab = true;
            this.outputTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.outputTextBox.Location = new System.Drawing.Point(2, 310);
            this.outputTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputTextBox.Size = new System.Drawing.Size(417, 409);
            this.outputTextBox.TabIndex = 8;
            this.outputTextBox.WordWrap = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(177, 290);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Output Display";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(348, 287);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 19);
            this.button1.TabIndex = 5;
            this.button1.Text = "Calculate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CalculateBtn_Click);
            // 
            // functionDerTextBox
            // 
            this.functionDerTextBox.Location = new System.Drawing.Point(18, 114);
            this.functionDerTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.functionDerTextBox.Name = "functionDerTextBox";
            this.functionDerTextBox.Size = new System.Drawing.Size(140, 20);
            this.functionDerTextBox.TabIndex = 2;
            this.functionDerTextBox.Text = "20 * x^4 - 12 * x^3 - 30 * x^2 + 10* x - 15";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 99);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Function Derivative";
            // 
            // clearLogBtn
            // 
            this.clearLogBtn.Location = new System.Drawing.Point(12, 287);
            this.clearLogBtn.Margin = new System.Windows.Forms.Padding(2);
            this.clearLogBtn.Name = "clearLogBtn";
            this.clearLogBtn.Size = new System.Drawing.Size(89, 19);
            this.clearLogBtn.TabIndex = 13;
            this.clearLogBtn.Text = "Clear Output";
            this.clearLogBtn.UseVisualStyleBackColor = true;
            this.clearLogBtn.Click += new System.EventHandler(this.clearLogBtn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.Methods);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 7);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(417, 275);
            this.tabControl1.TabIndex = 16;
            // 
            // Methods
            // 
            this.Methods.BackColor = System.Drawing.Color.LightGray;
            this.Methods.Controls.Add(this.methodComboBox);
            this.Methods.Controls.Add(this.label1);
            this.Methods.Controls.Add(this.functionTextBox);
            this.Methods.Controls.Add(this.label6);
            this.Methods.Controls.Add(this.label2);
            this.Methods.Controls.Add(this.functionDerTextBox);
            this.Methods.Controls.Add(this.label3);
            this.Methods.Controls.Add(this.rangesTextBox);
            this.Methods.Controls.Add(this.label4);
            this.Methods.Controls.Add(this.toleranceComboBox);
            this.Methods.Location = new System.Drawing.Point(23, 4);
            this.Methods.Name = "Methods";
            this.Methods.Padding = new System.Windows.Forms.Padding(3);
            this.Methods.Size = new System.Drawing.Size(390, 267);
            this.Methods.TabIndex = 0;
            this.Methods.Text = "Methods";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightGray;
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.t2MatrixInpu);
            this.tabPage2.Controls.Add(this.t2comboBoxMethod);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(23, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(390, 267);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Matrix";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(221, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(148, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Matrix Input (Space Delimited)";
            // 
            // t2MatrixInpu
            // 
            this.t2MatrixInpu.Location = new System.Drawing.Point(6, 50);
            this.t2MatrixInpu.Multiline = true;
            this.t2MatrixInpu.Name = "t2MatrixInpu";
            this.t2MatrixInpu.Size = new System.Drawing.Size(363, 206);
            this.t2MatrixInpu.TabIndex = 2;
            // 
            // t2comboBoxMethod
            // 
            this.t2comboBoxMethod.FormattingEnabled = true;
            this.t2comboBoxMethod.Items.AddRange(new object[] {
            "Gauss Elimination (Back Substitution)",
            "Gauss-Jordan Elimination"});
            this.t2comboBoxMethod.Location = new System.Drawing.Point(6, 23);
            this.t2comboBoxMethod.Name = "t2comboBoxMethod";
            this.t2comboBoxMethod.Size = new System.Drawing.Size(107, 21);
            this.t2comboBoxMethod.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Method";
            // 
            // MAT320_AIO_Calulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 722);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.clearLogBtn);
            this.Controls.Add(this.button1);
            this.Name = "MAT320_AIO_Calulator";
            this.Text = "MAT320 AIO Calculator";
            this.tabControl1.ResumeLayout(false);
            this.Methods.ResumeLayout(false);
            this.Methods.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
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
        private System.Windows.Forms.Button clearLogBtn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Methods;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox t2MatrixInpu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox t2comboBoxMethod;

    }
}

