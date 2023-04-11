using UnityEngine;

using System;
using RTS.Utils;
using LogType = RTS.Utils.LogType;

namespace RTS
{
    public class SelectSystem
    {
        public event Action<Transform> OnSelect;
        public Transform SelectedUnit { get; private set; }

        public void Select()
        {
            var hit2D = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x
                    , Camera.main.ScreenToWorldPoint(Input.mousePosition).y)
                    , direction: Vector2.down
                    , distance: 1f);

            if (hit2D.transform)
            {
                SelectedUnit = hit2D.transform;

                this.Log($"SelectedUnit = {SelectedUnit}", LogType.SelectFeature);
                OnSelect?.Invoke(SelectedUnit);
            }
            else
            {
                Deselect();
            }
        }

        public void Deselect()
        {
            Clear();
            this.Log($"SelectedUnit = {SelectedUnit}", LogType.SelectFeature);
            OnSelect?.Invoke(SelectedUnit);
        }

        void Clear()
        {
            SelectedUnit = null;
        }
    }
}