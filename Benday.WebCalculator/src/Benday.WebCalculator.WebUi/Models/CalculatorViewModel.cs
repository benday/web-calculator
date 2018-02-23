using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benday.WebCalculator.WebUi.Models
{
    public class CalculatorViewModel
    {
        public double Value1 { get; set; }
        public double Value2 { get; set; }
        public double Result { get; set; }
        public List<string> Operators { get; set; }
        public string Operator { get; set; }
        public string Message { get; set; }
        public bool IsResultValid { get; set; }
    }
}
