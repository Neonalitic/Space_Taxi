using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _fuelPanel;
    [SerializeField] private GameObject _baseHint;
    [SerializeField] private GameObject _oreHint;

    [SerializeField] private GameObject _taskPanel;
    [SerializeField] private GameObject _taskButton;

    [SerializeField] private AudioSource _pauseSound;
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _portalCam;

    [SerializeField] private TMP_Text _fuelText;
    [SerializeField] private GameObject _cisternOn;
    [SerializeField] private GameObject _cisternOff;
    [SerializeField] private TMP_Text _hintsOn;
    [SerializeField] private TMP_Text _task2;

    [SerializeField] private AudioSource _voice;
    [SerializeField] private AudioSource[] _dialogs;

    [SerializeField] private ParticleSystem _portal;

    [SerializeField] private GameObject _hints;
    [SerializeField] private GameObject _check;
    [SerializeField] private GameObject _light;
    bool _isHint;
    bool _isTask;

    private void Start()
    {
        _pausePanel.SetActive(false);
        _taskPanel.SetActive(false);
        _taskButton.SetActive(true);
        _cisternOff.SetActive(true);
        _cisternOn.SetActive(false);
        _portalCam.SetActive(false);
        _portal.Stop();
        _hints.SetActive(true);
        _check.SetActive(true);
        _isHint = true;
        _isTask = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Confined;
            _pausePanel.SetActive(true);
            Time.timeScale = 0;
            _camera.GetComponent<CameraController>().enabled = false;
            _light.GetComponent<Lighting>().enabled = false;
            _baseHint.SetActive(false);
            _oreHint.SetActive(false);
            _voice.Pause();
            foreach(AudioSource replic in _dialogs)
            {
                replic.Pause();
            }
        }

        if (_fuelText.text == "Куплено")
        {
            _cisternOff.SetActive(false);
            _cisternOn.SetActive(true);
            _task2.color = Color.green;
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            if (!_isTask)
            {
                _taskPanel.SetActive(true);
                _taskButton.SetActive(false);
                _isTask = !_isTask;
            }
            else
            {
                _taskPanel.SetActive(false);
                _taskButton.SetActive(true);
                _isTask = !_isTask;
            }
        }
    }
        public void ToMenu()
        {
            _pauseSound.PlayOneShot(_pauseSound.clip);
            SceneManager.LoadScene(0);
        }
        public void ExitPause()
        {
            _pauseSound.PlayOneShot(_pauseSound.clip);
            _pausePanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            _camera.GetComponent<CameraController>().enabled = true;
            _light.GetComponent<Lighting>().enabled = true;
            if (!_voice.isPlaying)
            {
                _voice.UnPause();
            foreach (AudioSource replic in _dialogs)
            {
                replic.UnPause();
            }
        }
    }

        public void ExitFuel()
        {
            _pauseSound.PlayOneShot(_pauseSound.clip);
            _fuelPanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            _camera.GetComponent<CameraController>().enabled = true;
            _baseHint.SetActive(false);
        }

        public void BuyFuel()
        {
            if (_fuelText.color == Color.green)
            {
                _pauseSound.PlayOneShot(_pauseSound.clip);
                _fuelPanel.SetActive(false);
                _fuelText.text = "Куплено";
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                _camera.GetComponent<CameraController>().enabled = true;
                _portal.Play();
                _portalCam.SetActive(true);
                Invoke("CamOn", 5f);
            }
        }

    public void HintsOn()
    {
        if(_isHint)
        {
            _hintsOn.text = "Включить подсказки";
            _check.SetActive(false);
            _hints.SetActive(false);
            _isHint = !_isHint;
        }
        else
        {
            _hintsOn.text = "Скрыть подсказки";
            _check.SetActive(true);
            _hints.SetActive(true);
            _baseHint.SetActive(false);
            _oreHint.SetActive(false);
            _isHint = !_isHint;
        }
    }

    private void CamOn()
    {
        _portalCam.SetActive(false);
    }
}
