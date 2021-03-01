using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HSRM.Core.Events;
using HSRM.Core.Commands;
using HSRM.Core;
using HSRM.Core.Collectables;

namespace DE.HSRM.MI.EscapeThePyramid.DoorWithKey
{
    public class SetDoorAnimatorCommand : BaseSetAnimatorCommand
    {
        public BoolEvent OnExecute = null;

        [SerializeField] private bool boolValue = true;

        public bool BoolValue { get => boolValue; set => boolValue = value; }

        [SerializeField] private Inventory targetInventory = null;

        private InventoryItem inventoryItem = null;

        public GameObject KeyInfoTextPrefab;

        private bool isActive = true;

        bool isOpen()
        {
            var itemAmount = 0;
            foreach (var item in targetInventory.Items)
            {
                if (item.Key.ItemName =="DoorKey")
                {
                    inventoryItem = item.Key;
                    itemAmount = item.Value;
                }
            }
            if (itemAmount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void ExecuteCommand()
        {
            if (isActive)
            {
                if (isOpen())
                {
                    animator.SetBool(parameterName, true);
                    targetInventory.RemoveItem(inventoryItem, 1);
                    isActive = false;
                    ChangeLayers(gameObject, 0);
                    GameObject.Find("/Core/UI/InventoryCanvas/InventoryPanel/Content").SetActive(false);
                    OnExecute?.Invoke(BoolValue);
                } 
                else
                {
                    ShowFloatingText();
                }
            }
        }

        void ShowFloatingText()
        {
            Instantiate(KeyInfoTextPrefab, transform.position, Quaternion.identity, transform);
        }

            public static void ChangeLayers(GameObject go, int layer)
        {
            go.layer = layer;
            foreach (Transform child in go.transform)
            {
                ChangeLayers(child.gameObject, layer);
            }
        }

    }
}
