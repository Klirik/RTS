namespace RTS
{
    public class BoundedInt
    {
        int currentValue;
        public int Value
        {
            get => currentValue;
            set => currentValue = value > MaxValue ? MaxValue : value;
        }

        public int MaxValue { get; private set; }

        public BoundedInt(int initialValue, int maxValue)
        {
            MaxValue = maxValue;
            Value = initialValue;
        }

        public void SetMaxValue(int newMaxValue) => MaxValue = newMaxValue;
    }
}