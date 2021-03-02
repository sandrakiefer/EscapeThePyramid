using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DE.HSRM.MI.EscapeThePyramid.DoorWithPin
{
    public class CodeLock : MonoBehaviour
    {

        int codeLength;
        int placeInCode;

        public string code = "";
        public string attemptedCode;

        [SerializeField] protected Animator animator = null;
        [SerializeField] protected string parameterName = string.Empty;

        private void Start()
        {
            codeLength = code.Length;
        }

        void CheckCode()
        {
            if(attemptedCode == code)
            {
                animator.SetBool(parameterName, true);
            } else
            {
                Debug.Log("Wrong Code");
            }
        }

        public void SetValue(string value)
        {
            placeInCode++;

            if(placeInCode <= codeLength)
            {
                attemptedCode += value;
            }

            if(placeInCode == codeLength)
            {
                CheckCode();
                attemptedCode = "";
                placeInCode = 0;
            }
        }
    }
}
