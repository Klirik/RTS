using RTS.Currencies;
using RTS.Gathers;
using RTS.UI;

namespace RTS
{
    public class UnitGatherState : State
    {
        UnitView unitView;

        ResourceView target;
        
        public UnitGatherState(UnitView unitView)
        {
            this.unitView = unitView;
        }

        public override void Enter()
        {
            base.Enter();
            target = unitView.GatherDetector.CurrentTarget;
        }

        public override void Tick()
        {
            base.Tick();
            
            var distance = (target.transform.position - unitView.transform.position).magnitude;

            if (!(unitView.Source.GatherDistance.Value > distance) 
                || target.Source.Ticks.Value <= 0 
                || !target.Gather(ticksPerOne: 3)) 
                return;
            
            if (unitView.FactionState.CurrenciesCollection.Collection.TryGetValue(target.Source.ResourceType, out var currency))
            {
                currency.Value.Value += target.Source.Amount.Value;
            }
        }

        public override void Exit()
        {
            base.Exit();
            
        }
    }
}