using LibCalc.Types;

namespace LibCalc.Engine
{
    public class ItemMethod : Item
    {
        public ItemMethod(string name) : base(name)
        {
        }

        public CalcType CalcType { get; set; }

        public Method<float> Method { get; set; }

        public ArgsType ArgType { get; set; }

        public LevelType LevelType { get; set; }

        public new Item Copy()
        {
            return CreateItem(Name, Method);
        }
    }
}