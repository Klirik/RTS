using RTS.Weapons;

namespace RTS
{
    public class UnitConfig
    {
        public int Health;
        public int MaxHealth;
        
        public float Speed;

        public WeaponConfig WeaponConfig;

        public UnitConfig(float speed, int health, int maxHealth, WeaponConfig weaponConfig)
        {
            Health = health;
            MaxHealth = maxHealth;
            
            Speed = speed;
            WeaponConfig = weaponConfig;
        }
    }
}