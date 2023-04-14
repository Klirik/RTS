using RTS.Weapons;
using UnityEngine;

namespace RTS
{
    [CreateAssetMenu(fileName = "Config", menuName = "RTS/Unit", order = 1)]
    public class UnitConfigSO : ScriptableObject
    {
        public UnitConfigSkillSO SkillSO;
        public WeaponConfigSO WeaponSO;
    }
}