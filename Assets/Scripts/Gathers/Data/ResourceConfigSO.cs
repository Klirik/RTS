using UnityEngine;

namespace RTS.Gathers
{
    [CreateAssetMenu(fileName = "Resource", menuName = "RTS/Gather", order = 1)]
    public class ResourceConfigSO : ScriptableObject
    {
        public ResourceType ResourceType;

        public int Ticks;
        
        [SerializeField] int amount;
        [SerializeField] bool isRandomAmount; 
        [SerializeField] int amountDelta;
        
        public int Amount => isRandomAmount ? Random.Range(amount - amountDelta, amount + amountDelta) : amount;
    }
}