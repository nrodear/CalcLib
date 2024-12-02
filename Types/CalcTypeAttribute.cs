using System;

namespace CalcLib.Types
{
    public class CalcTypeAttribute : Attribute
    {
        public CalcType CalcType;
        public CalcTypeAttribute(CalcType calcType)
        {
            CalcType = calcType;
        }
    }
}