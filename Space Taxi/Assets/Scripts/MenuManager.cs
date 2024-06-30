using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioSource _buttonSound;


    public void GameLoad()
    {
        SceneManager.LoadScene(1);
        _buttonSound.PlayOneShot(_buttonSound.clip);
        Time.timeScale = 1;
    }
    public void GameExit()
    {
        Application.Quit();
        _buttonSound.PlayOneShot(_buttonSound.clip);
    }

    public void ToSettings()
    {
        SceneManager.LoadScene(3);
        _buttonSound.PlayOneShot(_buttonSound.clip);
    }
}
