using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    private void Start()
    {
        if (musicSource.isPlaying == false)
        {
            musicSource.Play();
        }
        
    }
}
