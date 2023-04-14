using RTS.Weapons;
using Zenject;

namespace RTS.Units
{
    
    public class UnitFactory : IFactory<UnitConfig, FactionType, Unit>, 
        IFactory<UnitConfigSO, FactionType, Unit>
    {
        readonly WeaponFactory weaponFactory;

        public UnitFactory(WeaponFactory weaponFactory)
        {
            this.weaponFactory = weaponFactory;
        }
        public Unit Create(UnitConfig config, FactionType factionType) 
            => new Unit(config.Health, config.MaxHealth, config.Speed, weaponFactory.Create(config.WeaponConfig), factionType);

        public Unit Create(UnitConfigSO config, FactionType factionType)
            => new Unit(config, weaponFactory.Create(config.WeaponSO), factionType);

    }
}