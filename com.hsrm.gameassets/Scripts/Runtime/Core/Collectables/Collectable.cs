using HSRM.Core.Events;
using UnityEngine;

namespace HSRM.Core.Collectables
{
    public class Collectable : MonoBehaviour
    {
        public CollectableEvent OnCollect;

        public void Collect()
        {
            OnCollect?.Invoke(this);
        }
    }
}