using UnityEngine;
namespace HSRM.Core.Commands
{
    public class QuitApplicationCommand : BaseCommand
    {
        protected override void ExecuteCommand()
        {
            if (Application.platform == RuntimePlatform.WindowsPlayer)
            { 
                Application.Quit();
            }
        }
    }

}