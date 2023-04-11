using UnityEngine;

namespace RTS.Inputs
{
    public class InputSystem : ITickable
    {
        readonly SelectSystem selectSystem;
        readonly ClickMovementSystem clickMovementSystem;

        public InputSystem(SelectSystem selectSystem, ClickMovementSystem clickMovementSystem)
        {
            this.selectSystem = selectSystem;
            this.clickMovementSystem = clickMovementSystem;
        }
        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                selectSystem.Select();
            }
            
            if (Input.GetMouseButtonUp(1))
            {
                if (selectSystem.SelectedUnit)
                    clickMovementSystem.Move();
            }
        }
    }
}