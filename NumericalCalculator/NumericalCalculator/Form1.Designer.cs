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
            this.SuspendLayout();
            // 
            // methodComboBox
            // 
            this.methodComboBox.FormattingEnabled = true;
            this.methodComboBox.Items.AddRange(new object[] {
            "Bisection",
            "Regula Falsi",
            "Newtons Method"});
            this.methodComboBox.Location = new System.Drawing.Point(12, 44);
            this.methodComboBox.Name = "methodComboBox";
            this.methodComboBox.Size = new System.Drawing.Size(174, 24);
            this.methodComboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Method Selection";
            // 
            // functionTextBox
            // 
            this.functionTextBox.Location = new System.Drawing.Point(278, 44);
            this.functionTextBox.Name = "functionTextBox";
            this.functionTextBox.Size = new System.Drawing.Size(186, 22);
            this.functionTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Function";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(540, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ranges(Comma Delimited)";
            // 
            // rangesTextBox
            // 
            this.rangesTextBox.Location = new System.Drawing.Point(543, 46);
            this.rangesTextBox.Name = "rangesTextBox";
            this.rangesTextBox.Size = new System.Drawing.Size(186, 22);
            this.rangesTextBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(813, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 17);
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
            this.toleranceComboBox.Location = new System.Drawing.Point(816, 46);
            this.toleranceComboBox.Name = "toleranceComboBox";
            this.toleranceComboBox.Size = new System.Drawing.Size(174, 24);
            this.toleranceComboBox.TabIndex = 3;
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(15, 285);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(549, 414);
            this.outputTextBox.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(236, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Output";
            // 
            // MAT320_AIO_Calulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 711);
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
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Label label5;

    }
}

