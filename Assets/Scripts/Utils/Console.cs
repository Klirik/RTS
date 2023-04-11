using UnityEngine;

namespace RTS.Utils
{
    public static class Console
    {
        public static void Log(this object obj, string msg, LogType logType = LogType.None)
        {
            Debug.Log($"{logType} {obj.GetType().Name}: {msg}");
        }
    }
}