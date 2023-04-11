using UnityEngine;

namespace RTS.UI
{
    public class UnitEnemyTargetDetector : TargetDetector<UnitView>
    {
        readonly Unit unit;
        public UnitView CurrentTarget;

        public UnitEnemyTargetDetector(Unit unit)
        {
            this.unit = unit;
        }
        
        public void Initialize()
        {
            OnAdd += OnAddUnit;
            OnRemove += OnRemoveUnit;
        }

        void OnAddUnit(UnitView obj)
        {
            if (CurrentTarget == null && obj.Source.Faction != unit.Faction)
                CurrentTarget = obj;
        }

        void OnRemoveUnit(Transform obj)
        {
            if (CurrentTarget != null && CurrentTarget.transform != null && CurrentTarget.transform == obj)
                CurrentTarget = null;
        }
    }
}