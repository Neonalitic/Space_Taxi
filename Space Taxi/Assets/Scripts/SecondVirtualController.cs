using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondVirtualController : MonoBehaviour
{
    [SerializeField] private GameObject _mainCam;
    [SerializeField] private GameObject _firstCam;
    [SerializeField] private GameObject _UI;
    [SerializeField] private GameObject _spawn;
    [SerializeField] private GameObject _flight;
    [SerializeField] private GameObject _dialogs;

    private void Start()
    {
        _mainCam.SetActive(false);
        _firstCam.SetActive(true);
        _UI.SetActive(false);
        _spawn.SetActive(false);
        _dialogs.SetActive(false);
        _flight.GetComponent<SecondCarController>().enabled = false;
        Invoke("DialogOn", 2f);
        Invoke("CameraOn", 15f);
    }

    private void DialogOn()
    {
        _dialogs.SetActive(true);
    }
    private void CameraOn()
    {
        _mainCam.SetActive(true);
        _firstCam.SetActive(false);
        _UI.SetActive(true);
        _spawn.SetActive(true);
        _flight.GetComponent<SecondCarController>().enabled = true;
    }
}
