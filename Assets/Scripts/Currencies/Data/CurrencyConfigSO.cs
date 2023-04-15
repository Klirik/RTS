using RTS.Gathers;
using UnityEngine;

namespace RTS.Currencies
{
    [CreateAssetMenu(fileName = "Currency", menuName = "RTS/Currency", order = 1)]
    public class CurrencyConfigSO : ScriptableObject
    {
        public ResourceType Type;
        public int InitialValue;
    }
}