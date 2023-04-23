using RTS.Stats;
using RTS.Weapons;
using UnityEngine;

namespace RTS
{
    [CreateAssetMenu(fileName = "Config", menuName = "RTS/Unit", order = 1)]
    public class UnitConfigSO : ScriptableObject
    {
        public StatsConfig StatsConfig;

        public UnitConfigStatSO statSO;
        public WeaponConfigSO WeaponSO;
    }
}