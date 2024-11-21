using CalcLib.Engine;
using CalcLib.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalcLib.EnginTests
{
    [TestClass]
    internal class CoreTests
    {
        [TestMethod]
        public void CoreTest()
        {
            var coreTest = new Core(null);
            Assert.IsNotNull(coreTest);
            Assert.IsNotNull(coreTest.Stack);
        }


        [TestMethod]
        public void Core_AddValue_Test()
        {
            var value5 = FunctionItem.CreateItem("5", 5);
            var valueAdd = FunctionItem.CreateItem("+", null);
            var valueResult = FunctionItem.CreateItem("=", null);

            var coreTest = new Core(null);

            coreTest.Add(value5);
            coreTest.Add(valueAdd);
            coreTest.Add(value5);
            coreTest.Add(valueResult);

            coreTest.Process();
            string task = coreTest.TaskToString();

            Assert.IsFalse("5+5=10" == task);
            Assert.IsNotNull(coreTest.Stack);
        }
    }
}