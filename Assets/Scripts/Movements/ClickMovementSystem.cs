using System;
using RTS.UI;
using UnityEngine;

namespace RTS
{
    public class ClickMovementSystem
    {
        public event Action<Transform, Vector3> OnMove;
        public event Action OnEndMove;
        SelectSystem selectSystem;

        
        Vector2 position;

        public ClickMovementSystem(SelectSystem selectSystem)
        {
            this.selectSystem = selectSystem;
        }

        public void Move()
        {
            position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var view = selectSystem.SelectedUnit.GetComponent<UnitView>();
            view.ClickToMove(position);
            OnMove?.Invoke(view.transform, position);
        }
    }
}