using System;
using System.Windows;
using System.Windows.Controls;
using CalcLib.Engine;
using CalcLib.Types;

namespace CalcLib.UI
{
    public class ButtonCore
    {
        private int _offSetTop;
        private int _offSetLeft;

        public const int Width = 40;
        public const int Height = 40;
        
        public static ButtonCore GetInstance(int top, int left)
        {
            var ret = new ButtonCore
            {
                _offSetTop = top,
                _offSetLeft = left
            };
            return ret;
        }

        public void AddDefaultsButtons(Window that, Grid mainGrid, IButtonValues values)
        {
            for (var y = 0; y <= values.GetLengthY; y++)
            {
                for (var x = 0; x <= values.GetLengthX; x++)
                {
                    var item = values.GetItem(y, x);
                    AddButton(that, mainGrid, x, y, item);
                }
            }
        }

        private void AddButton(Window that, Grid mainGrid, int x, int y, Item item)
        {
            if (that == null) throw new ArgumentNullException(nameof(that));
            if (mainGrid == null) throw new ArgumentNullException(nameof(mainGrid));
            if (item == null) throw new ArgumentNullException(nameof(item));

            var button = PrettyButton.CreateInstance("PrettyButton" + x + y,
                item.Name);

            that.RegisterName(button.Name, button);
            mainGrid.Children.Add(button);

            button.Margin = new Thickness
            {
                Top = y * Height + _offSetTop,
                Left = x * Width + _offSetLeft
            };
            button.CommandParameter = item;

            if (item is Item itemF)
            {
                button.CommandParameter = itemF;
                button.Click += ButtonOnClick;
            }
        }

        private void ButtonOnClick(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var item = button.CommandParameter as Item;
            Values.Add(item);
        }
    }
}