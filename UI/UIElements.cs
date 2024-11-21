using System.Windows.Controls;

namespace CalcLib.UI
{
    public sealed class UiElements
    {
        private static readonly UiElements instance = new UiElements();

        public TextBox TextBox { get; set; }

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static UiElements()
        {
        }

        private UiElements()
        {
        }

        public static UiElements Instance
        {
            get { return instance; }
        }
    }
}