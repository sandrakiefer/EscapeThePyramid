using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DE.HSRM.MI.EscapeThePyramid.GameOver;

namespace DE.HSRM.MI.EscapeThePyramid.Timer
{
    public class TimerCountdown : MonoBehaviour
    {

        public GameObject textDisplay;
        [Range(0, 59)]
        public int minutesLeft = 1;
        [Range(0, 59)]
        public int secondsLeft = 30;
        public bool takingAway = false;

        void Start()
        {
            textDisplay.GetComponent<Text>().text = "00:00";
        }

        void Update()
        {
            if (takingAway == false && secondsLeft > 0)
            {
                StartCoroutine(TimerTake());
            } 
        }

        IEnumerator TimerTake()
        {
            takingAway = true;
            yield return new WaitForSeconds(1);
            secondsLeft -= 1;
            if (secondsLeft % 60 == 0)
            {
                if (minutesLeft > 0)
                {
                    if (minutesLeft < 10)
                    {
                        textDisplay.GetComponent<Text>().text = "0" + minutesLeft + ":00";
                    }
                    else
                    {
                        textDisplay.GetComponent<Text>().text = minutesLeft + ":00";
                    }
                    minutesLeft -= 1;
                    secondsLeft = 60;
                } 
                else
                {
                    textDisplay.GetComponent<Text>().text = "00:00";
                    GameObject.Find("Core/UI/GameOver/Background").GetComponent<GameOverScreen>().Setup("Your time is up ...");
                }
            } 
            else
            {
                if (secondsLeft < 10)
                {
                    if (minutesLeft < 10)
                    {
                        textDisplay.GetComponent<Text>().text = "0" + minutesLeft + ":0" + secondsLeft;
                    }
                    else
                    {
                        textDisplay.GetComponent<Text>().text = minutesLeft + ":0" + secondsLeft;
                    }
                }
                else
                {
                    if (minutesLeft < 10)
                    {
                        textDisplay.GetComponent<Text>().text = "0" + minutesLeft + ":" + secondsLeft;
                    }
                    else
                    {
                        textDisplay.GetComponent<Text>().text = minutesLeft + ":" + secondsLeft;
                    }
                }
            }
            takingAway = false;
        }

    }
}
