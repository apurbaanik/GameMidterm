using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminateObject : MonoBehaviour
{
    public float duration = 2;
    void Start()
    {
        Destroy(gameObject, duration);
    }

}