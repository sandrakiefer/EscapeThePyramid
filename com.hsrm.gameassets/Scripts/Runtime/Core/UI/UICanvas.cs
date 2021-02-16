using UnityEngine;
using UnityEngine.Events;

namespace HSRM.Core.UI
{
    public class UICanvas : MonoBehaviour
    {
        public enum ViewState { Show, Hide, Visible, Hidden, Undefined };

        [SerializeField] private ViewState startState = ViewState.Hidden;

        public UnityEvent OnShow = null;
        public UnityEvent OnHide = null;
        public UnityEvent OnSetVisible = null;
        public UnityEvent OnSetHidden = null;

        private ViewState viewState = ViewState.Undefined;

        public ViewState CurrentViewState => viewState;

        private void Start()
        {
            SetState(startState);
        }

        private void SetState(ViewState state)
        {
            switch (state)
            {
                case ViewState.Show:
                    Show();
                    break;
                case ViewState.Hide:
                    Hide();
                    break;
                case ViewState.Visible:
                    SetVisible();
                    break;
                case ViewState.Hidden:
                    SetHidden();
                    break;
            }
        }

        public virtual void Show()
        {
            if (viewState != ViewState.Show)
            {
                viewState = ViewState.Show;
                OnShow?.Invoke();
            }
        }

        public void ShowDelayed(float delay)
        {
            Invoke(nameof(Show), delay);
        }

        public virtual void Hide()
        {
            if (viewState != ViewState.Hide)
            {
                viewState = ViewState.Hide;
                OnHide?.Invoke();
            }
        }

        public void HideDelayed(float delay)
        {
            Invoke(nameof(Hide), delay);
        }

        public virtual void SetVisible()
        {
            if (viewState != ViewState.Visible)
            {
                viewState = ViewState.Visible;
                OnSetVisible?.Invoke();
            }
        }

        public void SetVisibleDelayed(float delay)
        {
            Invoke(nameof(SetVisible), delay);
        }

        public virtual void SetHidden()
        {
            if (viewState != ViewState.Hidden)
            {
                viewState = ViewState.Hidden;
                OnSetHidden?.Invoke();
            }
        }

        public void SetHiddenDelayed(float delay)
        {
            Invoke(nameof(SetHidden), delay);
        }
    }
}