using CalculatorApp.Domain.Calculator;
using CalculatorApp.Presentation.Abstractions;
using System.Collections.Generic;


namespace CalculatorApp.Presentation.MainScreen.Abstractions
{
    public interface IMainScreenView : IScreenView
    {
        void DisplayResult(MathOperationResult result);
        void RestoreState(string state);
        void RestoreHistory(List<MathOperationResult> history);
    }
}
