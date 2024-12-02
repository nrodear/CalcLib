using CalcLib.Types;
using CalcLib.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CalcLib.EngineTests
{
    [TestClass]
    public class ValuesTests
    {
        // x²
        [TestMethod]
        public void GetValueUsingDelegates_ProcessSquare_One()
        {
            var value = Item.CreateItem("5", 5);
            var method = Item.CreateItem("²", Methods.Square());

            Values.Clear();
            Values.Add(value);
            Values.Add(method);

            var actual = Values.Process();
            Assert.IsNotNull(actual);
            Assert.AreEqual(25, actual);
        }

        // 5 + 5
        [TestMethod]
        public void GetValueUsingDelegates_ArgTypTwo()
        {
            var value = Item.CreateItem("5", 5);
            var methodAdd = Item.CreateItem("+", Methods.Add());

            Values.Clear();
            Values.Add(value);
            Values.Add(methodAdd);
            Values.Add(value);

            var actual = Values.Process();
            Assert.IsNotNull(actual);
            Assert.AreEqual(10, actual);
        }


        // 5 + 5 +5
        [TestMethod]
        public void GetValueUsingDelegates_ArgTypTwoTwice()
        {
            var value = Item.CreateItem("5", 5);
            var methodAdd = Item.CreateItem("+", Methods.Add());

            Values.Clear();
            Values.Add(value);
            Values.Add(methodAdd);
            Values.Add(value);
            Values.Add(methodAdd);
            Values.Add(value);

            var actual = Values.Process();
            Assert.IsNotNull(actual);
            Assert.AreEqual(15, actual);
        }


        // 100 + 10%
        [TestMethod]
        public void GetValueUsingDelegates_ProcessPercent()
        {
            var value100 = Item.CreateItem("1", 100);
            var value10 = Item.CreateItem("1", 10);
            var methodPlus = Item.CreateItem("+", Methods.Add());
            var methodPercent = Item.CreateItem("%", Methods.Percent());

            Values.Clear();
            Values.Add(value100);
            Values.Add(methodPlus);
            Values.Add(value10);
            Values.Add(methodPercent);

            var actual = Values.Process();
            Assert.IsNotNull(actual);
            Assert.AreEqual(110, actual);
        }

        [TestMethod]
        public void GetValueUsingDelegates_Attributes()
        {
            var actual = Item.CreateItem("c", Methods.Percent());

            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void GetItemInstance_TypeOf()
        {
            ItemMethod actual = (ItemMethod)Item.CreateItem("c", Methods.Percent());

            Assert.IsNotNull(actual);
        }
    }
}