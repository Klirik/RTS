using System;
using RTS.UI;
using UnityEngine;
using Zenject;

namespace RTS
{
    public class ClickMovementSystem
    {
        public event Action<Transform, Vector3> OnMove;
        SelectSystem selectSystem;

        Vector2 position;
        
        [Inject]
        void Init(SelectSystem selectSystem)
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