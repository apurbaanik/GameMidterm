using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionChicken : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    Transform user;

    public AudioSource _audioSource;
    public AudioClip shootSound;

    public GameObject bulletPrefab;
    public Transform spawnPointChicken;
    public int bulletSpeed = 600;

    public float distance = 10000;

    public float xDirection;
    
    public int movement = 4;

    bool keepShooting = true;


    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody2D>();
        user = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(Follow());
        StartCoroutine(Shoot());
    }

    void Update(){
        if (publicvar.playerSeesEnemy){
            xDirection = transform.localScale.x;
            GameObject newBullet = Instantiate(bulletPrefab, spawnPointChicken.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(xDirection*bulletSpeed, 0)); 
            _audioSource.PlayOneShot(shootSound);

        }
        
    }
    
    IEnumerator Follow(){
        while(true){
            yield return new WaitForSeconds(0.1f);
            if(Vector2.Distance(transform.position, user.position) < distance && Vector2.Distance(transform.position, user.position) > 1){
                if (user.position.x > transform.position.x && transform.localScale.x < 0 || user.position.x < transform.position.x && transform.localScale.x > 0){
                    transform.localScale *= new Vector2(-1,1);
                }
                Vector2 angle_direction = (user.position - transform.position);
                _rigidbody.velocity = angle_direction.normalized * movement;
            }
        }
    }


    IEnumerator Shoot(){
        while (true){
            yield return new WaitForSeconds(.6f);
            Vector3 infront = transform.TransformDirection(Vector3.forward);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, infront, out hit)){
                if(!hit.transform.CompareTag("Enemy")){
                    xDirection = transform.localScale.x;
                    GameObject newBullet = Instantiate(bulletPrefab, spawnPointChicken.position, Quaternion.identity);
                    newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(xDirection*bulletSpeed, 0)); 
                    _audioSource.PlayOneShot(shootSound);

                }
                
                //_animator.SetTrigger("Shooting");
            }

        }
        
    }

   
}
