namespace RTS
{
    public class UnitHealthSystem
    {
        readonly Unit unit;

        public UnitHealthSystem(Unit unit)
        {
            this.unit = unit;
        }
        
        public void TakeDamage(int amount)
        {
            unit.Health.Value -= amount;
        }

        public void RestoreHealth(int amount)
        {
            unit.Health.Value += amount;
        }
    }
}