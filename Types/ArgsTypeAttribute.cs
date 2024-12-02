using System;
using CalcLib.Types;

namespace CalcLib.Types
{
    internal class ArgsTypeAttribute : Attribute
    {
        public ArgsType ArgType;
        public ArgsTypeAttribute( ArgsType argsType)
        {
            ArgType =argsType;
        }
    }
}