namespace MyApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.CalculatorScreen = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.button11 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button0 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// CalculatorScreen
			// 
			this.CalculatorScreen.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.CalculatorScreen.Location = new System.Drawing.Point(12, 12);
			this.CalculatorScreen.Name = "CalculatorScreen";
			this.CalculatorScreen.ReadOnly = true;
			this.CalculatorScreen.Size = new System.Drawing.Size(416, 56);
			this.CalculatorScreen.TabIndex = 0;
			this.CalculatorScreen.Text = "0.";
			this.CalculatorScreen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.button1.Location = new System.Drawing.Point(12, 89);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(87, 86);
			this.button1.TabIndex = 1;
			this.button1.Text = "1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.NumberButton_Click);
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.button2.Location = new System.Drawing.Point(122, 89);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(87, 86);
			this.button2.TabIndex = 2;
			this.button2.Text = "2";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.NumberButton_Click);
			// 
			// button3
			// 
			this.button3.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.button3.Location = new System.Drawing.Point(232, 89);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(87, 86);
			this.button3.TabIndex = 3;
			this.button3.Text = "3";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.NumberButton_Click);
			// 
			// button6
			// 
			this.button6.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.button6.Location = new System.Drawing.Point(232, 192);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(87, 86);
			this.button6.TabIndex = 6;
			this.button6.Text = "6";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.NumberButton_Click);
			// 
			// button5
			// 
			this.button5.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.button5.Location = new System.Drawing.Point(122, 192);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(87, 86);
			this.button5.TabIndex = 5;
			this.button5.Text = "5";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.NumberButton_Click);
			// 
			// button4
			// 
			this.button4.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.button4.Location = new System.Drawing.Point(12, 192);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(87, 86);
			this.button4.TabIndex = 4;
			this.button4.Text = "4";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.NumberButton_Click);
			// 
			// button9
			// 
			this.button9.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.button9.Location = new System.Drawing.Point(232, 295);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(87, 86);
			this.button9.TabIndex = 9;
			this.button9.Text = "9";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.NumberButton_Click);
			// 
			// button8
			// 
			this.button8.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.button8.Location = new System.Drawing.Point(122, 295);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(87, 86);
			this.button8.TabIndex = 8;
			this.button8.Text = "8";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.NumberButton_Click);
			// 
			// button7
			// 
			this.button7.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.button7.Location = new System.Drawing.Point(12, 295);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(87, 86);
			this.button7.TabIndex = 7;
			this.button7.Text = "7";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.NumberButton_Click);
			// 
			// button10
			// 
			this.button10.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.button10.Location = new System.Drawing.Point(341, 89);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(87, 86);
			this.button10.TabIndex = 10;
			this.button10.Text = "/";
			this.button10.UseVisualStyleBackColor = true;
			// 
			// button11
			// 
			this.button11.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.button11.Location = new System.Drawing.Point(341, 192);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(87, 86);
			this.button11.TabIndex = 11;
			this.button11.Text = "x";
			this.button11.UseVisualStyleBackColor = true;
			// 
			// button12
			// 
			this.button12.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.button12.Location = new System.Drawing.Point(341, 295);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(87, 86);
			this.button12.TabIndex = 12;
			this.button12.Text = "-";
			this.button12.UseVisualStyleBackColor = true;
			// 
			// button13
			// 
			this.button13.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.button13.Location = new System.Drawing.Point(270, 407);
			this.button13.Name = "button13";
			this.button13.Size = new System.Drawing.Size(158, 86);
			this.button13.TabIndex = 13;
			this.button13.Text = "+ / =";
			this.button13.UseVisualStyleBackColor = true;
			this.button13.Click += new System.EventHandler(this.button13_Click);
			// 
			// button0
			// 
			this.button0.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.button0.Location = new System.Drawing.Point(122, 407);
			this.button0.Name = "button0";
			this.button0.Size = new System.Drawing.Size(87, 86);
			this.button0.TabIndex = 14;
			this.button0.Text = "0";
			this.button0.UseVisualStyleBackColor = true;
			this.button0.Click += new System.EventHandler(this.NumberButton_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(441, 505);
			this.Controls.Add(this.button0);
			this.Controls.Add(this.button13);
			this.Controls.Add(this.button12);
			this.Controls.Add(this.button11);
			this.Controls.Add(this.button10);
			this.Controls.Add(this.button9);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.CalculatorScreen);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Fritz\'s Wonderful Windows Application";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.TextBox CalculatorScreen;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Button button0;
	}
}

