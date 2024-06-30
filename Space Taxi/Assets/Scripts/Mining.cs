using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Outline))]
public class Mining : MonoBehaviour
{
    private Outline _outline;
    public AudioSource _brakeStone;
    public GameObject _hint;
    private void Start()
    {
        _outline = GetComponent<Outline>();
        _outline.OutlineWidth = 0;
    } 

    public void Update()
    {
        if (_outline.OutlineWidth > 0)
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (transform.localScale.x < 1f)
                {
                    Destroy(gameObject);
                    _brakeStone.PlayOneShot(_brakeStone.clip);
                }
            }
        }
    }

}
