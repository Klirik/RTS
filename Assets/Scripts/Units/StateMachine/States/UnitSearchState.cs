using RTS.UI;
using UnityEngine;

namespace RTS
{
    public class UnitSearchState : State
    {
        readonly UnitView unitView;
        public bool IsMoving;
        public UnitSearchState(UnitView unitView)
        {
            this.unitView = unitView;
        }

        public override void Enter()
        {
            base.Enter();
            IsMoving = true;
            unitView.movementStrategy.MoveRandomly();
            unitView.movementStrategy.OnEnd += EndMoving;
        }

        void EndMoving()
        {
            IsMoving = false;
        }

        public override void Exit()
        {
            base.Exit();
            unitView.movementStrategy.Stop();
            unitView.movementStrategy.OnEnd -= EndMoving;
        }
    }
}