
using CalcLib.Types;

namespace CalcLib.CalcVariants
{
    public class ButtonDefaultValues
    {
        IItem _nnnn = NoneItem.CreateItem();
        IItem _perc = FunctionItem.CreateItem("%", -1);
        IItem Clear = FunctionItem.CreateItem("C", -1);

        IItem Div = FunctionItem.CreateItem("/", null);

        IItem Add = FunctionItem.CreateItem("+", null);
        IItem Multi = FunctionItem.CreateItem("*", null);
        IItem Minus = FunctionItem.CreateItem("-", null);

        IItem Calc = FunctionItem.CreateItem("=", null);

        IItem Comma = FunctionItem.CreateItem(",", -1);

        IItem Num0 = FunctionItem.CreateItem("0", -1);
        IItem Num1 = FunctionItem.CreateItem("1", -1);
        IItem Num2 = FunctionItem.CreateItem("2", -1);
        IItem Num3 = FunctionItem.CreateItem("3", -1);
        IItem Num4 = FunctionItem.CreateItem("4", -1);
        IItem Num5 = FunctionItem.CreateItem("5", -1);
        IItem Num6 = FunctionItem.CreateItem("6", -1);
        IItem Num7 = FunctionItem.CreateItem("7", -1);
        IItem Num8 = FunctionItem.CreateItem("8", -1);
        IItem Num9 = FunctionItem.CreateItem("9", -1);

        private readonly IItem[,] _buttonItems = new IItem[,] { };

        public ButtonDefaultValues()
        {
            _buttonItems = new IItem[,]
            {
                { _perc, _nnnn, Clear, _nnnn },
                { _nnnn, _nnnn, _nnnn, Div },
                { Num7, Num8, Num9, Multi },
                { Num4, Num5, Num6, Minus },
                { Num1, Num2, Num3, Add },
                { _nnnn, Num0, Comma, Calc },
            };
            GetLengthY = _buttonItems.GetUpperBound(0);
            GetLengthX = _buttonItems.GetUpperBound(1);
            GetX = GetLengthX + 1;
        }

        internal int GetLengthY { get; }

        internal int GetLengthX { get; set; }

        public int GetX { get; }

        internal IItem GetItem(int y, int x)
        {
            return (IItem)_buttonItems.GetValue(y, x);
        }
    }
}