using UnityEngine;

namespace RTS.Weapons
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "RTS/Weapon", order = 1)]
    public class WeaponConfigSO : ScriptableObject
    {
        [SerializeField] int attack;
        [SerializeField] bool isRandomAttack; 
        [SerializeField] int attackDelta;
        [Space]
        [SerializeField] float attackCooldown;
        [SerializeField] bool isRandomAttackCooldown;
        [SerializeField] float cooldownDelta;
        
        [Space]
        [SerializeField] float attackRange;
        [SerializeField] bool isRandomAttackRange;
        [SerializeField] float attackRangeDelta;

        public int Attack => isRandomAttack ? Random.Range(attack - attackDelta, attack + attackDelta) : attack; 
        
        public float AttackCooldown => isRandomAttackCooldown 
            ? Random.Range(attackCooldown - cooldownDelta, attackCooldown + cooldownDelta) 
            : attackCooldown;
        
        public float AttackRange => isRandomAttackRange 
            ? Random.Range(attackRange - attackRangeDelta, attackRange + attackRangeDelta) 
            : attackRange; 
    }
}