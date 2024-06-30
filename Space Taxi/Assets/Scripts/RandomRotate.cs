using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotate : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0, Random.Range(0.01f, 0.1f), 0);
    }
}
