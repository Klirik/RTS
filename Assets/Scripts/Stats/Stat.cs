using UniRx;

namespace RTS.Stats
{
    public class Stat
    {
        public ReactiveProperty<float> Value;
    }

    public class BoundedStat : Stat
    {
        public ReactiveProperty<float> MaxValue;
    }

    public class RandomStat : Stat
    {
        public ReactiveProperty<float> DeltaValue;
    }
}