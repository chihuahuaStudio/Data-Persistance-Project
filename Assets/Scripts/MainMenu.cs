using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadMainMenu()
    {
        
        SceneManager.LoadScene(0);
        
    }

    public void PlayMenuSound()
    {
        AudioManager.Instance.PlayMenuSound();
    }
}
