#region Usings

using Basics;
using Components;
using JetBrains.Annotations;
using Leopotam.Ecs;

#endregion

namespace Systems
{
    public class GatherResourceProcessing : IEcsRunSystem
    {
        private readonly EcsWorld world;
        [PublicAPI(PublicAPIComment.DI)] private EcsFilter<ResourceGameplayElementComponent> filter;

        public GatherResourceProcessing(EcsWorld world)
        {
            this.world = world;
        }

        public void Run()
        {
            foreach (var entity in filter)
            {
                ref var resourceGameplayElementComponent = ref filter.Get1(entity);

                if (resourceGameplayElementComponent.resourceGameplayElement.IsTriggered)
                {
                    var newEntity = world.NewEntity();
                    ref var entityComponent = ref newEntity.Get<ResourceAmountChangedEventComponent>();
                    entityComponent.uid = resourceGameplayElementComponent.uid;
                    entityComponent.amount = resourceGameplayElementComponent.amount;
                    
                    resourceGameplayElementComponent.resourceGameplayElement.Dispose();
                    filter.GetEntity(entity).Destroy();
                }

            }
        }
    }
}