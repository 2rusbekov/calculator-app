using UnityEngine;


namespace CalculatorApp.Presentation.Abstractions
{
    public abstract class ScreenView<TPresenter, TModel> : MonoBehaviour where TPresenter : IScreenPresenter
    {
        public bool IsActive { get; protected set; }
        
        protected TPresenter presenter;
        protected TModel model;
        
        
        public virtual void Initialize(TPresenter presenter, TModel model)
        {
            this.presenter = presenter;
            this.model = model;
        }


        public virtual void Show()
        {
            IsActive = true;
            gameObject.SetActive(true);
        }


        public virtual void Hide()
        {
            IsActive = false;
            gameObject.SetActive(false);
        }
    }
}
