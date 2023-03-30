using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFox : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    GameManager _gameManager;

    public AudioSource _audioSource;
    public AudioClip destroyedSound;

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
            _rigidbody2D.AddForce(new Vector2(transform.localScale.x * 200, 100));
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bullet")) {
            _audioSource.PlayOneShot(destroyedSound);
            _gameManager.incrementEnemyScoreCounter(20);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
