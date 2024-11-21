using System;
using System.Windows;
using System.Windows.Controls;
using CalcLib.CalcVariants;
using CalcLib.Types;

namespace CalcLib.UI
{
    public class ButtonCore
    {
        private int _offSetTop = 0;
        private int _offSetLeft = 0;

        public const int Width = 40;
        private const int Height = 40;


        public static ButtonCore GetInstance(int top, int left)
        {
            var ret = new ButtonCore
            {
                _offSetTop = top,
                _offSetLeft = left
            };
            return ret;
        }

        public void AddDefaultsButtons(Window that, Grid mainGrid, ButtonDefaultValues values)
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

        private void AddButton(Window that, Grid mainGrid, int x, int y, IItem item)
        {
            if (that == null) throw new ArgumentNullException(nameof(that));
            if (mainGrid == null) throw new ArgumentNullException(nameof(mainGrid));
            if (item == null) throw new ArgumentNullException(nameof(item));

            var button = OneCharButton.CreateInstance("oneCharButton" + x + y,
                item.Name, Width, Height);

            that.RegisterName(button.Name, button);
            mainGrid.Children.Add(button);

            if (item is FunctionItem itemF)
            {
                button.Click += getClick(itemF);
            }


            button.Margin = new Thickness
            {
                Top = y * Height + _offSetTop,
                Left = x * Width + _offSetLeft
            };
        }

        private RoutedEventHandler getClick(FunctionItem item)
        {
            return (sender, args) =>
            {
                var uiElements = UiElements.Instance;
                uiElements.TextBox.Text = item.Name;
            };
        }
    }
}