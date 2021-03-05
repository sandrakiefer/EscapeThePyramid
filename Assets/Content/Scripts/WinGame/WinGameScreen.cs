using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using HSRM.Core.UI;

namespace DE.HSRM.MI.EscapeThePyramid.WinGame
{
    public class WinGameScreen : MonoBehaviour
    {

        [SerializeField] private UICanvas canvas = null;
    
        public void Show()
        {
            StartCoroutine(ending());
        }

        IEnumerator ending()
        {
            canvas.Show();
            yield return new WaitForSeconds(10);
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

    }
}
