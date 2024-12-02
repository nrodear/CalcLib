using System;
using CalcLib.Types;

namespace CalcLib.Types
{
    internal class CalcTypeAttribute : Attribute
    {
        public CalcType CalcType;
        public CalcTypeAttribute(CalcType calcType)
        {
            CalcType = calcType;
        }
    }
}