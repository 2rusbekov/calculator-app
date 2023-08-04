using UnityEngine;


namespace CalculatorApp.Widgets
{
    public class HeightFitter : MonoBehaviour
    {
        [SerializeField] private RectTransform reference;
        [SerializeField] private float minHeight;
        [SerializeField] private float maxHeight;

        private RectTransform rect;

        private RectTransform Rect => rect ? rect : rect = transform as RectTransform;


        private void OnEnable()
        {
            if (Rect == null)
            {
                enabled = false;
                return;
            }

            FitSize();
        }


        private void Update()
        {
            //TODO: Move from Update. `hasChanged` will be true every frame if reference has a LayoutGroup.
            if (reference.hasChanged)
            {
                FitSize();
            }
        }


        public void FitSize()
        {
            float size = Mathf.Clamp(reference.sizeDelta.y, minHeight, maxHeight);
            Rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size);
        }
    }
}
