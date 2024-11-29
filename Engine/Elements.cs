using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Controls;
using CalcLib.Types;

namespace CalcLib.Engine
{
    public sealed class Elements
    {
        private static readonly Elements instance = new Elements();

        private TextBox TextBox { get; set; }

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Elements()
        {
        }

        private Elements()
        {
        }

        public static Elements Instance => instance;

        public static void Clear()
        {
            if (instance.TextBox != null)
            {
                instance.TextBox.Text = "";
            };
        }

        public static void SetText(string text)
        {
            if (instance.TextBox != null)
            {
                instance.TextBox.Text = text;
            }
        }

        public static void SetTextBox(TextBox textBox)
        {
            instance.TextBox = textBox;
        }
    }
}