using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seng.Mathematics;

namespace Tests.MathematicsTests
{
    [TestClass]
    public class EvaluatorTests
    {
        [TestMethod]
        public void EvaluateTest()
        {
            var expression = "2 + 3 *   10 - 4 / 2 +    4 * 3";
            var expectedResult = 42;
            var actualResult = SMath.Evaluate(expression);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
