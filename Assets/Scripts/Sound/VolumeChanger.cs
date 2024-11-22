using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VolumeChanger : MonoBehaviour
{
    public static VolumeChanger Instance;
    
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    
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
    }

    private void Start()
    {
        VolumeSetup();
    }

    private void VolumeSetup()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMasterVolume();
            SetMusicVolume();
            SetSFXVolume();
        }
    }

    private void LoadVolume()
    {
        if (musicSlider != null) musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        if (sfxSlider != null) sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        SetMasterVolume();
        SetMusicVolume();
        SetSFXVolume();
    }

    public void SetMasterVolume()
    {
        float volume = (masterSlider == null) ? PlayerPrefs.GetFloat("masterVolume") : masterSlider.value;
        if (volume == 0) volume = 0.0001f;
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("masterVolume", volume);
    }
    
    public void SetMusicVolume()
    {
        float volume = (musicSlider == null) ? PlayerPrefs.GetFloat("musicVolume") : musicSlider.value;
        if (volume == 0) volume = 0.0001f;
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = (sfxSlider == null) ? PlayerPrefs.GetFloat("sfxVolume") : sfxSlider.value;
        if (volume == 0) volume = 0.0001f;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }
}
