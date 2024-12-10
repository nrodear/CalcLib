﻿using LibCalc.Engine;

namespace LibCalc.Types
{
    public interface IButtonValues
    {
        int GetLengthY { get; }
        int GetLengthX { get; set; }
        int GetX { get; }
        Item GetItem(int y, int x);
    }
}