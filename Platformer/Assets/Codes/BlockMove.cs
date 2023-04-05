using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    public int blockSpeed = 1;
    private Vector2 midPoint;

    void Start()
    {
        midPoint = transform.position; // intial position of the block
    }

    void Update()
    {
        Vector2 block = midPoint; // start from the intial placed 
        block.x += Mathf.Sin(Time.time * blockSpeed) * 4; // update the x axis with the speed
        transform.position = block; // change the position based on the updated x axis change
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")){
            other.transform.SetParent(transform);
        }
    }
    
    void OnCollisionExit2D(Collision2D collider) {
        if (collider.gameObject.CompareTag("Player")){
            collider.transform.SetParent(null);
        }
    }
}
