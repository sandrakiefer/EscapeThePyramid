using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DE.HSRM.MI.skief.EscapeThePyramid.OpeningText
{
    public class TypewriterEffect : MonoBehaviour
    {

        public TextMeshProUGUI textDisplay;
        [SerializeField] private Canvas canvas = null;
        public string[] sentences;
        public float typingSpeed;

        void Start()
        {
            StartCoroutine(Type());
        }

        IEnumerator Type()
        {
            yield return new WaitForSeconds(1.5f);
            for(int i = 0; i < sentences.Length; i++)
            {
                foreach(char letter in sentences[i].ToCharArray())
                {
                    textDisplay.text += letter;
                    yield return new WaitForSeconds(typingSpeed);
                }
                textDisplay.text += "\n";
            }
            yield return new WaitForSeconds(3);
            textDisplay.text = "";
            canvas.enabled = false;
        }

    }
}
