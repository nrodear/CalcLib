using System;
using System.Collections.Generic;
using CalcLib.Types;

namespace CalcLib.Engine
{
    internal class Core
    {
        public List<IItem> Stack = new List<IItem>();

        public Core()
        {
        }

        public Core(List<IItem> stack)
        {
            if (stack != null)
            {
                this.Stack = stack;
            }
        }


        public void Add(FunctionItem item)
        {
            Stack.Add(item);
        }

        public string TaskToString()
        {
            var result = "";
            foreach (var item in Stack)
            {
                if (item is FunctionItem castedItem)
                {
                    switch (castedItem.CalcType)
                    {
                        case CalcType.Value:
                            result += castedItem.Value.ToString();
                            break;
                        case CalcType.Func:
                            result += castedItem.Name;
                            break;
                        case CalcType.None:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            return result;
        }

        public void Process()
        {
            throw new NotImplementedException();
        }
    }
}