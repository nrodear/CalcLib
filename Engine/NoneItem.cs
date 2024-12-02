
namespace CalcLib.Engine
{
    internal class NoneItem : Item
    {
        private NoneItem() : base("?")
        {
        }

        public static NoneItem CreateItem()
        {
            return new NoneItem();
        }
    }
}