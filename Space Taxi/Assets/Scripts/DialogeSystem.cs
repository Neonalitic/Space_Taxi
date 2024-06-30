using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogeSystem : MonoBehaviour
{
    public GameObject _windowDialog;
    public TMP_Text _textDialog;
    public TMP_Text _name;
    public GameObject _lastVoice;
    
    public GameObject[] _voices;
    public string[] _message;
    public string[] _nameCount;
    public int _numberDialog = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _lastVoice.SetActive(false);
            _numberDialog++;
            _textDialog.text = _message[_numberDialog];
            _name.text = _nameCount[_numberDialog];
            _voices[_numberDialog].SetActive(true);
            
            if (_numberDialog == _message.Length - 1)
            {
                _windowDialog.SetActive(false);
            }
        }
    }
}