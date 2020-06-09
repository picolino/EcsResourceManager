#region Usings

using UnityEngine;
using UnityEngine.UI;

#endregion

namespace Behaviours
{
    public class ResourceDisplayElementBehaviour : MonoBehaviour, IResourceDisplayElement
    {
        [SerializeField] private Text amountDisplayText;
        [SerializeField] private Image iconDisplayImage;

        [SerializeField] public ResourceElement resource;

        private void Start()
        {
            iconDisplayImage.sprite = resource.image;
            UpdateAmountDisplay();
        }

        public void AddAmount(double amount)
        {
            resource.amount += amount;
            UpdateAmountDisplay();
        }

        private void UpdateAmountDisplay()
        {
            amountDisplayText.text = resource.AmountString;
        }
    }
}