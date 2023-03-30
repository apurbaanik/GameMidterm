using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    private float speed = 1;
    private float area = 4;
    private Vector2 startPoint;

    void Start()
    {
        startPoint = transform.position; // intial position of the block
    }

    void Update()
    {
        Vector2 block = startPoint; // start from the intial placed 
        block.x += Mathf.Sin(Time.time * speed) * area; // update the x axis with the speed
        transform.position = block; // change the position based on the updated x axis change
    }
}
