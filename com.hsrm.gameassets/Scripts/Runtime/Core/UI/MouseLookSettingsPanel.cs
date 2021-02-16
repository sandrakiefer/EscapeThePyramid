using HSRM.Core.Util;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HSRM.Core.UI
{
    public class MouseLookSettingsPanel : MonoBehaviour
    {
        [SerializeField] private Toggle toggleMouseX = null;
        [SerializeField] private Toggle toggleMouseY = null;

        [SerializeField] private Slider sliderMouseX = null;
        [SerializeField] private Slider sliderMouseY = null;

        private List<MouseLook> mouseLookComponents = new List<MouseLook>();

        public void ApplySettings()
        {
            UpdatePlayerPrefs();
            UpdateMouseLookComponents();
        }

        private void Start()
        {
            GetMouseLookComponentsFromScene();
            InitializeUserInterface();
            ApplySettings();
        }

        private void GetMouseLookComponentsFromScene()
        {
            Scene scene = SceneManager.GetActiveScene();
            foreach (var rootGO in scene.GetRootGameObjects())
            {
                var components = rootGO.GetComponentsInChildren<MouseLook>(true);
                if (components != null)
                {
                    mouseLookComponents.AddRange(components);
                }
            }
        }

        private void InitializeUserInterface()
        {
            sliderMouseX.SetValueWithoutNotify(PlayerPrefs.GetFloat("SensitivityX", 100f));
            sliderMouseY.SetValueWithoutNotify(PlayerPrefs.GetFloat("SensitivityY", 100f));
            toggleMouseX.SetIsOnWithoutNotify(PlayerPrefs.GetInt("InvertX", 0) == 1);
            toggleMouseY.SetIsOnWithoutNotify(PlayerPrefs.GetInt("InvertY", 1) == 1);
        }

        private void UpdatePlayerPrefs()
        {
            PlayerPrefs.SetFloat("SensitivityX", sliderMouseX.value);
            PlayerPrefs.SetFloat("SensitivityY", sliderMouseY.value);
            PlayerPrefs.SetInt("InvertX", toggleMouseX.isOn ? 1 : 0);
            PlayerPrefs.SetInt("InvertY", toggleMouseY.isOn ? 1 : 0);
        }

        private void UpdateMouseLookComponents()
        {
            foreach (var mouseLook in mouseLookComponents)
            {
                mouseLook.InvertX = toggleMouseX.isOn;
                mouseLook.InvertY = toggleMouseY.isOn;
                mouseLook.SensitivityX = sliderMouseX.value;
                mouseLook.SensitivityY = sliderMouseY.value;
            }
        }
    }

}
