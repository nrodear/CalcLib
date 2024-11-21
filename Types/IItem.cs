namespace CalcLib.Types
{
    /// <summary>
    /// CalcType defines types of buttons from calc
    /// </summary>
    public enum CalcType
    {
        None,
        Value,
        Func
    }


    /// <summary>
    /// 
    /// </summary>
    public interface IItem
    {
        string Name { get; }
        CalcType CalcType { get; }
    }
}