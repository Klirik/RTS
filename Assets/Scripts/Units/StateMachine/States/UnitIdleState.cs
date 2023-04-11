﻿using DG.Tweening;
using RTS.UI;
using UnityEngine;

namespace RTS
{
    public class UnitIdleState : State
    {
        
    }
    
    public class UnitDeathState : State
    {
        readonly UnitView unitView;

        public bool IsDeathing;
        
        public UnitDeathState(UnitView unitView)
        {
            this.unitView = unitView;
        }
        
        // WIP:
        // Sequence sequence;
        // public override void Enter()
        // {
        //     base.Enter();
        //     var startColor = unitView.renderer.color;
        //     sequence?.Kill();
        //     sequence = DOTween.Sequence()
        //         .Append(unitView.renderer.DOColor(Color.white, 0.1f))
        //         .Append(unitView.renderer.DOColor(startColor, 0.1f))
        //         .SetLoops(2)
        //         .OnComplete(() => IsDeathing = false);
        //     IsDeathing = true;
        // }
        //
        // public override void Exit()
        // {
        //     base.Exit();
        //     sequence?.Kill();
        //     IsDeathing = false;
        // }
    }
}