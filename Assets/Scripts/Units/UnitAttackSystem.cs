using UnityEngine;

namespace RTS
{
    public class UnitAttackSystem : ITickable
    {
        public Weapon Weapon;
        public float Cooldown { get; set; }
        public bool isCooldown => Cooldown > 0;

        public UnitAttackSystem(Weapon weapon)
        {
            Weapon = weapon;
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