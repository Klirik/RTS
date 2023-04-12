using UniRx;

namespace RTS
{
    public class Unit
    {
        public readonly UnitConfig Config;
        
        public ReactiveProperty<int> Health;
        public ReactiveProperty<int> MaxHealth;

        public Weapon Weapon;
        
        public FactionType Faction;
        public float Speed;
        
        public Unit(UnitConfig config)
        {
            Config = config;
            
            MaxHealth = new ReactiveProperty<int>(config.MaxHealth);
            Health = new ReactiveProperty<int>(config.Health);

            Weapon = config.Weapon;
            
            Faction = config.FactionType;
            Speed = config.Speed;
        }
    }
}