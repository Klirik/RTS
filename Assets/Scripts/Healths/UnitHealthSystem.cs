using RTS.Healths;
using RTS.Units;
using UnityEngine;

namespace RTS.Healths
{
    public class UnitHealthSystem : BaseHaveHealth<Unit>
    {
        public UnitHealthSystem(Unit source) : base(source)
        {
        }

        public override void TakeDamage(int amount)
        {
            var currentValue = source.Health.Value - amount;
            source.Health.Value = Mathf.Clamp(currentValue, 0, source.Health.Value);
        }

        public override void RestoreHealth(int amount)
        {
            source.Health.Value += amount;
        }
    }
}