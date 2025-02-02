namespace RehvidGames.Utilities
{
    using UnityEngine;

    public class CooldownTimer: MonoBehaviour
    {
        private float lastTime = -Mathf.Infinity; 
        private float lastTimeFixed = -Mathf.Infinity;
        
        public void Reset() => lastTime = Time.time;
        
        public void ResetFixed() => lastTimeFixed = Time.fixedTime;
        
        public bool HasElapsed(float delay) => Time.time - lastTime >= delay;
        
        public bool HasElapsedFixed(float delay) => Time.fixedTime - lastTimeFixed >= delay;
        
        public bool IsInitializedFixed() => !float.IsNegativeInfinity(lastTimeFixed) && lastTimeFixed > 0.0f;
    }
}