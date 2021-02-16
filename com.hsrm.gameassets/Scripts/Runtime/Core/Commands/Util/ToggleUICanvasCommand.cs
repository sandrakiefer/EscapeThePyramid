using HSRM.Core.UI;
using UnityEngine;
namespace HSRM.Core.Commands
{
    public class ToggleUICanvasCommand : BaseCommand
    {
        [SerializeField] private UICanvas canvas = null;

        public override bool CanExecute { 
            get => base.CanExecute && canvas != null; 
            set => base.CanExecute = value; 
        }

        protected override void ExecuteCommand()
        {
            switch (canvas.CurrentViewState)
            {
                case UICanvas.ViewState.Show:
                    canvas.Hide();
                    break;
                case UICanvas.ViewState.Hide:
                    canvas.Show();
                    break;
                case UICanvas.ViewState.Visible:
                    canvas.SetHidden();
                    break;
                case UICanvas.ViewState.Hidden:
                    canvas.SetVisible();
                    break;
            }
        }
    }

}