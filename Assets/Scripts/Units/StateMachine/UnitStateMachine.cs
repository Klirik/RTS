using RTS.UI;

namespace RTS.Units
{
    public class UnitStateMachine : StateMachine
    {
        UnitIdleState idle;
        UnitGatherState gather;
        UnitFightState fight;
        UnitSearchState search;
        UnitDeathState death;

        public UnitStateMachine(UnitView unitView)
        {
            idle = new UnitIdleState();
            fight = new UnitFightState(unitView);
            gather = new UnitGatherState(unitView);
            search = new UnitSearchState(unitView);
            death = new UnitDeathState(unitView);
            
            AddTransition(idle, search, NoMovingNoTarget);
            AddTransition(idle, fight, CanDamageEnemy);
            AddTransition(search, fight, CanDamageEnemy);
            
            AddTransition(idle, gather, CanGather);
            AddTransition(search, gather, CanGather);
            AddTransition(gather, idle, NoCanGather);
            
            AddTransition(search, idle, NoMovingNoTarget);
            AddTransition(fight, idle, NoTarget);
            AddTransition(fight, idle, NoInRangeTarget);
            
            AddAnyTransition(death, IsDeath);

            bool IsDeath() => unitView.Source.Health.Value <= 0;

            bool CanGather() => unitView.GatherDetector.CurrentTarget != null 
                                && unitView.GatherDetector.CurrentTarget.Source.IsGathered == false;
            bool NoCanGather() => unitView.GatherDetector.CurrentTarget == null
                                || unitView.GatherDetector.CurrentTarget.Source.IsGathered;
            
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