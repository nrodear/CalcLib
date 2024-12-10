
namespace LibCalc.Engine
{
    public class ItemValue : Item
    {
        public ItemValue(string name, float value) : base(name)
        {
            Value = value;
        }

        public float Value { get; set; }

        public new Item Copy()
        {
            return CreateItem(Name, Value);
        }
    }
}