using System.Collections.Generic;
using UnityEngine;

namespace RTS.Gathers
{
    public class ResourceView : MonoView<Resource>, IGatherable, ITickable
    {
        public SpriteRenderer Renderer;

        Dictionary<ResourceType, Color> viewSettings = new Dictionary<ResourceType, Color>()
        {
            {ResourceType.Wood, new Color(116f / 256f, 248f/ 256f, 113f/ 256f)}, // green
            {ResourceType.Crystall, new Color(113f/ 256f, 222f/ 256f, 248f/ 256f)}, // blue
        };

        public override void Set(Resource source)
        {
            base.Set(source);
            Renderer.color = viewSettings[Source.ResourceType];
        }

        public bool Gather(int ticksPerOne)
        {
            if (Source.IsGathered) 
                return false;
            
            var currentValue = Source.Ticks.Value - ticksPerOne;
            Source.Ticks.Value = Mathf.Max(0, currentValue);

            if (Source.Ticks.Value == 0)
            {
                Source.IsGathered = true;
                Destroy(gameObject);
                return true;
            }

            return false;
        }

        public void Tick()
        {
        }
    }
}