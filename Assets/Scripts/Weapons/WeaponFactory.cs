using Zenject;

namespace RTS.Weapons
{
    public class WeaponFactory : IFactory<WeaponConfigSO, Weapon>
        , IFactory<WeaponConfig, Weapon>
    {
        public Weapon Create(WeaponConfigSO configSo) => new Weapon(configSo);

        public Weapon Create(WeaponConfig config) =>
            new Weapon(config.Attack, config.AttackCooldown, config.AttackRange);
    }
}