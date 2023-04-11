namespace RTS
{
    public class UnitConfig
    {
        public int Health;
        public int MaxHealth;
        
        readonly int attack;
        public FactionType FactionType;
        public float Speed;

        public Weapon Weapon;

        public UnitConfig(float speed, FactionType factionType
            , int health, int maxHealth, Weapon weapon)
        {
            Speed = speed;
            FactionType = factionType;
            Health = health;
            MaxHealth = maxHealth;
            Weapon = weapon;
        }
    }
}