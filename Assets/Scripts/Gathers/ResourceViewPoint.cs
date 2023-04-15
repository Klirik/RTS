using UnityEngine;
using Zenject;

namespace RTS.Gathers
{
    public class ResourceViewPoint : MonoBehaviour
    {
        ResourceViewFactory resourceViewFactory;
        ResourceFactory resourceFactory;
        public ResourceConfigSO ResourceConfig;
        
        ResourceView resourceView;
        
        [Inject]
        void InnerInit(ResourceViewFactory resourceViewFactory, ResourceFactory resourceFactory)
        {
            this.resourceViewFactory = resourceViewFactory;
            this.resourceFactory = resourceFactory;
        }

        void Awake()
        {
            var resource = resourceFactory.Create(ResourceConfig);
            resourceView = resourceViewFactory.Create(resource, transform);
        }
    }
}