using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using TextBox = System.Windows.Controls.TextBox;

namespace CalcLib.UI
{
    public class TextBoxes
    {
        private TextBox _textbox;

        public TextBox GetTextBox(int  top , int left , int width)
        {
            //< TextBox HorizontalAlignment = "Left" Margin = "308,215,0,0" 
            //TextWrapping = "Wrap" Text = "TextBox" VerticalAlignment = "Top" Width = "200" />
            
            _textbox = new TextBox
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness()
                {
                    Top = top,      // 300
                    Left = left,    // 200
                },
                Width = width,      // 200
                Background = new SolidColorBrush(Color.FromRgb(244, 255, 237))
            };
            
            return _textbox;
        }

    }

}
