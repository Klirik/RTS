using System.Collections.Generic;

namespace RTS
{
    public class UpdateManager
    {
        HashSet<ITickable> collection = new HashSet<ITickable>();
        public IReadOnlyCollection<ITickable> Collection => collection;

        public void Add(ITickable tickable)
        {
            collection.Add(tickable);
        }

        public void Remove(ITickable tickable)
        {
            if(collection.Contains(tickable))
                collection.Remove(tickable);
        }
    }
}