using System.Collections.Generic;


namespace CalculatorApp.Domain.Calculator.Abstractions
{
    public interface IEquationParser
    {
        void BuildExpression(IEnumerable<MathOperationPattern> expressions);
        EquationParserResult Parse(string equation);
    }
}
