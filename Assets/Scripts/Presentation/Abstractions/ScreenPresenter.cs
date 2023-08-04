namespace CalculatorApp.Presentation.Abstractions
{
    public abstract class ScreenPresenter<TView, TModel>  where TView : IScreenView
    {
        protected TView view;
        protected TModel model;
        
        public virtual void Initialize(TView view, TModel model)
        {
            this.view = view;
            this.model = model;
        }
    }
}
