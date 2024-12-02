using System;

namespace CalcLib.Types
{
    public class ArgsTypeAttribute : Attribute
    {
        public ArgsType ArgType;
        public ArgsTypeAttribute( ArgsType argsType)
        {
            ArgType =argsType;
        }
    }
}