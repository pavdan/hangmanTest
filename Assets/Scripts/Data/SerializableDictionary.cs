using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Hangman.Data
{
    [Serializable]
    public abstract class SerializableDictionary<TKey, TValue> : ISerializationCallbackReceiver
    {
        [SerializeField] private TKey[] _keys;
        [SerializeField] private TValue[] _values;
        public Dictionary<TKey, TValue> Dictionary = new();

        public void OnBeforeSerialize()
        {
            _keys = Dictionary.Keys.ToArray();
            _values = Dictionary.Values.ToArray();
        }

        public void OnAfterDeserialize()
        {
            for (int i = 0; i < _keys.Length; i++)
                Dictionary.Add(_keys[i], _values[i]);
        }
    }
}