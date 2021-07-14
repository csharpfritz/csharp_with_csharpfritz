using System;

namespace MyApp.Core
{
	public class Presenter
	{

		private readonly ICalculatorView _View;
		private decimal _Buffer = 0;


		public Presenter(ICalculatorView view)
		{
			this._View = view;
		}

		public void NumberButtonPressed(string numberButtonValue)
		{

			if (_View.ScreenDisplay == "0." || _CompletedOperation)
			{
				_View.ScreenDisplay = numberButtonValue;
				_CompletedOperation = false;
			}
			else
			{
				_View.ScreenDisplay += numberButtonValue;
			}

		}

		private char _CurrentOperation = ' ';
		private bool _CompletedOperation = false;

		public void OperatorButtonClick(string @operator)
		{

			if (_CurrentOperation == ' ')
			{
				_CurrentOperation = @operator.Contains("+") ? '+' : @operator[0];
				_Buffer = decimal.Parse(_View.ScreenDisplay);
				_View.ScreenDisplay = "0.";
			}
			else
			{

				decimal currentValue = decimal.Parse(_View.ScreenDisplay);

				_Buffer = _CurrentOperation switch
				{
					'+' => (_Buffer + currentValue),
					'-' => (_Buffer - currentValue),
					'x' => (_Buffer * currentValue),
					'/' => (_Buffer / currentValue),
					_ => 0m
				};

				_View.ScreenDisplay = _Buffer.ToString();
				//_CurrentOperation = ' ';
				_CompletedOperation = true;

			}

		}

		public void ClearButtonPressed()
		{
			_View.ScreenDisplay = "0.";
		}
	}

}
