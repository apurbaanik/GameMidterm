using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    GameManager _gameManager;

    public AudioSource _audioSource;
    public AudioClip collectChicken;
    public AudioClip destroyedSound;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            // _audioSource.PlayOneShot(collectChicken);
            AudioSource.PlayClipAtPoint(collectChicken, gameObject.transform.position);
            _gameManager.incrementChickenCounter(1);
            Destroy(gameObject);
        }

/*         if (other.CompareTag("Bullet")) {
            _audioSource.PlayOneShot(destroyedSound);
            Destroy(gameObject);
            Destroy(other.gameObject);
        } */
    }
}

