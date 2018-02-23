using Benday.WebCalculator.Api;
using Benday.WebCalculator.WebUi;
using Benday.WebCalculator.WebUi.Controllers;
using Benday.WebCalculator.WebUi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
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
                    _SystemUnderTest = new CalculatorController(
                        new CalculatorService());
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
        public void CalculatorController_Index_Model_MessageIsInitialized()
        {
            var model =
                UnitTestUtility.GetModel<CalculatorViewModel>(
                    SystemUnderTest.Index());

            var actual = model.Message;

            var expected = String.Empty;

            Assert.AreEqual<string>(expected, actual, "Message field value was wrong.");
        }

        [TestMethod]
        public void CalculatorController_Index_Model_IsResultValidShouldBeFalse()
        {
            var model =
                UnitTestUtility.GetModel<CalculatorViewModel>(
                    SystemUnderTest.Index());

            var actual = model.IsResultValid;

            var expected = false;

            Assert.AreEqual<bool>(expected, actual, "IsResultValid field value was wrong.");
        }

        [TestMethod]
        public void CalculatorController_Index_Model_OperatorsCollectionIsPopulated()
        {
            var model =
                UnitTestUtility.GetModel<CalculatorViewModel>(
                    SystemUnderTest.Index());

            Assert.IsNotNull(model.Operators, 
                "Operators collection was null.");

            var actual = model.Operators.Select(x => x.Text).ToList();

            var expected = new List<string>();

            expected.Add(CalculatorConstants.Message_ChooseAnOperator);
            expected.Add(CalculatorConstants.OperatorAdd);
            expected.Add(CalculatorConstants.OperatorSubtract);
            expected.Add(CalculatorConstants.OperatorMultiply);
            expected.Add(CalculatorConstants.OperatorDivide);            

            CollectionAssert.AreEqual(expected, actual,
                "Wrong values in operators collection.");
        }

        [TestMethod]
        public void CalculatorController_Calculator_Add()
        {
            var model =
                UnitTestUtility.GetModel<CalculatorViewModel>(
                    SystemUnderTest.Index());

            double value1 = 2;
            double value2 = 3;
            double expected = 5;

            model.Value1 = value1;
            model.Value2 = value2;
            model.Operator = CalculatorConstants.OperatorAdd;

            var actual =
                UnitTestUtility.GetModel<CalculatorViewModel>(
                    SystemUnderTest.Calculate(model));

            Assert.IsTrue(actual.IsResultValid, "Result should be valid.");
            Assert.AreEqual<double>(expected, actual.ResultValue, "Result was wrong.");
            Assert.AreEqual<string>(CalculatorConstants.Message_Success, 
                actual.Message, "Message was wrong.");
        }

        [TestMethod]
        public void CalculatorController_Calculator_Subtract()
        {
            var model =
                UnitTestUtility.GetModel<CalculatorViewModel>(
                    SystemUnderTest.Index());

            double value1 = 2;
            double value2 = 3;
            double expected = -1;

            model.Value1 = value1;
            model.Value2 = value2;
            model.Operator = CalculatorConstants.OperatorSubtract;

            var actual =
                UnitTestUtility.GetModel<CalculatorViewModel>(
                    SystemUnderTest.Calculate(model));

            Assert.IsTrue(actual.IsResultValid, "Result should be valid.");
            Assert.AreEqual<double>(expected, actual.ResultValue, "Result was wrong.");
            Assert.AreEqual<string>(CalculatorConstants.Message_Success,
                actual.Message, "Message was wrong.");
        }

        [TestMethod]
        public void CalculatorController_Calculator_Multiply()
        {
            var model =
                UnitTestUtility.GetModel<CalculatorViewModel>(
                    SystemUnderTest.Index());

            double value1 = 2;
            double value2 = 3;
            double expected = 6;

            model.Value1 = value1;
            model.Value2 = value2;
            model.Operator = CalculatorConstants.OperatorMultiply;

            var actual =
                UnitTestUtility.GetModel<CalculatorViewModel>(
                    SystemUnderTest.Calculate(model));

            Assert.IsTrue(actual.IsResultValid, "Result should be valid.");
            Assert.AreEqual<double>(expected, actual.ResultValue, "Result was wrong.");
            Assert.AreEqual<string>(CalculatorConstants.Message_Success,
                actual.Message, "Message was wrong.");
        }

        [TestMethod]
        public void CalculatorController_Calculator_Divide()
        {
            var model =
                UnitTestUtility.GetModel<CalculatorViewModel>(
                    SystemUnderTest.Index());

            double value1 = 8;
            double value2 = 4;
            double expected = 2;

            model.Value1 = value1;
            model.Value2 = value2;
            model.Operator = CalculatorConstants.OperatorDivide;

            var actual =
                UnitTestUtility.GetModel<CalculatorViewModel>(
                    SystemUnderTest.Calculate(model));

            Assert.IsTrue(actual.IsResultValid, "Result should be valid.");
            Assert.AreEqual<double>(expected, actual.ResultValue, "Result was wrong.");
            Assert.AreEqual<string>(CalculatorConstants.Message_Success,
                actual.Message, "Message was wrong.");
        }

        [TestMethod]
        public void CalculatorController_Calculator_DivideByZero()
        {
            var model =
                UnitTestUtility.GetModel<CalculatorViewModel>(
                    SystemUnderTest.Index());

            double value1 = 8;
            double value2 = 0;
            
            model.Value1 = value1;
            model.Value2 = value2;
            model.Operator = CalculatorConstants.OperatorDivide;

            var actual =
                UnitTestUtility.GetModel<CalculatorViewModel>(
                    SystemUnderTest.Calculate(model));

            Assert.IsFalse(actual.IsResultValid, "Result should not be valid.");
            Assert.AreEqual<double>(0, actual.ResultValue, "Result was wrong.");
            Assert.AreEqual<string>(CalculatorConstants.Message_CantDivideByZero,
                actual.Message, "Message was wrong.");
        }
    }
}
