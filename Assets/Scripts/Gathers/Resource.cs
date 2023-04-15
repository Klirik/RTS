using UniRx;

namespace RTS.Gathers
{
    public class Resource
    {
        public ResourceType ResourceType;

        public int ConfigTick { get; } 
        public ReactiveProperty<int> Ticks;
        
        public ReactiveProperty<int> Amount;

        public bool IsGathered;
        
        public Resource(int ticks, int amount, ResourceType resourceType)
        {
            ConfigTick = ticks;
            Ticks = new ReactiveProperty<int>(ticks);
            Amount = new ReactiveProperty<int>(amount);
            ResourceType = resourceType;
        }
    }
}
