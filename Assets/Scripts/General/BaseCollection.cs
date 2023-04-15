using System.Collections.Generic;

namespace RTS
{
    public class BaseCollection<TEntity>
    {
        HashSet<TEntity> collection = new HashSet<TEntity>();
        public IReadOnlyCollection<TEntity> Collection => collection;

        public void Add(TEntity entity)
        {
            collection.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            if(collection.Contains(entity))
                collection.Remove(entity);
        }
    }
}