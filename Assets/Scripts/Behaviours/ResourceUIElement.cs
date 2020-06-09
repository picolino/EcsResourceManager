#region Usings

using UnityEngine;

#endregion

namespace Behaviours
{
    [CreateAssetMenu(fileName = "New Resource", menuName = "Resource definition", order = 51)]
    public class ResourceUIElement : ScriptableObject
    {
        [SerializeField] public int uid;
        [SerializeField] public double amount;
        [SerializeField] public Sprite image;

        public string AmountString => amount.ToString("N0");
    }
}