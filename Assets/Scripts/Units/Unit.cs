using RTS.Weapons;
using UniRx;

namespace RTS.Units
{
    public class Unit
    {
        public ReactiveProperty<int> Health;
        public ReactiveProperty<int> MaxHealth;
        
        public ReactiveProperty<float> GatherDistance;

        public Weapon Weapon;
        
        public FactionType Faction;
        public float Speed;
        
        public Unit(UnitConfigSO config, Weapon weapon, FactionType factionType) 
            : this(config.statSO.Health, config.statSO.MaxHealth, config.statSO.Speed
                , config.statSO.GatherDistance, weapon, factionType) 
        {}
        
        public Unit(int health, int maxHealth, float speed, float gatherDistance, Weapon weapon, FactionType factionType)
        {
            Health = new ReactiveProperty<int>(health);
            MaxHealth = new ReactiveProperty<int>(maxHealth);
            Speed = speed;

            GatherDistance = new ReactiveProperty<float>(gatherDistance);
            
            Faction = factionType;

            Weapon = weapon;
        }
    }
}