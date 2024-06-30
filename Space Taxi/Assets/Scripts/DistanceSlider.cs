using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceSlider : MonoBehaviour
{
    [SerializeField] private Slider _distanceSlider;

    private void Start()
    {
        _distanceSlider.value = 0;
    }

    private void Update()
    {
        _distanceSlider.value += Time.deltaTime/100;
    }
}
