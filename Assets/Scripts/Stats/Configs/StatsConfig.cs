using System;
using System.Collections.Generic;

namespace RTS.Stats
{
    [Serializable]
    public class StatsConfig
    {
        public List<StatConfig> StatConfigs = new List<StatConfig>();
        public List<BoundedStatConfig> BoundedStatConfigs = new List<BoundedStatConfig>();
        public List<RandomStatConfig> RandomStatConfigs = new List<RandomStatConfig>();
    }
}