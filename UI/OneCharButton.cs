using System;
using System.Web;
using System.Windows;
using System.Windows.Controls;

namespace CalcLib.UI
{
    internal class OneCharButton
    {
        private readonly Button _myControl = new Button();
        
        private OneCharButton(string name, string symbol, int width, int height)
        {
            if (symbol.Length > 1)
            {
                throw new ArgumentException("symbol");
            }

            var myEncodedString = HttpUtility.HtmlEncode(symbol);

            _myControl.Width = 40;
            _myControl.Height = 40;

            _myControl.Name = name;
            _myControl.Content = symbol;

            _myControl.VerticalAlignment = VerticalAlignment.Top;
            _myControl.HorizontalAlignment = HorizontalAlignment.Left;
        }

        public static Button CreateInstance(string name, string symbol, int width, int height)
        {
            return new OneCharButton(name, symbol, width, height)._myControl;
        }
    }
}