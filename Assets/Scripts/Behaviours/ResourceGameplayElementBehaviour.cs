#region Usings

using System;
using Components;
using UnityEngine;

#endregion

namespace Behaviours
{
    public class ResourceGameplayElementBehaviour : MonoBehaviour, IResourceGameplayElement
    {
        public bool IsTriggered { get; private set; }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            IsTriggered = true;
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}