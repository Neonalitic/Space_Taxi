using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private AudioSource _pauseSound;
    [SerializeField] private AudioSource _nitroSound;
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _endPanel;
    [SerializeField] private Slider _distanceSlider;
    [SerializeField] private GameObject _dialog2;
    [SerializeField] private AudioSource[] _dialogs;

    private void Start()
    {
        _pausePanel.SetActive(false);
        _endPanel.SetActive(false);
        _dialog2.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale > 0)
            {
                Cursor.lockState = CursorLockMode.Confined;
                _pausePanel.SetActive(true);
                _nitroSound.Pause();
                Time.timeScale = 0;
                foreach (AudioSource replic in _dialogs)
                {
                    replic.Pause();
                }
            }
        }
        if (_distanceSlider.value >= 1)
        {
            _dialog2.SetActive(true);
            Invoke("End", 5f);
        }
    }

    public void ExitPause()
    {
        _pauseSound.PlayOneShot(_pauseSound.clip);
        _pausePanel.SetActive(false);
        _nitroSound.UnPause();
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        foreach (AudioSource replic in _dialogs)
        {
            replic.UnPause();
        }
    }

    public void ToMenu()
    {
        _pauseSound.PlayOneShot(_pauseSound.clip);
        SceneManager.LoadScene(0);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    private void End()
    {
            Cursor.lockState = CursorLockMode.Confined;
            _endPanel.SetActive(true);
            _nitroSound.Stop();
            Time.timeScale = 0;
    }
}
