using System;

namespace CalcLib.Types
{
    public class LevelTypeAttribute : Attribute
    {
        public LevelType LevelType;
        public LevelTypeAttribute(LevelType level)
        {
            LevelType = level;
        }
    }
}