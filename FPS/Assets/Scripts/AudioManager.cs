using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource BGM;
    public AudioSource SFX;

    public AudioClip bg;
    public AudioClip attacksfx;
    public AudioClip deathsfx;
    public static AudioManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BGM.clip = bg;
        BGM.Play();
    }

    public void playSFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
}
