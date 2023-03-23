using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    float speed = 0.1f;
    public Renderer ground;

    void Update()
    {
        ground.material.mainTextureOffset += new Vector2(Time.deltaTime*speed, 0);
    }
}
