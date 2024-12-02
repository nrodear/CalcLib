namespace CalcLib.Types
{
    /// <summary>
    /// 
    /// </summary>
    public enum LevelType
    {
        // cls or result
        None = -1,

        // x²
        // Execute instant with last value
        Instant = 0,
        // 100 + 20%
        // Execute with last value but is "dependent" on previous value
        One = 1,
        // 1 + 1 
        Two = 2,

    }
}