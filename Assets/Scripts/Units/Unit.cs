namespace RTS
{
    public class Unit
    {
        public readonly UnitConfig Config;
        
        public int Health;
        public int MaxHealth;

        public Weapon Weapon;
        
        public FactionType Faction;
        public float Speed;
        
        public Unit(UnitConfig config)
        {
            Config = config;
            
            Health = config.Health;
            MaxHealth = config.MaxHealth;

            Weapon = config.Weapon;
            
            Faction = config.FactionType;
            Speed = config.Speed;
        }
    }
}