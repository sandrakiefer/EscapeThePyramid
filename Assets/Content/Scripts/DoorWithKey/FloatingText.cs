using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DE.HSRM.MI.skief.EscapeThePyramid.DoorWithKey
{
    public class FloatingText : MonoBehaviour
    {
        public float DestroyTime = 3f;

        void Start()
        {
            Destroy(gameObject, DestroyTime);
        }

    }
}
