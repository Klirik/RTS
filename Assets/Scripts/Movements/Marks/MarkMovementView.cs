using DG.Tweening;
using UnityEngine;

namespace RTS
{
    public class MarkMovementView : MonoBehaviour
    {
        public SpriteRenderer renderer;

        Sequence sequence;

        Color? initColor;

        Color InitColor
        {
            get
            {
                initColor ??= renderer.color;
                return initColor.Value;
            }
        }
        
        public void Show(Vector3 position)
        {
            gameObject.SetActive(true);
            transform.position = position;

            renderer.color = InitColor;
            
            sequence?.Kill();
            sequence = DOTween.Sequence()
                .Append(renderer.DOFade(0f, 1f))
                .Append(renderer.DOFade(1f, 1f))
                .SetLoops(3);
        }
        
        public void Hide()
        {
            sequence?.Kill();
            gameObject.SetActive(false);
        }
    }
}