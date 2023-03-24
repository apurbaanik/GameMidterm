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


    // Animation variables
    private Animator _animator;
    private AudioSource _audioSource;
    

    // Variables to manage jumping
    public Transform playerShoes;
    public LayerMask terrain;
    bool onTerrain = false;

    //Start
    void Start()
    {   
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();  //Get animator component
        _audioSource = GetComponent<AudioSource>();
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
        if (Input.GetKeyDown("e")){
            GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(xDirection*bulletSpeed, 0)); 
            _animator.SetTrigger("Shooting");
        }

        // NOTE: GO TO game over screen after destroying
        if (publicvar.playerDead == true){
            _animator.SetTrigger("Dead");
            wait5sec(5);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            publicvar.playerDead = false;
        }
        
        // Reload scene if you fall off the map
        if(_rigidbody.position.y < -20){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    IEnumerator wait5sec(int time) {
        yield return new WaitForSeconds(time);
    }
}
