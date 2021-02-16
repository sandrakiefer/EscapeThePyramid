using UnityEngine;

namespace HSRM.Core.Commands
{
    public abstract class BaseSelectionCommand : BaseRaycasterCommand
    {
        public virtual bool HasSelection { get; protected set; } = false;
    }
}