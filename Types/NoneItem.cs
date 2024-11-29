
namespace CalcLib.Types
{
    internal class NoneItem : ItemBase
    {
        private NoneItem()
        {
            CalcType = CalcType.None;
            Name = "?";
            Value = -1;
        }

        public static NoneItem CreateItem()
        {
            return new NoneItem();
        }
    }
}