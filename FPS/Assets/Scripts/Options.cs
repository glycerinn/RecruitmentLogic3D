using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public AudioMixer Audio;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider SFXSlider;

    void Start()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            loadVolume();
        }
        else
        {
            setMasterVolume();
            setMusicVolume();
            setSFXVolume();
        }
       
    }

    public void SetUp()
    {
        gameObject.SetActive(true);
    }

    public void setMasterVolume()
    {
        float volume = masterSlider.value;
        Audio.SetFloat("master", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }

    public void setMusicVolume()
    {
        float volume = musicSlider.value;
        Audio.SetFloat("Music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void setSFXVolume()
    {
        float volume = SFXSlider.value;
        Audio.SetFloat("SFX", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void loadVolume()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        musicSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("MusicVolume");

        setMasterVolume();
        setMusicVolume();
        setSFXVolume();
    }

    public void LoadMenu()
    {
        gameObject.SetActive(false);
    }
}

