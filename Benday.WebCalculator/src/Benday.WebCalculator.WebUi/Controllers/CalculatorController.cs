using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Benday.WebCalculator.WebUi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Benday.WebCalculator.WebUi.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            var model = new CalculatorViewModel();

            model.Operator = CalculatorConstants.Message_ChooseAnOperator;

            model.Operators = GetOperators();

            return base.View(model);
        }
        private List<string> GetOperators()
        {
            var operators = new List<string>();

            operators.Add(CalculatorConstants.Message_ChooseAnOperator);
            operators.Add("Add");
            operators.Add("Subtract");
            operators.Add("Multiply");
            operators.Add("Divide");

            return operators;
        }
    }
}