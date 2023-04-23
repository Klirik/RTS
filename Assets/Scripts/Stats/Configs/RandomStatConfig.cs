using System;
using UnityEngine;

namespace RTS.Stats
{
    [Serializable]
    public class RandomStatConfig
    {
        public StatType Type;  
        public float MinValue;
        [Tooltip("MinValue+Random(Delta) = CurrentValue")]
        public float Delta;
    }
}