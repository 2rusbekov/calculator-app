using System.Collections.Generic;


namespace CalculatorApp.Domain.Calculator.Abstractions
{
    public interface IMathOperationProcessor
    {
        string Alias { get; }
        string Pattern { get; }


        MathOperationResult Process(List<string> parameters);
    }
}
