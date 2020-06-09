using Behaviours;

namespace Components
{
    public struct ResourceItemComponent
    {
        public int uid;
        public double amount;
        public IResourceItemBehaviour resourceItemBehaviour;
    }
}