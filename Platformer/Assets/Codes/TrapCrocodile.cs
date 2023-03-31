using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCrocodile : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    GameManager _gameManager;
    public GameObject deadParticleEffect;

    public AudioSource _audioSource;
    public AudioClip destroyedSound;

    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();   
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bullet")) {
            AudioSource.PlayClipAtPoint(destroyedSound, gameObject.transform.position);
            // _audioSource.PlayOneShot(destroyedSound);
            Instantiate(deadParticleEffect, transform.position, Quaternion.identity);
            _gameManager.incrementEnemyScoreCounter(10);
            Destroy(other.gameObject);
            StartCoroutine(Wait());
            Destroy(gameObject);
        }
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(10f);
    }
}
