using System;

namespace RTS.Stats
{
    [Serializable]
    public class BoundedStatConfig
    {
        public StatType Type;  
        public float Value;
        public float MaxValue;
    }
}