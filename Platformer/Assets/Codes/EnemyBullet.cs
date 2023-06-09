using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    GameManager _gameManager;
    public AudioSource _audioSource;
    public AudioClip hurtPlayer;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            // _audioSource.PlayOneShot(hurtPlayer);
            AudioSource.PlayClipAtPoint(hurtPlayer, gameObject.transform.position);
            _gameManager.decrementHealthCounter(1);
            Destroy(gameObject);
        }
    }
}
