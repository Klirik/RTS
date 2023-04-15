using RTS.Gathers;
using RTS.Units;
using UnityEngine;

namespace RTS.UI
{
    public class UnitGatherTargetDetector : TargetDetector<ResourceView>
    {
        public ResourceView CurrentTarget;

        public void Initialize()
        {
            OnAdd += OnAddUnit;
            OnRemove += OnRemoveUnit;
        }

        void OnAddUnit(ResourceView obj)
        {
            if (CurrentTarget == null)
                CurrentTarget = obj;
        }

        void OnRemoveUnit(Transform obj)
        {
            if (CurrentTarget != null && CurrentTarget.transform != null && CurrentTarget.transform == obj)
                CurrentTarget = null;
        }
    }
}