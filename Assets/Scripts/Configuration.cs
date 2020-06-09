#region Usings

using Behaviours;
using UnityEngine;

#endregion

public class Configuration : MonoBehaviour
{
    [Header("Resource definitions")] 
    [SerializeField] public ResourceUIElement[] resourceElements;

    [Header("Dependencies")] 
    [Tooltip("Canvas for resources placement")] 
    [SerializeField] public Canvas resourcePanelCanvas;
    [Tooltip("Prefab for display each type of resource on the UI")] 
    [SerializeField] public GameObject resourceUiDisplayElementPrefab;
    [Tooltip("Player game object")] 
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject resourcePrefab;
    [SerializeField] public Camera mainCamera;
}