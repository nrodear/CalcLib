using System;
using System.Linq;
using System.Reflection;
using CalcLib.Types;

namespace CalcLib.Engine
{
    public class Item
    {
        public string Name { get; set; }

        private static ArgsType GetArgsTypeAttribute(Method<float> method)
        {
            var attrs = method.Method.GetCustomAttributes<ArgsTypeAttribute>();
            var item = attrs.Select(x => x).First();
            return item.ArgType;
        }

        private static LevelType GetLevelTypeAttribute(Method<float> method)
        {
            var attrs = method.Method.GetCustomAttributes<LevelTypeAttribute>();
            var item = attrs.Select(x => x).First();
            return item.LevelType;
        }

        private static CalcType GetCalcTypeAttribute(Method<float> method)
        {
            var attrs = method.Method.GetCustomAttributes<CalcTypeAttribute>();
            var item = attrs.Select(x => x).First();
            return item.CalcType;
        }

        protected Item(string name)
        {
            Name = name;
        }

        public static Item CreateItem(string name, Method<float> method)
        {
            var item = new ItemMethod(name)
            {
                ArgType = GetArgsTypeAttribute(method),
                LevelType = GetLevelTypeAttribute(method),
                CalcType = GetCalcTypeAttribute(method),
                Method = method
            };
            return item;
        }

        public static Item CreateItem(string name, float value)
        {
            var item = new ItemValue(name, value);
            return item;
        }

        public Item Copy()
        {
            if (GetType() == typeof(ItemValue))
            {
                return ((ItemValue)this).Copy();
            }

            if (GetType() == typeof(ItemMethod))
            {
                return ((ItemMethod)this).Copy();
            }
            throw new Exception("err");
        }
    }
}