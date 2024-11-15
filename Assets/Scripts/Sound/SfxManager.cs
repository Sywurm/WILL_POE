using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SfxManager : MonoBehaviour
{
    public static SfxManager Instance;

    HashMap<string, AudioClip> m_sfxHash = new();

    [SerializeField] List<AudioClip> _clips = new List<AudioClip>();
    [SerializeField] AudioSource _audioSource;

    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
        // audioSource = GetComponent<AudioSource>();

        // Populate the hashmap with our audio clips
        for (int i = 0; i < _clips.Count; i++)
        {
            m_sfxHash.AddToHashMap(_clips[i].name, _clips[i]);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void PlaySound(string soundName)
    {
        AudioClip clip = m_sfxHash.GetValueFromKey(soundName);
        
        _audioSource.PlayOneShot(clip);
    }
}
