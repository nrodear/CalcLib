using System;
using System.Windows;
using System.Windows.Controls;

namespace LibCalc.UI
{
    internal class PrettyButton
    {
        private readonly Button _myControl = new Button();
        
        private PrettyButton(string name, string symbol)
        {
            if (symbol.Length > 2)
            {
                throw new ArgumentException("symbol");
            }
            
            _myControl.Width = ButtonCore.Width;
            _myControl.Height = ButtonCore.Height;

            _myControl.Name = name;
            _myControl.Content = symbol;

            _myControl.VerticalAlignment = VerticalAlignment.Top;
            _myControl.HorizontalAlignment = HorizontalAlignment.Left;
        }

        public static Button CreateInstance(string name, string symbol)
        {
            return new PrettyButton(name, symbol)._myControl;
        }
    }
}