using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserControl : MonoBehaviour
{   
    //Player Bullets
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public int bulletSpeed = 600;
    
    // Player Variables
    private Rigidbody2D _rigidbody;
    public int playerJumpVal = 10;
    public int playerSpeed = 5;

    public float xDirection;

    bool turned = false;

    // Animation variables
    private Animator _animator;
    

    // Variables to manage jumping
    public Transform playerShoes;
    public LayerMask terrain;
    bool onTerrain = false;

    //Start
    void Start()
    {   
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();  //Get animator component
    }

    // Fixed Update
    void FixedUpdate() {
        float horizontalMovement = Input.GetAxis("Horizontal") * playerSpeed;
        _rigidbody.velocity = new Vector2(horizontalMovement, _rigidbody.velocity.y);

        xDirection = transform.localScale.x;


        if (horizontalMovement < 0 && xDirection > 0 || horizontalMovement > 0 && xDirection < 1){
            transform.localScale *= new Vector2(-1,1);
        }

        _animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));

        onTerrain = Physics2D.OverlapCircle(playerShoes.position, .2f, terrain);
        _animator.SetBool("Grounded", onTerrain);

        if(onTerrain && Input.GetButton("Jump")){
            _rigidbody.AddForce(new Vector2(0,playerJumpVal));
        }
    }

    // Update
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            
            
            GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(xDirection*bulletSpeed, 0));
            
            
            
        }
        
        // Reload scene if you fall off the map
        if(_rigidbody.position.y < -20){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
