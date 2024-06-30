using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualController : MonoBehaviour
{
    [SerializeField] private GameObject _vrCam;
    [SerializeField] private GameObject _UI;
    [SerializeField] private GameObject _mainCam;
    [SerializeField] private GameObject _titre;
    public GameObject _windowDialog;

    private void Awake()
    {
        _vrCam.SetActive(true);
        _mainCam.SetActive(false);
        _UI.SetActive(false);
        _titre.SetActive(true);
        _windowDialog.SetActive(false);
    }
    private void Update()
    {
        Invoke("TitreOff", 5f);
        Invoke("StartWindow", 15f);
        Invoke("CameraOn", 25f);
        Invoke("UIOn", 25f);
    }

    private void CameraOn()
    {
        _vrCam.SetActive(false);
        _mainCam.SetActive(true);
    }
    private void UIOn()
    {
        _UI.SetActive(true);
    }
    private void TitreOff()
    {
        _titre.SetActive(false);
    }

    private void StartWindow()
    {
        _windowDialog.SetActive(true);
    }
}
