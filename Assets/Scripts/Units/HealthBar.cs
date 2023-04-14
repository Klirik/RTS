using System;
using UnityEngine;
using UniRx;
using Unit = RTS.Units.Unit;

namespace RTS.UI
{
    public class HealthBar : MonoView<Unit>
    {
        public Transform line;

        CompositeDisposable changeHealthStream = new CompositeDisposable();
        public override void Set(Unit source)
        {
            changeHealthStream.Clear();
            
            base.Set(source);
            
            SetValue(source.Health.Value, source.MaxHealth.Value);
            source.Health.Subscribe(_ => SetValue(source.Health.Value, source.MaxHealth.Value)).AddTo(changeHealthStream);
            source.MaxHealth.Subscribe(_ => SetValue(source.Health.Value, source.MaxHealth.Value)).AddTo(changeHealthStream);
        }

        void SetValue(int health, int maxHealth)
        {
            var normalized = (float) health / maxHealth;
            line.transform.localScale = new Vector3(normalized > 0 ? normalized : 0, 1f);
        }

        void OnDestroy()
        {
            changeHealthStream.Dispose();
        }
    }
}