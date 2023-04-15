using UniRx;

namespace RTS.Currencies
{
    public class Currency
    {
        public ReactiveProperty<int> Value;

        public Currency(int initialValue)
        {
            Value = new ReactiveProperty<int>(initialValue);
        }
    }
}