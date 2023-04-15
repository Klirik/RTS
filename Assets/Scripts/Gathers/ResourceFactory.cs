using Zenject;

namespace RTS.Gathers
{
    public class ResourceFactory : IFactory<ResourceConfigSO, Resource>
        , IFactory<RestorableResourceConfigSO, Resource>
    {
        public Resource Create(ResourceConfigSO config) 
            => new Resource(config.Ticks, config.Amount, config.ResourceType);

        public Resource Create(RestorableResourceConfigSO config) 
            => new RestorableResource(config.Ticks, config.Amount, config.ResourceType, config.RestoreTicks);
    }
}