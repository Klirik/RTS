using UnityEngine;
using Zenject;

namespace RTS.Gathers
{
    public class ResourceViewFactory : IFactory<Resource, Transform, ResourceView>,
        IFactory<Resource, Transform, ResourceView, ResourceView>
    {
        DiContainer diContainer;
        ResourceView prefab;
        readonly UpdateManager updateManager;

        public ResourceViewFactory(DiContainer diContainer, ResourceView prefab, UpdateManager updateManager)
        {
            this.diContainer = diContainer;
            this.prefab = prefab;
            this.updateManager = updateManager;
        }
        public ResourceView Create(Resource model, Transform point) => Create(model, point, prefab);

        public ResourceView Create(Resource model, Transform point, ResourceView prefab)
        {
            var resourceView = diContainer.InstantiatePrefabForComponent<ResourceView>(prefab);
            resourceView.transform.position = point.position;
            resourceView.Set(model);
            updateManager.Add(resourceView);
            return resourceView;
        }
    }
}