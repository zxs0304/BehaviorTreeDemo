using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTrees
{
    public class Blackboard : MonoBehaviour
    {
        [SerializeField]private Dictionary<string, object> data = new();

        public T Get<T>(string key)
        {
            if (data.TryGetValue(key, out object value)) return (T)value;
            return default;
        }

        public void Add<T>(string key, T value)
        {
            data[key] = value;
        }

        public bool Remove(string key)
        {
            bool hasKey = data.ContainsKey(key);
            if (hasKey) data.Remove(key);
            return hasKey;
        }

    }
}