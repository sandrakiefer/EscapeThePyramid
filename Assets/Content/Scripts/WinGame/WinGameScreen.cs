using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using HSRM.Core.UI;
using DE.HSRM.MI.skief.EscapeThePyramid.Timer;

namespace DE.HSRM.MI.skief.EscapeThePyramid.WinGame
{
    public class WinGameScreen : MonoBehaviour
    {

        [SerializeField] private UICanvas canvas = null;
        public TimerCountdown timer;

        public void Show()
        {
            StartCoroutine(ending());
        }

        IEnumerator ending()
        {
            timer.playing = false;
            canvas.Show();
            yield return new WaitForSeconds(10);
            SceneManager.LoadScene(0);
        }

    }
}
