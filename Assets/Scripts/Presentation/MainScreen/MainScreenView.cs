using System;
using System.Collections.Generic;
using System.Text;
using CalculatorApp.Domain.Calculator;
using CalculatorApp.Presentation.Abstractions;
using CalculatorApp.Presentation.MainScreen.Abstractions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace CalculatorApp.Presentation.MainScreen
{
    public class MainScreenView : ScreenView<IMainScreenPresenter, MainScreenModel>, IMainScreenView
    {
        [SerializeField] private TMP_InputField equationInput;
        [SerializeField] private TMP_Text historyText;
        [SerializeField] private Button resultButton;

        private const string EquationSymbol = "=";
        private const string ErrorText = "Error";


        public override void Initialize(IMainScreenPresenter presenter, MainScreenModel model)
        {
            base.Initialize(presenter, model);
            resultButton.onClick.AddListener(OnResultButtonClick);
            RestoreState(model.InputValue);
            RestoreHistory(model.History);
        }


        public void RestoreState(string state)
        {
            equationInput.text = state;
        }


        public void RestoreHistory(List<MathOperationResult> history)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = history.Count - 1; i >= 0; i--)
            {
                var result = history[i];
                if (sb.Length > 0)
                {
                    sb.Append(Environment.NewLine);
                }

                sb.Append(result.Request);
                sb.Append(EquationSymbol);
                sb.Append(result.IsValid ? result.Answer : ErrorText);
            }

            historyText.text = sb.ToString();
        }


        public void DisplayResult(MathOperationResult result)
        {
            string newEntry = $"{result.Request}{EquationSymbol}{(result.IsValid ? result.Answer : ErrorText)}";
            historyText.text = $"{newEntry}{Environment.NewLine}{historyText.text}";
        }


        private void OnResultButtonClick()
        {
            string inputValue = equationInput.text;
            presenter.OnResultRequested(inputValue);
            equationInput.text = "";
        }


        private void OnDisable()
        {
            string inputValue = equationInput.text;
            presenter.SaveInputState(inputValue);
        }
    }
}
