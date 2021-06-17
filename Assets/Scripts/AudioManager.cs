using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource myAudioSource;
    public AudioClip enterNameSound, startSound, quitSound, menuSound, ballSound, brickSound, gameOverSound;

    public static AudioManager Instance;

    private void Awake()
    {
       if(Instance!=null)
       {
           Destroy(gameObject);
       }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayNameSound()
    {
        myAudioSource.PlayOneShot(enterNameSound);
    }

    public void PlayStartSound()
    {
        myAudioSource.PlayOneShot(startSound);
    }

    public void PlayQuitSound()
    {
        myAudioSource.PlayOneShot(quitSound);
    }

    public void PlayMenuSound()
    {
        myAudioSource.PlayOneShot(menuSound);
    }

    public void PlayBallSound()
    {
        myAudioSource.PlayOneShot(ballSound);
    }

    public void PlayBrickSound()
    {
        myAudioSource.PlayOneShot(brickSound);
    }

    public void PlayGameOverSound()
    {
        myAudioSource.PlayOneShot(gameOverSound);
    }

}
