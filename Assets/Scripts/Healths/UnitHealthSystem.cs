using System;

namespace RTS
{
    public class UnitHealthSystem
    {
        public event Action OnUpdate; 
        public event Action OnEnd;

        public BoundedInt Health { get; private set; }
        
        public UnitHealthSystem(int initialHealth, int maxHealth)
        {
            Health = new BoundedInt(initialHealth, maxHealth);
        }
        
        public void TakeDamage(int amount)
        {
            Health.Value -= amount;
            OnUpdate?.Invoke();
            if(Health.Value <= 0)
                OnEnd?.Invoke();
        }

        public void RestoreHealth(int amount)
        {
            Health.Value += amount;
            OnUpdate?.Invoke();
        }
    }
}