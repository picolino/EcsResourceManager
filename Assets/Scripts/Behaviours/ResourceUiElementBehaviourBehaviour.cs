#region Usings

using UnityEngine;
using UnityEngine.UI;

#endregion

namespace Behaviours
{
    public class ResourceUiElementBehaviourBehaviour : MonoBehaviour, IResourceUiElementBehaviour
    {
        [SerializeField] private Text amountDisplayText;
        [SerializeField] private Image iconDisplayImage;

        [SerializeField] public ResourceUiElement resourceUi;

        private void Start()
        {
            iconDisplayImage.sprite = resourceUi.image;
            UpdateAmountDisplay();
        }

        public void AddAmount(double amount)
        {
            resourceUi.amount += amount;
            UpdateAmountDisplay();
        }

        private void UpdateAmountDisplay()
        {
            amountDisplayText.text = resourceUi.AmountString;
        }
    }
}