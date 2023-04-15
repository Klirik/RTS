using UniRx;

namespace RTS.Gathers
{
    public class RestorableResource : Resource
    {
        public ReactiveProperty<float> Restore;

        public RestorableResource(int ticks, int amount, ResourceType resourceType, float restore ) 
            : base(ticks, amount, resourceType)
        {
            Restore = new ReactiveProperty<float>(restore);
        }
    }
}