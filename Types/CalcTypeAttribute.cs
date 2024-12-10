using System;

namespace LibCalc.Types
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