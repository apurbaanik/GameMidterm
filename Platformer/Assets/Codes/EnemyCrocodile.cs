using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCrocodile : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    GameManager _gameManager;

    public AudioSource _audioSource;
    public AudioClip destroyedSound;

    public GameObject deadParticleEffect;
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public int bulletSpd = 400;
    public float xDirection;

    Transform player;

    void Start() {
        _audioSource = GetComponent<AudioSource>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(Move());
        StartCoroutine(Shoot());
    }

    void Update() {
        if (((player.position.x > transform.position.x) && (transform.localScale.x < 0)) 
            || ((player.position.x < transform.position.x) && (transform.localScale.x > 0))) {
                transform.localScale *= new Vector2(-1, 1);
        }

        xDirection = transform.localScale.x;
    }

    IEnumerator Move() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(1f, 4f));
            _rigidbody2D.AddForce(new Vector2(transform.localScale.x * (Random.Range(200, 400)), 0));
        }
    }

    IEnumerator Shoot() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(3f, 6f));
            GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(xDirection * bulletSpd, 0));
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bullet")) {
            _audioSource.PlayOneShot(destroyedSound);
            Instantiate(deadParticleEffect, transform.position, Quaternion.identity);
            _gameManager.incrementEnemyScoreCounter(20);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
