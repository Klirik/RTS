using UnityEngine;

namespace RTS.Gathers
{
    [CreateAssetMenu(fileName = "Resource", menuName = "RTS/Gather", order = 1)]
    public class RestorableResourceConfigSO : ResourceConfigSO
    {
        [SerializeField] int restoreTicks;
        [SerializeField] bool isRandomRestoreTicks; 
        [SerializeField] int restoreTicksDelta;
        
        public int RestoreTicks => isRandomRestoreTicks 
            ? Random.Range(restoreTicks - restoreTicksDelta, restoreTicks + restoreTicksDelta) 
            : restoreTicks;
    }
}