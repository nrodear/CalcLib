using System;

namespace LibCalc.Types
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