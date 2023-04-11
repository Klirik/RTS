using System;
using UnityEngine;
using Zenject;

namespace RTS
{
    public class MarkMovementSystem : IInitializable, IDisposable
    {
        readonly ClickMovementSystem clickMovementSystem;
        readonly MarkMovementView prefab;

        MarkMovementView mark;
        
        public MarkMovementSystem(ClickMovementSystem clickMovementSystem, MarkMovementView prefab)
        {
            this.clickMovementSystem = clickMovementSystem;
            this.prefab = prefab;
        }

        public void Initialize()
        {
            mark = GameObject.Instantiate(prefab);
            mark.gameObject.SetActive(false);
            clickMovementSystem.OnMove += ShowMark;
        }

        void ShowMark(Transform transform, Vector3 endPosition)
        {
            mark.Show(endPosition);
        }

        public void Dispose()
        {
            clickMovementSystem.OnMove -= ShowMark;
        }
    }
}