using UnityEngine;

namespace RTS
{
    public class MonoView<TSource> : MonoBehaviour
    {
        public TSource Source { get; protected set; }

        public virtual void Set(TSource source)
        {
            Source = source;
        }
    }
}
