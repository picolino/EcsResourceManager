#region Usings

using Basics;
using Components;
using JetBrains.Annotations;
using Leopotam.Ecs;

#endregion

namespace Systems
{
    public class GatherResourceItemsProcessing : IEcsRunSystem
    {
        private readonly EcsWorld world;
        [PublicAPI(PublicAPIComment.DI)] private EcsFilter<ResourceItemComponent> filter;

        public GatherResourceItemsProcessing(EcsWorld world)
        {
            this.world = world;
        }

        public void Run()
        {
            foreach (var entity in filter)
            {
                ref var resourceItemComponent = ref filter.Get1(entity);

                if (resourceItemComponent.resourceItemBehaviour.IsTriggered)
                {
                    var newEntity = world.NewEntity();
                    ref var resourceAmountChangedEventComponent = ref newEntity.Get<ResourceAmountChangedEventComponent>();
                    resourceAmountChangedEventComponent.uid = resourceItemComponent.uid;
                    resourceAmountChangedEventComponent.amount = resourceItemComponent.amount;
                    
                    resourceItemComponent.resourceItemBehaviour.Dispose();
                    filter.GetEntity(entity).Destroy();
                }

            }
        }
    }
}