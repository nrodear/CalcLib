using System;
using CalcLib.Types;
using CalcLib.Engine;

namespace CalcLib.CalcVariants
{
    public class ButtonDefaultValues
    {
        private readonly ItemBase[,] _buttonItems = new ItemBase[,] { };

        public ButtonDefaultValues()
        {

            ItemBase _nnnn = NoneItem.CreateItem();

            ItemBase Clear = Item.CreateItem("C", Methods.Clear(), ArgsType.None);
            ItemBase Calc = Item.CreateItem("=", Methods.Result(), ArgsType.None);
            
            ItemBase perc = Item.CreateItem("%", Methods.Percent(), ArgsType.Two);
            ItemBase Inv = Item.CreateItem(((char)177).ToString(),Methods.Invert(),ArgsType.One);
            
            ItemBase Add = Item.CreateItem("+", Methods.Add(), ArgsType.Two);
            ItemBase Div = Item.CreateItem("/", Methods.Division(),ArgsType.Two);
            ItemBase Minus = Item.CreateItem("-", Methods.Minus(), ArgsType.Two);
            ItemBase Multi = Item.CreateItem("*", Methods.Multiply(), ArgsType.Two);

            ItemBase Comma = Item.CreateItem(",");

            ItemBase Num0 = Item.CreateItem("0", 0);
            ItemBase Num1 = Item.CreateItem("1", 1);
            ItemBase Num2 = Item.CreateItem("2", 2);
            ItemBase Num3 = Item.CreateItem("3", 3);
            ItemBase Num4 = Item.CreateItem("4", 4);
            ItemBase Num5 = Item.CreateItem("5", 5);
            ItemBase Num6 = Item.CreateItem("6", 6);
            ItemBase Num7 = Item.CreateItem("7", 7);
            ItemBase Num8 = Item.CreateItem("8", 8);
            ItemBase Num9 = Item.CreateItem("9", 9);


            _buttonItems = new ItemBase[,]
            {
                { perc, _nnnn, Clear, _nnnn },
                { _nnnn, _nnnn, _nnnn, Div },
                { Num7, Num8, Num9, Multi },
                { Num4, Num5, Num6, Minus },
                { Num1, Num2, Num3, Add },
                { Inv, Num0, Comma, Calc },
            };

            GetLengthY = _buttonItems.GetUpperBound(0);
            GetLengthX = _buttonItems.GetUpperBound(1);
            GetX = GetLengthX + 1;
        }

        internal int GetLengthY { get; }

        internal int GetLengthX { get; set; }

        public int GetX { get; }

        internal ItemBase GetItem(int y, int x)
        {
            return (ItemBase)_buttonItems.GetValue(y, x);
        }
    }
}


