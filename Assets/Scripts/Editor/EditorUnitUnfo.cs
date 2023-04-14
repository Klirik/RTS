using System;
using RTS.UI;
using UnityEditor;
using UnityEngine;

namespace RTS.Editors
{
    [CustomEditor(typeof(UnitView))]
    public class EditorUnitUnfo : Editor
    {
        void OnSceneGUI()
        {
            var unitView = (UnitView) target;
            
            if(unitView == null)
                return;

            GUIStyle style = new GUIStyle() ;
            style.fontSize = 15;
            style.richText = true;
            
            string text = String.Empty;
            if (unitView.StateMachine != null)
                text = $"<color=red>{unitView.StateMachine.CurrentState.GetType().Name}</color>";
                
            Handles.Label(unitView.transform.position + new Vector3(-0.5f, 1.5f, 0) ,text, style);
        }
    }
}
