using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    public static bool GameisPaused;
    public GameObject pauseMenuUI;
    public AudioMixer Audio;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider SFXSlider;

    void Start()
    {
        GameisPaused = false;
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
        Cursor.lockState =CursorLockMode.Locked;
    }

    public void Pause()
    {
        Cursor.lockState =CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
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

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
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
}
