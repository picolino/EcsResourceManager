#region Usings

using Components;
using Leopotam.Ecs;
using UnityEngine;

#endregion

namespace Behaviours
{
    public class ResourceItemBehaviour : MonoBehaviour
    {
        private EcsWorld world;
        private EcsEntity entity;
        private ResourceItemComponent resourceItemComponent;

        public void Init(EcsWorld world, ref ResourceItemComponent resourceItemComponent, ref EcsEntity entity)
        {
            this.world = world;
            this.entity = entity;
            this.resourceItemComponent = resourceItemComponent;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var newEntity = world.NewEntity();
            ref var resourceAmountChangedEventComponent = ref newEntity.Get<ResourceAmountChangedEventComponent>();
            resourceAmountChangedEventComponent.uid = resourceItemComponent.uid;
            resourceAmountChangedEventComponent.amount = resourceItemComponent.amount;
            
            entity.Destroy();
            
            Destroy(gameObject);
        }
    }
}