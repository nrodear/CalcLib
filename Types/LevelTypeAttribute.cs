using System;

namespace CalcLib.Types
{
    internal class LevelTypeAttribute : Attribute
    {
        public LevelType LevelType;
        public LevelTypeAttribute(LevelType level)
        {
            LevelType = level;
        }
    }
}