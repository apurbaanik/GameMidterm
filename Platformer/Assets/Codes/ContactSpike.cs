using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContactSpike : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    GameManager _gameManager;
    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            _gameManager.decrementHealthCounter(1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}