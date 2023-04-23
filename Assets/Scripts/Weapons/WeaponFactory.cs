using Zenject;

namespace RTS.Weapons
{
    public class WeaponFactory : IFactory<WeaponConfigSO, Weapon>
    {
        public Weapon Create(WeaponConfigSO configSo) => new Weapon(configSo);

    }
}