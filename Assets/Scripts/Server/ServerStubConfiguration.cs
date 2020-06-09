#region Usings

using UnityEngine;

#endregion

namespace Server
{
    public class ServerStubConfiguration : MonoBehaviour
    {
        [Header("Random resource over time change configuration")] 
        [SerializeField] public int intervalMin = 100;
        [SerializeField] public int intervalMax = 400;
        [SerializeField] public int amountMin = -1;
        [SerializeField] public int amountMax = 2;
    }
}