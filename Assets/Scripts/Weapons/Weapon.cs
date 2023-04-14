namespace RTS.Weapons
{
    public class Weapon
    {
        public int Attack;
        public float AttackCooldown;
        public float AttackRange;

        public Weapon(int attack, float attackCooldown, float attackRange)
        {
            Attack = attack;
            AttackCooldown = attackCooldown;
            AttackRange = attackRange;
        }
        
        public Weapon(WeaponConfigSO config) : this(config.Attack, config.AttackCooldown, config.AttackRange)
        {
        }
    }
}