using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class HashMap : MonoBehaviour
{
    //Variables for the keys and values

    //Array
    //string[] keys;
    //AudioClip[] values;

    //List
    List<string> keys = new List<string>();
    List<AudioClip> values = new List<AudioClip>();

    //Possible populate of hashmap method
    public void AddToHashMap(AudioClip _clip)
    {
        //take audio clip instead of name as string as you can get the name using clip.name
        keys.Add(_clip.name);   //Name of audioClip
        values.Add(_clip);  //Sound of audio 

    }

    //Retreive value using the keys
    public AudioClip GetValueFromKey(string _key)
    {
        int index = GetIndexOfKey(_key);    //Call method to get index of key
        AudioClip clip = values[index];     //Use index of key to get correct audioclip
        return clip;    //return clip
    }

    public int GetIndexOfKey(string _key)
    {
        int index = keys.IndexOf(_key);     //get index of key
        return index;
    }

    public void Start() //Display values of hashmap in console for testing
    {
        for (int i = 0; i < keys.Count; i++)
        {
            Debug.Log("Keys: " + keys[i] + ", Values: " + values[i]);
        }
    }
}
