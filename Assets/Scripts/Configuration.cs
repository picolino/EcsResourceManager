#region Usings

using Behaviours;
using UnityEngine;

#endregion

public class Configuration : MonoBehaviour
{
    [Header("Resource definitions")] 
    [SerializeField] public ResourceUiElement[] resourceUiElements;

    [Header("Dependencies")] 
    [Tooltip("Canvas for resources placement")] 
    [SerializeField] public Canvas resourcePanelCanvas;
    [Tooltip("Prefab for display each type of resource on the UI")] 
    [SerializeField] public GameObject resourceUiElementPrefab;
    [Tooltip("Player game object")] 
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject resourceItemPrefab;
    [SerializeField] public Camera mainCamera;
}