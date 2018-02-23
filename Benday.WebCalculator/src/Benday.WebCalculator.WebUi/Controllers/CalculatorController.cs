using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Benday.WebCalculator.Api;
using Benday.WebCalculator.WebUi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Benday.WebCalculator.WebUi.Controllers
{
    public class CalculatorController : Controller
    {
        private ICalculatorService _CalculatorService;

        public CalculatorController(ICalculatorService calculator)
        {
            if (calculator == null)
            {
                throw new ArgumentNullException(nameof(calculator), $"{nameof(calculator)} is null.");
            }

            _CalculatorService = calculator;
        }

        public IActionResult Index()
        {
            var model = new CalculatorViewModel();

            model.Operator = CalculatorConstants.Message_ChooseAnOperator;

            model.Operators = GetOperators();

            model.Message = String.Empty;

            model.IsResultValid = false;

            return View(model);
        }

        private List<string> GetOperators()
        {
            var operators = new List<string>();

            operators.Add(CalculatorConstants.Message_ChooseAnOperator);
            operators.Add(CalculatorConstants.OperatorAdd);
            operators.Add(CalculatorConstants.OperatorSubtract);
            operators.Add(CalculatorConstants.OperatorMultiply);
            operators.Add(CalculatorConstants.OperatorDivide);

            return operators;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Calculate(CalculatorViewModel model)
        {
            var operation = model.Operator;

            if (operation == CalculatorConstants.OperatorAdd)
            {
                model.Result = 
                    _CalculatorService.Add(
                        model.Value1, model.Value2);
                model.Message = CalculatorConstants.Message_Success;
                model.IsResultValid = true;
            }
            else if (operation == CalculatorConstants.OperatorSubtract)
            {
                model.Result =
                    _CalculatorService.Subtract(
                        model.Value1, model.Value2);
                model.Message = CalculatorConstants.Message_Success;
                model.IsResultValid = true;
            }
            else if (operation == CalculatorConstants.OperatorMultiply)
            {
                model.Result =
                    _CalculatorService.Multiply(
                        model.Value1, model.Value2);
                model.Message = CalculatorConstants.Message_Success;
                model.IsResultValid = true;
            }
            else if (operation == CalculatorConstants.OperatorDivide)
            {
                if (model.Value2 == 0d)
                {
                    model.Result = 0;
                    model.Message = CalculatorConstants.Message_CantDivideByZero;
                    model.IsResultValid = false;

                }
                else
                {
                    model.Result =
                    _CalculatorService.Divide(
                        model.Value1, model.Value2);
                    model.Message = CalculatorConstants.Message_Success;
                    model.IsResultValid = true;
                }                
            }
            else
            {
                model.IsResultValid = false;
                model.Result = 0;
                model.Message = CalculatorConstants.Message_UnknownOperatorMessage;
            }

            return View(model);
        }
    }
}