using System.Collections.Generic;

namespace RTS.Currencies
{
    public class BaseDictionaryCollection<TType, TEntity>
    {
        Dictionary<TType, TEntity> collection = new Dictionary<TType, TEntity>();
        public IReadOnlyDictionary<TType, TEntity> Collection => collection;

        public void Add(TType key, TEntity value)
        {
            if(collection.ContainsKey(key)) 
                return;
            collection[key] = value;
        }

        public void Remove(TType key)
        {
            collection.Remove(key);
        }
    }
}