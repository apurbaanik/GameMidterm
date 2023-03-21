using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl : MonoBehaviour
{
    // Player Variables
    private Rigidbody2D _rigidbody;
    public int playerJumpVal = 10;
    public int playerSpeed = 5;
    

    // Variables to manage jumping
    public Transform playerShoes;
    public LayerMask terrain;
    bool onTerrain = false;

    //Start
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Fixed Update
    void FixedUpdate() {
        float horizontalMovement = Input.GetAxis("Horizontal") * playerSpeed;
        _rigidbody.velocity = new Vector2(horizontalMovement, _rigidbody.velocity.y);
    }

    // Update
    void Update()
    {
        onTerrain = Physics2D.OverlapCircle(playerShoes.position, .3f, terrain);
        if(onTerrain && Input.GetButton("Jump")){
            _rigidbody.AddForce(new Vector2(0,playerJumpVal));
        }
    }
}
