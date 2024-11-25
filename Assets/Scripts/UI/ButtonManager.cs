using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
	public static ButtonManager Instance;
    
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
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetSceneMainGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void SetSceneTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void SetSceneMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayButtonSound()
    {
        SfxManager.Instance.PlaySound("MouseClickSFX");
    }
    
    public void PlayPaperCrumpleSound()
    {
        SfxManager.Instance.PlaySound("PaperCrumple");
    }

    public void PlayNotificationSound()
    {
        SfxManager.Instance.PlaySound("NotificationSound");
    }

    public void PlayHireSound()
    {
        SfxManager.Instance.PlaySound("GoodSFX");
    }

    public void PlayFireSound()
    {
        SfxManager.Instance.PlaySound("CrySound");
    }

    public void ToggleGameObjectActive(GameObject toggle)
    {
        toggle.SetActive(!toggle.activeInHierarchy);
    }

    public void SetMasterVolumeOnVolumeChanger()
    {
        VolumeChanger.Instance.SetMasterVolume();
    }
    public void SetMusicVolumeOnVolumeChanger()
    {
        VolumeChanger.Instance.SetMusicVolume();
    }
    public void SetSFXVolumeOnVolumeChanger()
    {
        VolumeChanger.Instance.SetSFXVolume();
    }
}
