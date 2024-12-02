
namespace CalcLib.Engine
{
    public class NoneItem : Item
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