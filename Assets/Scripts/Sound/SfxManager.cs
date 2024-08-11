using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SfxManager : MonoBehaviour
{
    public static SfxManager instance;
    HashMap myHashMap = new HashMap();

    [SerializeField] List<AudioClip> myClips = new List<AudioClip>();
    [SerializeField] AudioSource audioSource;

    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();

        //Populate the hashmap with our audio clips
        for (int i = 0; i < myClips.Count; i++)
        {
            myHashMap.AddToHashMap(myClips[i]);

        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void PlaySound(string soundName)
    {
        AudioClip clip = myHashMap.GetValueFromKey(soundName);
        audioSource.PlayOneShot(clip);
    }
}
