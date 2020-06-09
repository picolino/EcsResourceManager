#region Usings

using UnityEngine;

#endregion

namespace Behaviours
{
    public class ResourceItemBehaviourBehaviour : MonoBehaviour, IResourceItemBehaviour
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