namespace CalcLib.CalcVariants
{
    internal class ButtonsStrings
    {
        protected static readonly string[,] _buttonsStrings = new string[,]
        {
            { "%", "?", "C", "?" },
            { "?", "?", "?", "/" },
            { "7", "8", "9", "x" },
            { "4", "5", "6", "-" },
            { "1", "2", "3", "+" },
            { "?", "0", ",", "=" },
        };

        internal int GetLengthY { get; } = _buttonsStrings.GetLength(0);

        internal int GetLengthX { get; } = _buttonsStrings.GetLength(1);

        internal string[,] Get { get; } = _buttonsStrings;
    }
}
