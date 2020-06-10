#region Usings

using Definitions;
using UnityEngine;

#endregion

public class Configuration : MonoBehaviour
{
    [Header("Resource definitions")] 
    [SerializeField] public ResourceElementDefinition[] resourceUiElementDefinitions;

    [Header("Dependencies")] 
    
    [Tooltip("Canvas for resources placement")] 
    [SerializeField] public Canvas resourcePanelCanvas;

    [Tooltip("Prefab for display each type of resource on the UI")] 
    [SerializeField] public GameObject resourceUiElementPrefab;

    [Tooltip("Player game object")] 
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject resourceItemPrefab;
    [SerializeField] public Camera mainCamera;

    [Header("Player settings")] 
    
    [SerializeField] public float playerSpeed = 5;

    [Header("Simulation settings")] 
    
    [SerializeField] public int resourceSpawnItemAmountMin = -10;
    [SerializeField] public int resourceSpawnItemAmountMax = 11;
    [SerializeField] public int resourceSpawnItemPositionXMin = -3;
    [SerializeField] public int resourceSpawnItemPositionXMax = 4;
    [SerializeField] public int resourceSpawnItemPositionYMin = -3;
    [SerializeField] public int resourceSpawnItemPositionYMax = 4;
}