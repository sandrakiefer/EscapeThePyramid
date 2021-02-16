using System.Collections;
using UnityEngine;
namespace HSRM.Core.Commands
{

    public abstract class BaseCommand : MonoBehaviour
    {
        [SerializeField] private bool canExecute = true;
        protected abstract void ExecuteCommand();

        public virtual bool CanExecute 
        {
            get => canExecute;
            set => canExecute = value;
        }
        
        public void Execute()
        {
            if (CanExecute)
            {
                ExecuteCommand();
            }
        }

        public void ExecuteDelayed(float delay)
        {
            StartCoroutine(DelayedExecute(delay));
        }


        private IEnumerator DelayedExecute(float delay)
        {
            yield return new WaitForSeconds(delay);
            Execute();
        }
    }

}
