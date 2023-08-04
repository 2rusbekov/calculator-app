using System;
using CalculatorApp.Presentation.Abstractions;


namespace CalculatorApp.Presentation.MainScreen.Abstractions
{
    public interface IMainScreenPresenter : IScreenPresenter
    {
        void OnResultRequested(string inputValue);
        void SaveInputState(string inputValue);
    }
}
