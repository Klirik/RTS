using System;
using System.Collections.Generic;
using UnityEngine;

namespace RTS.UI
{
    public class TargetDetector<TEntity> 
        where TEntity : MonoBehaviour
    {
        public event Action<TEntity> OnAdd;
        public event Action<Transform> OnRemove;
        
        public HashSet<Transform> detectedTargets = new HashSet<Transform>();

        public void Add(Transform transform)
        {
            if (!transform.TryGetComponent<TEntity>(out var view)) return;
            
            detectedTargets.Add(view.transform);
            OnAdd?.Invoke(view);
        }

        public void Remove(Transform transform)
        {
            if (!detectedTargets.Contains(transform)) return;
            detectedTargets.Remove(transform);
            OnRemove?.Invoke(transform);
        }
    }
}