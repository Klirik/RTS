using RTS.UI;

namespace RTS
{
    public class UnitFightState : State
    {
        UnitView unitView;

        UnitView target;
        
        public UnitFightState(UnitView unitView)
        {
            this.unitView = unitView;
        }

        public override void Enter()
        {
            base.Enter();
            target = unitView.EnemyDetector.CurrentTarget;
        }

        public override void Tick()
        {
            base.Tick();
            if(unitView.UnitAttackSystem.isCooldown) return;
            
            var distance = (target.transform.position - unitView.transform.position).magnitude;
            
            if(unitView.UnitAttackSystem.Weapon.AttackRange > distance)
                unitView.UnitAttackSystem.Damage(target);
        }
    }
}