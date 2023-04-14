using RTS.Weapons;
using UniRx;

namespace RTS.Units
{
    public class Unit
    {
        public ReactiveProperty<int> Health;
        public ReactiveProperty<int> MaxHealth;

        public Weapon Weapon;
        
        public FactionType Faction;
        public float Speed;
        
        public Unit(UnitConfigSO config, Weapon weapon, FactionType factionType) 
            : this(config.SkillSO.Health, config.SkillSO.MaxHealth, config.SkillSO.Speed, weapon, factionType) 
        {}
        
        public Unit(int health, int maxHealth, float speed, Weapon weapon, FactionType factionType)
        {
            Health = new ReactiveProperty<int>(health);
            MaxHealth = new ReactiveProperty<int>(maxHealth);
            Speed = speed;
            
            Faction = factionType;

            Weapon = weapon;
        }
    }
}