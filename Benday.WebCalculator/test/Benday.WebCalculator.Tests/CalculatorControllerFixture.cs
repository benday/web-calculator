using Benday.WebCalculator.WebUi;
using Benday.WebCalculator.WebUi.Controllers;
using Benday.WebCalculator.WebUi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Benday.WebCalculator.Tests
{
    [TestClass]
    public class CalculatorControllerFixture
    {
        [TestInitialize]
        public void OnTestInitialize()
        {
            _SystemUnderTest = null;
        }

        private CalculatorController _SystemUnderTest;

        private CalculatorController SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new CalculatorController();
                }

                return _SystemUnderTest;
            }
        }

        [TestMethod]
        public void CalculatorController_Index_ModelIsNotNull()
        {
            var actual =
                UnitTestUtility.GetModel<CalculatorViewModel>(
                    SystemUnderTest.Index());

            Assert.IsNotNull(actual, "Model was null.");
        }

        [TestMethod]
        public void CalculatorController_Index_Model_Value1IsInitialized()
        {
            var model =
                UnitTestUtility.GetModel<CalculatorViewModel>(
                    SystemUnderTest.Index());

            var actual = model.Value1;

            var expected = 0d;

            Assert.AreEqual<double>(expected, actual, "Value1 field value was wrong.");
        }

        [TestMethod]
        public void CalculatorController_Index_Model_Value2IsInitialized()
        {
            var model =
                UnitTestUtility.GetModel<CalculatorViewModel>(
                    SystemUnderTest.Index());

            var actual = model.Value2;

            var expected = 0d;

            Assert.AreEqual<double>(expected, actual, "Value2 field value was wrong.");
        }

        [TestMethod]
        public void CalculatorController_Index_Model_OperatorIsInitialized()
        {
            var model =
                UnitTestUtility.GetModel<CalculatorViewModel>(
                    SystemUnderTest.Index());

            var actual = model.Operator;

            var expected = CalculatorConstants.Message_ChooseAnOperator;

            Assert.AreEqual<string>(expected, actual, "Operator field value was wrong.");
        }

        [TestMethod]
        public void CalculatorController_Index_Model_OperatorsCollectionIsPopulated()
        {
            var model =
                UnitTestUtility.GetModel<CalculatorViewModel>(
                    SystemUnderTest.Index());

            var actual = model.Operators;

            var expected = new List<string>();

            expected.Add(CalculatorConstants.Message_ChooseAnOperator);
            expected.Add("Add");
            expected.Add("Subtract");
            expected.Add("Multiply");
            expected.Add("Divide");

            Assert.IsNotNull(actual, "Operators collection was null.");

            CollectionAssert.AreEqual(expected, actual,
                "Wrong values in operators collection.");
        }
    }
}
