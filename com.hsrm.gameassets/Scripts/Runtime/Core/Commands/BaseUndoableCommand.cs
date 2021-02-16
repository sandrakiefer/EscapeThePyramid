using System.Collections;
using UnityEngine;

namespace HSRM.Core.Commands
{
    public abstract class BaseUndoableCommand : BaseCommand
    {
        public abstract bool CanUndo { get; }

        public void Undo()
        {
            if (CanUndo)
            {
                UndoCommand();
            }
        }
        public void UndoDelayed(float delay)
        {
            StartCoroutine(DelayedUndo(delay));
        }

        private IEnumerator DelayedUndo(float delay)
        {
            yield return new WaitForSeconds(delay);
            Undo();
        }

        protected abstract void UndoCommand();
    }
}