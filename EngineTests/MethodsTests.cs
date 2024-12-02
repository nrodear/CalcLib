using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalcLib.Engine;

namespace CalcLib.EngineTests
{
    [TestClass]

    public class MethodsTests
    {
        [TestMethod]
        public void Methods_allTest()
        {
            Methods.Add().Invoke(new float[] {1,1 });
            Methods.Division().Invoke(new float[] { 1, 1 });
            Methods.Invert().Invoke(new float[] { 1});
            Methods.Minus().Invoke(new float[] { 1, 1 });
            Methods.Multiply().Invoke(new float[] { 1, 1 });
            Methods.Percent().Invoke(new float[] { 1, 1 });
            
            Methods.Sqrt().Invoke(new float[] { 1});
            Methods.Square().Invoke(new float[] {1 });

            Methods.Clear().Invoke(new float[] { });
            Methods.Result().Invoke(new float[] { });
        }

        [TestMethod]
        public void Methods_NoneTest()
        {
            Methods.Clear().Invoke(new float[] { });
            Methods.Result().Invoke(new float[] { });
        }


    }
}