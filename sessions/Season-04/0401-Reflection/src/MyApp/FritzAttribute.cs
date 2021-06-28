using System;

namespace MyApp {

    public class FritzAttribute : Attribute
    {
        public FritzAttribute(bool onStream = false)
        {
            this.OnStream = onStream;
        }

        public bool OnStream { get; set; }

    }

}