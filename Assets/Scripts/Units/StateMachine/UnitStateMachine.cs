using RTS.UI;

namespace RTS
{
    public class UnitStateMachine : StateMachine
    {
        UnitIdleState idle;
        UnitFightState fight;
        UnitSearchEnemyState search;
        UnitDeathState death;

        public UnitStateMachine(UnitView unitView)
        {
            idle = new UnitIdleState();
            fight = new UnitFightState(unitView);
            search = new UnitSearchEnemyState(unitView);
            death = new UnitDeathState(unitView);
            
            AddTransition(idle, search, NoMovingNoTarget);
            AddTransition(search, fight, CanDamageEnemy);
            
            AddTransition(search, idle, NoMovingNoTarget);
            AddTransition(fight, idle, NoTarget);
            AddTransition(fight, idle, NoInRangeTarget);
            
            AddAnyTransition(death, IsDeath);

            bool IsDeath() => unitView.Source.Health.Value <= 0;
            bool IsTakeDamage() => unitView.Source.Health.Value <= 0;
            bool NoTarget() => unitView.EnemyDetector.CurrentTarget == null;
            bool NoMovingNoTarget() => !search.IsMoving && NoTarget();
            bool CanDamageEnemy() => HaveEnemyTarget() && !NoInRangeTarget(); 
            bool HaveEnemyTarget() => unitView.EnemyDetector.CurrentTarget != null;
            bool NoInRangeTarget()
            {
                if (NoTarget()) return false;
                    
                var distance = (unitView.EnemyDetector.CurrentTarget.transform.position 
                                - unitView.transform.position).magnitude;

                return unitView.UnitAttackSystem.Weapon.AttackRange < distance;
            };
            

            SetState(idle);
        }
    }
}