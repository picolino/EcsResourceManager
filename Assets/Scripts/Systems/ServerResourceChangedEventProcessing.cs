#region Usings

using System.Collections.Generic;
using Components;
using Leopotam.Ecs;

#endregion

namespace Systems
{
    public class ServerResourceChangedEventProcessing : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
    {
        private readonly EcsWorld world;
        private readonly DependencyContainer dependencyContainer;

        private Queue<ResourceAmountChangedEventComponent> changeResourceEventsQueue;

        public ServerResourceChangedEventProcessing(EcsWorld world, DependencyContainer dependencyContainer)
        {
            this.world = world;
            this.dependencyContainer = dependencyContainer;
        }

        public void Init()
        {
            changeResourceEventsQueue = new Queue<ResourceAmountChangedEventComponent>();
            dependencyContainer.Server.ResourceChangedEvent += ServerOnResourceChangedEvent;
        }

        public void Run()
        {
            for (var i = 0; i < changeResourceEventsQueue.Count; i++)
            {
                var changeResourceEventComponent = changeResourceEventsQueue.Dequeue();
                var entity = world.NewEntity();
                ref var resourceAmountChangedEventComponent = ref entity.Get<ResourceAmountChangedEventComponent>();
                resourceAmountChangedEventComponent = changeResourceEventComponent;
            }
        }

        public void Destroy()
        {
            dependencyContainer.Server.ResourceChangedEvent -= ServerOnResourceChangedEvent;
        }

        private void ServerOnResourceChangedEvent(int uid, double amount)
        {
            changeResourceEventsQueue.Enqueue(new ResourceAmountChangedEventComponent
                                              {
                                                  uid = uid,
                                                  amount = amount
                                              });
        }
    }
}