using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DE.HSRM.MI.EscapeThePyramid.DoorWithPin
{
    public class CameraControllerCodeLock : MonoBehaviour
    {

        CodeLock codeLock;

        int reachRange = 100;

        void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                CheckHitObj();
            }
        }

        void CheckHitObj()
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, reachRange))
            {
                codeLock = hit.transform.gameObject.GetComponentInParent<CodeLock>();

                if(codeLock != null)
                {
                    string value = hit.transform.name;
                    codeLock.SetValue(value);
                }
            }
        }

    }
}
