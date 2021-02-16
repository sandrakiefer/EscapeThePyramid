using UnityEngine;
using TMPro;

namespace HSRM.Core.UI
{
    public class InventoryItemLabel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameLabel = null;
        [SerializeField] private TextMeshProUGUI amountLabel = null;

        public void UpdateLabel(string name, int amount)
        {
            nameLabel.text = name;
            amountLabel.text = amount.ToString();
        }
    }
}