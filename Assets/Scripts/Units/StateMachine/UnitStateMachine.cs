using RTS.UI;

namespace RTS
{
    public class UnitStateMachine : StateMachine
    {
        UnitIdleState idleState;
        UnitFightState fightState;
        UnitSearchEnemyState moveState;
        UnitDeathState deathState;
        

        public UnitStateMachine(UnitView unitView)
        {
            idleState = new UnitIdleState();
            fightState = new UnitFightState(unitView);
            moveState = new UnitSearchEnemyState(unitView);
            deathState = new UnitDeathState(unitView);
            
            AddTransition(idleState, moveState, NoMovingNoTarget);
            AddTransition(moveState, idleState, NoMovingNoTarget);
            AddTransition(fightState, idleState, NoTarget);
            AddTransition(fightState, idleState, NoInRangeTarget);

            AddAnyTransition(fightState, CanDamageEnemy);
            AddAnyTransition(deathState, IsDeath);

            bool IsDeath() => unitView.UnitHealthSystem.Health.Value <= 0;
            bool NoTarget() => unitView.EnemyDetector.CurrentTarget == null;
            bool NoMovingNoTarget() => !moveState.IsMoving && NoTarget();
            bool CanDamageEnemy() => HaveEnemyTarget() && !NoInRangeTarget(); 
            bool HaveEnemyTarget() => unitView.EnemyDetector.CurrentTarget != null;
            bool NoInRangeTarget()
            {
                if (NoTarget()) return false;
                    
                var distance = (unitView.EnemyDetector.CurrentTarget.transform.position 
                                - unitView.transform.position).magnitude;

                return unitView.UnitAttackSystem.Weapon.AttackRange < distance;
            };
            

            SetState(idleState);
        }
    }
}