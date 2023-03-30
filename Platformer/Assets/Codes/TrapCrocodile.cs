using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCrocodile : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    GameManager _gameManager;

    public AudioSource _audioSource;
    public AudioClip destroyedSound;

    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();   
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
