using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using HSRM.Core.UI;

namespace DE.HSRM.MI.EscapeThePyramid.DoorWithPin
{
    public class PinLockController : MonoBehaviour
    {

        public string password = "1234";
        public Text displayInput;
        [SerializeField] protected Animator animator = null;
        [SerializeField] protected string parameterName = string.Empty;

        private string input;
        private float numberClicked = 0;
        private float numberGuesses;
        private Color baseColor;
        private GameObject go;

        void Start()
        {
            numberClicked = 0;
            numberGuesses = password.Length;
            go = gameObject.transform.Find("Background").gameObject;
            baseColor = go.GetComponent<Image>().color;
        }

        void Update()
        {
            if (numberClicked == numberGuesses)
            {
                if (input == password)
                {
                    StartCoroutine(showCorrect());
                }
                else
                {
                    StartCoroutine(showWrong());
                }
            }
        }

        public static void ChangeLayers(GameObject go, int layer)
        {
            go.layer = layer;
            foreach (Transform child in go.transform)
            {
                ChangeLayers(child.gameObject, layer);
            }
        }

        private IEnumerator showCorrect()
        {
            go.GetComponent<Image>().color = new Color(0.0824f, 0.7059f, 0f, 0.3f);
            yield return new WaitForSeconds(0.5f);
            go.GetComponent<Image>().color = baseColor;
            input = "";
            numberClicked = 0;
            GetComponent<UICanvas>().SetHidden();
            ChangeLayers(GameObject.Find("PinLock"), 0);
            animator.SetBool(parameterName, true);
        }

        private IEnumerator showWrong()
        {
            go.GetComponent<Image>().color = new Color(0.7059f, 0.1647f, 0f, 0.3f);
            yield return new WaitForSeconds(0.5f);
            go.GetComponent<Image>().color = baseColor;
            input = "";
            numberClicked = 0;
            displayInput.text = input.ToString();
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
