using RTS.Units;
using RTS.Weapons;
using UnityEngine;

namespace RTS
{
    public class UnitAttackSystem : ITickable
    {
        readonly Unit unit;
        public Weapon Weapon => unit.Weapon;
        public float Cooldown { get; set; }
        public bool isCooldown => Cooldown > 0;

        public UnitAttackSystem(Unit unit)
        {
            this.unit = unit;
        }

        public void Damage(IDamageable target)
        {
            if(isCooldown) return;
            
            target.TakeDamage(Weapon.Attack);
            Cooldown = Weapon.AttackCooldown;
        }

        public void Tick()
        {
            if(!isCooldown) return;
            
            Cooldown -= Time.deltaTime;
        }
    }
}