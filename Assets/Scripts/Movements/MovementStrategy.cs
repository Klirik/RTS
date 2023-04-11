using UnityEngine;

namespace RTS
{
    public abstract class MovementStrategy<TViewEntity> : MonoBehaviour
    {
        public TViewEntity view;

        public abstract void MoveTo(Vector3 position, float duration);
        public abstract void MoveRandomly();
    }
}