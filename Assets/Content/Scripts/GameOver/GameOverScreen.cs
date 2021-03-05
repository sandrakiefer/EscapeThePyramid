using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using HSRM.Core.UI;

namespace DE.HSRM.MI.EscapeThePyramid.GameOver
{
    public class GameOverScreen : MonoBehaviour
    {

        [SerializeField] private UICanvas canvas = null;
        public Text reasonText;
    
        public void Setup(string reason)
        {
            canvas.Show();
            reasonText.text = reason;
        }

        public void RestartButton()
        {
            SceneManager.LoadScene("EscapeThePyramid");
        }

        public void QuitButton()
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

    }
}
