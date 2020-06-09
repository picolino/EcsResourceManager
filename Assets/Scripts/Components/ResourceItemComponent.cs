#region Usings

using Behaviours;

#endregion

namespace Components
{
    public struct ResourceItemComponent
    {
        public int uid;
        public double amount;
        public IResourceItemBehaviour resourceItemBehaviour;
    }
}