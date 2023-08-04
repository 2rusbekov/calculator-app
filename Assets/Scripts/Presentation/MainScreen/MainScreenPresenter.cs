using CalculatorApp.Domain.Calculator;
using CalculatorApp.Domain.Calculator.Abstractions;
using CalculatorApp.Presentation.Abstractions;
using CalculatorApp.Presentation.MainScreen.Abstractions;
using System.Collections.Generic;
using CalculatorApp.Data;
using CalculatorApp.Data.Repositories;


namespace CalculatorApp.Presentation.MainScreen
{
    public class MainScreenPresenter : ScreenPresenter<IMainScreenView, MainScreenModel>, IMainScreenPresenter
    {
        //TODO: Use DI
        private ICalculationService calculationService;
        private IMainScreenDataRepository dataRepository;

        public MainScreenPresenter(ICalculationService calculationService, IMainScreenDataRepository dataRepository)
        {
            this.calculationService = calculationService;
            this.dataRepository = dataRepository;
        }


        public override void Initialize(IMainScreenView view, MainScreenModel model)
        {
            base.Initialize(view, model);
            LoadPreviosState();
        }


        public void OnResultRequested(string inputValue)
        {
            if (string.IsNullOrEmpty(inputValue))
            {
                return;
            }

            MathOperationResult result = calculationService.ParseAndCalculate(inputValue);
            dataRepository.SaveHistoryEntry(new HistoryData()
            {
                request = result.Request,
                answer = result.Answer,
            });
            view.DisplayResult(result);
        }


        public void SaveInputState(string inputValue)
        {
            model.InputValue = inputValue;
            dataRepository.SaveInputState(new InputStateData()
            {
                inputValue = inputValue
            });
        }


        private void LoadPreviosState()
        {
            var stateData = dataRepository.GetInputState();
            var history = dataRepository.GetHistory();
            model.InputValue = stateData.inputValue;

            model.History = new List<MathOperationResult>();
            
            if (history != null)
            {
                foreach (var entry in history)
                {
                    model.History.Add(new MathOperationResult()
                    {
                        Request = entry.request,
                        IsValid = !string.IsNullOrEmpty(entry.answer),
                        Answer = entry.answer
                    });
                }
            }
        }
    }
}
