#region Usings

using System.Linq;
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

        var random = new Random();
        var resourceIds = configuration.resourceElementDefinitions.Select(o => o.uid).ToArray();

        dependencyContainer = new DependencyContainer
                              {
                                  Random = random,
                                  Configuration = configuration,
                                  ServerStubConfiguration = serverStubConfiguration,
                                  ResourceIds = resourceIds,
                                  Server = new ServerStub(serverStubConfiguration, random, resourceIds)
                              };

        systems.Add(new InitializeResourcesProcessing(world, dependencyContainer))
               .Add(new UserInputProcessing(world, dependencyContainer))
               .Add(new PlayerMovementProcessing(dependencyContainer))
               .Add(new ResourceItemSpawnProcessing(world, dependencyContainer))
               .Add(new ServerResourceChangedEventProcessing(world, dependencyContainer))
               .Add(new UpdateResourcesProcessing())
               .OneFrame<ResourceAmountChangedEventComponent>()
               .Inject(dependencyContainer)
               .Init();
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