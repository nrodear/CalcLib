
namespace CalcLib.Types
{
    internal class NoneItem : IItem
    {
        public string Name { get; }
        public CalcType CalcType { get; }
        public string Value { get; }

        private NoneItem()
        {
            CalcType = CalcType.None;
            Name = "?";
            Value = "?";
        }

        public static NoneItem CreateItem()
        {
            return new NoneItem();
        }
    }
}