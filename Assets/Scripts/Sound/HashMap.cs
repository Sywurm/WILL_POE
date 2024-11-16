using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class HashMap<K, V>
{
    List<K> keys = new List<K>();
    List<V> values = new List<V>();

    public void AddToHashMap(K key, V value)
    {
        keys.Add(key);
        values.Add(value);
    }

    public V GetValueFromKey(K key)
    {
        int index = GetIndexOfKey(key);
        return values[index];
    }

    public int GetIndexOfKey(K key) => keys.IndexOf(key);
}
