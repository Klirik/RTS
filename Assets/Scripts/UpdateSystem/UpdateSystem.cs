using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace RTS
{
    public class UpdateSystem : MonoBehaviour
    {
        HashSet<ITickable> tickablesToDelete = new HashSet<ITickable>();
        UpdateManager manager;
        [Inject]
        void Init(UpdateManager manager)
        {
            this.manager = manager;
        }
        void Update()
        {
            foreach (var tickable in manager.Collection)
            {
                if (tickable != null)
                    tickable.Tick();
                else
                    tickablesToDelete.Add(tickable);
            }

            RemoveNullEntity();
        }

        void RemoveNullEntity()
        {
            if (!tickablesToDelete.Any()) return;

            foreach (var tickable in tickablesToDelete)
            {
                manager.Remove(tickable);
            }

            tickablesToDelete.Clear();
        }
    }
}