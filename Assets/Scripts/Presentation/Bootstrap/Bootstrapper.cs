using CalculatorApp.Data.Repositories;
using CalculatorApp.Data.Storage;
using CalculatorApp.Domain.Calculator;
using CalculatorApp.Presentation.MainScreen;
using UnityEngine;


namespace CalculatorApp.Presentation.Bootstrap
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private MainScreenView mainScreenView;


        private void Start()
        {
            //TODO: Use DI
            CalculationService calculationService = new CalculationService(new EquationParser());
            calculationService.AddProcessor(new AdditionProcessor());
                //.AddProcessor(new SubtractionProcessor());
            IMainScreenDataRepository mainScreenDataRepository = new MainScreenDataRepository(new PrefsStorage());
            
            
            // TODO: Move to some UiManager
            MainScreenPresenter mainScreenPresenter = new MainScreenPresenter(calculationService, mainScreenDataRepository);
            MainScreenModel mainScreenModel = new MainScreenModel();
            mainScreenPresenter.Initialize(mainScreenView, mainScreenModel);
            mainScreenView.Initialize(mainScreenPresenter, mainScreenModel);
            mainScreenView.Show();
        }
    }
}
