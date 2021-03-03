using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HSRM.Core.Commands;

namespace DE.HSRM.MI.EscapeThePyramid.Start
{
    public class QuitApplicationController : BaseCommand
    {
        protected override void ExecuteCommand()
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }

}
