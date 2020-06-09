#region Usings

using Behaviours;
using UnityEngine;

#endregion

public class Configuration : MonoBehaviour
{
    [Header("Resource definitions")] 
    [SerializeField] public ResourceElement[] resourceElements;

    [Header("Dependencies")] 
    [Tooltip("Canvas for resources placement")] 
    [SerializeField] public Canvas resourcePanelCanvas;
    [Tooltip("Prefab for display each type of resource")] 
    [SerializeField] public GameObject resourceDisplayElementPrefab;
}