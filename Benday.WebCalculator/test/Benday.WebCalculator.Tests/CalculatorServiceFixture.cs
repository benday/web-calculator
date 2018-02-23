using Benday.WebCalculator.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Benday.WebCalculator.Tests
{
    [TestClass]
    public class CalculatorServiceFixture
    {
        [TestInitialize]
        public void OnTestInitialize()
        {
            _SystemUnderTest = null;
        }

        private CalculatorService _SystemUnderTest;
        public CalculatorService SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new CalculatorService();
                }

                return _SystemUnderTest;
            }
        }

        [TestMethod]
        public void CalculatorService_Add()
        {
            double value1 = 1;
            double value2 = 2;

            double expected = 3;

            double actual = SystemUnderTest.Add(value1, value2);

            Assert.AreEqual<double>(expected, actual, "Wrong result.");
        }
    }
}
