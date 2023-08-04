using System.Collections.Generic;


namespace CalculatorApp.Domain.Calculator
{
    public class EquationParserResult
    {
        public string Alias { get; set; }
        public List<string> Parameters { get; set; } = new List<string>();
    }
}
