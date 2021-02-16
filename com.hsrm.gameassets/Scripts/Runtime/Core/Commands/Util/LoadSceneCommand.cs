using UnityEngine;
using UnityEngine.SceneManagement;

namespace HSRM.Core.Commands
{
    public class LoadSceneCommand : BaseCommand
    {
        [SerializeField] private int sceneIndex = 1;
        [SerializeField] private LoadSceneMode loadSceneMode = LoadSceneMode.Single;

        protected override void ExecuteCommand()
        {
            CanExecute = false;
            SceneManager.LoadScene(sceneIndex, loadSceneMode);
        }

    }
}
