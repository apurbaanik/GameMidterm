using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    GameManager _gameManager;
    public AudioSource _audioSource;
    public AudioClip coinPickSound;
    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            // _audioSource.PlayOneShot(coinPickSound);
            AudioSource.PlayClipAtPoint(coinPickSound, gameObject.transform.position);
            _gameManager.incrementCoinCounter(1);
            Destroy(gameObject);
        }
    }
}
