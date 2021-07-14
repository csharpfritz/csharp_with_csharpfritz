using System;

namespace MyApp.Core
{
    public interface ICalculatorView {

        public string ScreenDisplay { get; set; }

        public event EventHandler NumberButtonPressed;

    }

}
