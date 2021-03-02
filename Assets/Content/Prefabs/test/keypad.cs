using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace DE.HSRM.MI.EscapeThePyramid.DoorWithPin
{
    public class keypad : MonoBehaviour
    {

        public string password = "1234";
        public Text displayInput;
        [SerializeField] protected Animator animator = null;
        [SerializeField] protected string parameterName = string.Empty;

        private string input;
        private float numberClicked = 0;
        private float numberGuesses;

        void Start()
        {
            numberClicked = 0;
            numberGuesses = password.Length;
        }

        void Update()
        {
            if (numberClicked == numberGuesses)
            {
                if (input == password)
                {
                    showCorrect();
                    animator.SetBool(parameterName, true);
                    Debug.Log("Correct Password!");
                    input = ""; //Clear Password
                    numberClicked = 0;
                }
                else
                {
                    input = "";
                    displayInput.text = input.ToString();
                    numberClicked = 0;
                }
            }
        }

        IEnumerator showCorrect()
        {
            GameObject go = gameObject.transform.Find("EnteredValues").gameObject;
            go.GetComponent<Image>().color = Color.green;
            //var text = gameobject.getComponent<Text>();
            //text.color = new Color(0f, 110f, 5f, 0f);
            yield return new WaitForSeconds(1);
        }

        public void ValueEntered(string valueEntered)
        {
            switch (valueEntered)
            {
                case "Q":
                    numberClicked = 0;
                    input = "";
                    displayInput.text = input.ToString();
                    break;

                case "C":
                    input = "";
                    numberClicked = 0;
                    displayInput.text = input.ToString();
                    break;

                default:
                    numberClicked++;
                    input += valueEntered;
                    displayInput.text = input.ToString();
                    break;
            }

        }
    }
}
