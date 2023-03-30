using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContactSpike : MonoBehaviour
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
            _audioSource.PlayOneShot(hurtPlayer);
            publicvar.playerDead = true;
            publicvar._animatorPlayer.SetTrigger("Dead");
            StartCoroutine(Wait2sec(2f));
            publicvar._animatorPlayer.SetTrigger("FullDead");
            StartCoroutine(Wait5sec(2f));
        }
    }

    IEnumerator Wait5sec(float time) {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    IEnumerator Wait2sec(float time) {
        yield return new WaitForSeconds(time);
    }
}