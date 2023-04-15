using UnityEngine;

namespace RTS
{
    [CreateAssetMenu(fileName = "Skills", menuName = "RTS/Skills", order = 1)]
    public class UnitConfigSkillSO : ScriptableObject
    {
        public int Health = 4;
        public int MaxHealth = 4;
        public float Speed = 3;
        
        public float GatherDistance = 10;
    }
}