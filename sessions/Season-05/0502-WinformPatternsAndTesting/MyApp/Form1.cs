using System;
using System.Windows.Forms;
using MyApp.Core;

namespace MyApp
{

	public partial class Form1 : Form, ICalculatorView
	{

		private readonly Presenter _Presenter;

		public string ScreenDisplay
		{
			get => CalculatorScreen.Text;
			set { CalculatorScreen.Text = value; }
		}

		public Form1()
		{
			InitializeComponent();

			_Presenter = new Presenter(this);

		}

		private void NumberButton_Click(object sender, EventArgs e)
		{

			_Presenter.NumberButtonPressed((sender as Button).Text);

		}

		private void button13_Click(object sender, EventArgs e)
		{

			_Presenter.OperatorButtonClick((sender as Button).Text);

		}

		private void button14_Click(object sender, EventArgs e)
		{
			_Presenter.ClearButtonPressed();
		}
	}
}
