using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace MyApp
{

	public partial class Form1 : Form
	{

		private decimal _Buffer = 0;
		private char _Operation = ' ';

		public Form1()
		{
			InitializeComponent();
		}

		private void NumberButton_Click(object sender, EventArgs e)
		{

			var button = sender as Button;

			if (CalculatorScreen.Text == "0.")
			{
				CalculatorScreen.Text = button.Text;
			}
			else
			{
				CalculatorScreen.Text += button.Text;
			}

		}

		private void button13_Click(object sender, EventArgs e)
		{
			
			if (_Operation == ' ') {
				_Operation = '+';
				_Buffer = decimal.Parse(CalculatorScreen.Text);
				CalculatorScreen.Text = "0.";
			} else {

				decimal currentValue = decimal.Parse(CalculatorScreen.Text);

				CalculatorScreen.Text = _Operation switch
				{
					'+' => (_Buffer + currentValue).ToString(),
					'-' => (_Buffer - currentValue).ToString(),
					'x' => (_Buffer * currentValue).ToString(),
					'/' => (_Buffer / currentValue).ToString(),
					_ => "0."
				};

				_Buffer = 0;
				_Operation = ' ';

			}

		}
	}
}
