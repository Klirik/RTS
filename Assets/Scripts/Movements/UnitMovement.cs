using System;
using DG.Tweening;
using RTS.UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RTS
{
    public class UnitMovement : MovementStrategy<UnitView>
    {
        public event Action OnEnd;
        
        Sequence sequence;

        public override void MoveTo(Vector3 position, float speed)
        {
            var duration = (position - view.transform.position).magnitude / speed;

            sequence?.Kill();
            sequence = DOTween.Sequence()
                .Append(view != null ? view.transform.DOMove(position, duration).SetEase(Ease.Linear) : null)
                .OnComplete(Stop);
        }

        public override void MoveRandomly()
        {
            Vector3 newPoint = new Vector3(Random.Range(1f, 10f), Random.Range(1f, 10f), 0);
            MoveTo(newPoint, view.Source.Speed);
        }

        public void Stop()
        {
            sequence?.Kill();
            OnEnd?.Invoke();
        }

        protected void OnDestroy()
        {
            sequence?.Kill();
        }
    }
}