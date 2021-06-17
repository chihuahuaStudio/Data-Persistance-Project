using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayGameOverSound()
    {
        audioSource.PlayOneShot(audioClips[0]);
    }

    public void PlayBrickSound()
    {
        
        audioSource.PlayOneShot(audioClips[1], 0.5f);
    }
 
    public void PlayBallSound()
    {
        audioSource.PlayOneShot(audioClips[2]);
    }

    public void PlayStartButtonSound()
    {
        audioSource.PlayOneShot(audioClips[3]);
    }

    public void PlayQuitButtonSound()
    {
        audioSource.PlayOneShot(audioClips[4]);
    }

    public void PlayMenuButtonSound()
    {
        audioSource.PlayOneShot(audioClips[5]);
    }

    public void PlayEnterNameSound()
    {
        audioSource.PlayOneShot(audioClips[6]);
    }
}

