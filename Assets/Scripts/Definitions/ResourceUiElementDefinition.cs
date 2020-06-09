#region Usings

using UnityEngine;

#endregion

namespace Definitions
{
    [CreateAssetMenu(fileName = "New Resource", menuName = "Resource definition", order = 51)]
    public class ResourceUiElementDefinition : ScriptableObject
    {
        [SerializeField] public int uid;
        [SerializeField] public double amount;
        [SerializeField] public Sprite image;

        public string AmountString => amount.ToString("N0");
    }
}