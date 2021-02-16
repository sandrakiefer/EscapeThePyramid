using System.Collections.Generic;
using UnityEngine;

namespace HSRM.Core.Commands
{
    public class CompoundCommand : BaseCommand
    {
        [SerializeField] private List<BaseCommand> commands = new List<BaseCommand>();

        protected override void ExecuteCommand()
        {
            foreach(var command in commands)
            {
                command.Execute();
            }
        }
    }
}