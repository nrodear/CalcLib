using System;
using System.Windows;


namespace CalcLib.Types
{
    internal class FunctionItem : IItem
    {
        public string Name { get; }
        public int Value { get; }
        public CalcType CalcType { get; }

        public Func<object, RoutedEventArgs> Method { get; }

        private FunctionItem(string name, int value, Func<object, RoutedEventArgs> method, CalcType calcType)
        {
            Name = name;
            CalcType = calcType;
            Value = value;
            Method = method;
        }

        internal static FunctionItem CreateItem(string name, Func<object, RoutedEventArgs> method)
        {
            return new FunctionItem(name, 0, method, CalcType.Func);
        }

        internal static FunctionItem CreateItem(string name, int value)
        {
            return new FunctionItem(name, value, null, CalcType.Value);
        }
    }
}