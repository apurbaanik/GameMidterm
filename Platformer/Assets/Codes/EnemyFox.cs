using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFox : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    GameManager _gameManager;
    public AudioSource _audioSource;
    public AudioClip destroyedSound;
    public GameObject deadParticleEffect;

    Transform player;
    // Animator _animator;

    void Start() {
        _audioSource = GetComponent<AudioSource>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();   

        player = GameObject.FindGameObjectWithTag("Player").transform;
        // _animator = GetComponent<Animator>(); 

        StartCoroutine(Move());
    }

    void Update() {
        if (((player.position.x > transform.position.x) && (transform.localScale.x < 0)) 
            || ((player.position.x < transform.position.x) && (transform.localScale.x > 0))) {
                transform.localScale *= new Vector2(-1, 1);
        }
    }

    IEnumerator Move() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(1f, 2f));
            _rigidbody2D.AddForce(new Vector2(transform.localScale.x * 400, 100));
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bullet")) {
            // _audioSource.PlayOneShot(destroyedSound);
            AudioSource.PlayClipAtPoint(destroyedSound, gameObject.transform.position);
            Instantiate(deadParticleEffect, transform.position, Quaternion.identity);
            _gameManager.incrementEnemyScoreCounter(40);
            Destroy(other.gameObject);
            // StartCoroutine(Wait());
            Destroy(gameObject);
        }
    }
    
    IEnumerator Wait() {
        yield return new WaitForSeconds(10f);
    }
}
