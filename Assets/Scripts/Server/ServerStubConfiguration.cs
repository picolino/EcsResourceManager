#region Usings

using UnityEngine;

#endregion

namespace Server
{
    public class ServerStubConfiguration : MonoBehaviour
    {
        [Header("Random resource over time change configuration")] 
        [SerializeField] public int intervalMin = 1000;
        [SerializeField] public int intervalMax = 4000;
        [SerializeField] public int amountMin = -10;
        [SerializeField] public int amountMax = 11;
    }
}