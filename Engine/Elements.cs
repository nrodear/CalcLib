using System.Windows.Controls;
using CalcLib.UI;

namespace CalcLib.Engine
{
    public sealed class Elements
    {
        private static readonly Elements instance = new Elements();

        public TextBox TextBox { get; set; }


        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Elements()
        {
        }

        private Elements()
        {
        }

        public static Elements Instance
        {
            get { return instance; }
        }
    }
}