using UnityEngine;

namespace RTS
{
    [CreateAssetMenu(fileName = "Skills", menuName = "RTS/Skills", order = 1)]
    public class UnitConfigSkillSO : ScriptableObject
    {
        public int Health;
        public int MaxHealth;
        public float Speed;
    }
}