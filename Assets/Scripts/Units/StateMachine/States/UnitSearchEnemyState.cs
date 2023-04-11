using RTS.UI;
using UnityEngine;

namespace RTS
{
    public class UnitSearchEnemyState : State
    {
        readonly UnitView unitView;
        public bool IsMoving;
        public UnitSearchEnemyState(UnitView unitView)
        {
            this.unitView = unitView;
            unitView.movementStrategy.OnEnd += EndMoving;
        }

        public override void Enter()
        {
            base.Enter();
            IsMoving = true;
            unitView.movementStrategy.MoveRandomly();
        }

        void EndMoving()
        {
            IsMoving = false;
            Debug.Log($"End moving {unitView.name}");
        }

        public override void Exit()
        {
            base.Exit();
            unitView.movementStrategy.Stop();
        }
    }
}