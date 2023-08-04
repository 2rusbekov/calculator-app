using CalculatorApp.Domain.Calculator;
using System.Collections.Generic;


namespace CalculatorApp.Presentation.MainScreen
{
    public class MainScreenModel
    {
        public string InputValue { get; set; }
        public List<MathOperationResult> History { get; set; }
    }
}
