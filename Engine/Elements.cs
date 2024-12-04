using System;
using System.Globalization;
using System.Windows;


namespace CalcLib.Engine
{
    public sealed class Elements
    {
        private static readonly Elements _instance = new ();

        public System.Windows.Controls.TextBox TextBox { get; set; }

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Elements()
        {
        }

        private Elements()
        {
            Values.Instance.ValueChanged += UpdateText;
        }

        public static Elements Instance => _instance;

        public static void Clear()
        {
            SetText("");
        }

        public static void UpdateText()
        {
            if (Values.TryGetValue(out float value))
            {
                SetText(value.ToString(CultureInfo.InvariantCulture));
                return;
            }

            Clear();
        }

        public static void SetText(string text)
        {
            if (_instance.TextBox != null)
            {
                _instance.TextBox.Text = text;
            }
        }

        public static void SetTextBox(System.Windows.Controls.TextBox textBox)
        {
            _instance.TextBox = textBox;
        }

        public static void RegisterObjects(Window window,string name ,  Object textBox)
        {
            window.RegisterName(name, textBox);
        }
            
    }
}