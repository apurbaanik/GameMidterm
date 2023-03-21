using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl : MonoBehaviour
{
    // Player Variables
    private Rigidbody2D _rigidbody;
    public int playerJumpVal = 10;
    public int playerSpeed = 5;

    // Animation variables
    private Animator _animator;
    

    // Variables to manage jumping
    public Transform playerShoes;
    public LayerMask terrain;
    bool onTerrain = false;

    //Start
    void Start()
    {   
        //Get animator component
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Fixed Update
    void FixedUpdate() {
        float horizontalMovement = Input.GetAxis("Horizontal") * playerSpeed;
        _rigidbody.velocity = new Vector2(horizontalMovement, _rigidbody.velocity.y);

        float xDirection = transform.localScale.x;

        if (horizontalMovement < 0 && xDirection > 0 || horizontalMovement > 0 && xDirection < 1){
            transform.localScale *= new Vector2(-1,1);
        }

        _animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));
    }

    // Update
    void Update()
    {
        onTerrain = Physics2D.OverlapCircle(playerShoes.position, .2f, terrain);
        if(onTerrain && Input.GetButton("Jump")){
            _rigidbody.AddForce(new Vector2(0,playerJumpVal));
        }
    }
}
