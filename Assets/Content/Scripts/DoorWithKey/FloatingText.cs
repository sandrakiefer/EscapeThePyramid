using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DE.HSRM.MI.EscapeThePyramid.DoorWithKey
{
    public class FloatingText : MonoBehaviour
    {
        public float DestroyTime = 3f;
        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, DestroyTime);
        }

    }
}
