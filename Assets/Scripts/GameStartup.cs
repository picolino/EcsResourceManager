#region Usings

using Systems;
using Components;
using Leopotam.Ecs;
using Server;
using UnityEngine;
using Random = System.Random;

#endregion

public class GameStartup : MonoBehaviour
{
    [SerializeField] private Configuration configuration;
    [SerializeField] private ServerStubConfiguration serverStubConfiguration;

    private EcsWorld world;
    private EcsSystems systems;
    private DependencyContainer dependencyContainer;

    void Awake()
    {
        world = new EcsWorld();
        systems = new EcsSystems(world);

        dependencyContainer = new DependencyContainer
                              {
                                  Random = new Random(),
                                  Configuration = configuration,
                                  ServerStubConfiguration = serverStubConfiguration
                              };

        systems.Add(new InitializeResourcesSystem(dependencyContainer))
               .Add(new InitializeServerSystem(dependencyContainer))
               .Add(new ServerListeningSystem(world, dependencyContainer))
               .Add(new ResourcesUpdateSystem(dependencyContainer))
               .OneFrame<ResourceAmountChangedEventComponent>()
               .Inject(dependencyContainer);
    }

    private void Start()
    {
        systems.Init();
    }

    void Update()
    {
        systems.Run();
    }

    private void OnDestroy()
    {
        systems.Destroy();
        world.Destroy();
    }
}