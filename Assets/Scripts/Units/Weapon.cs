namespace RTS
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
    }
}