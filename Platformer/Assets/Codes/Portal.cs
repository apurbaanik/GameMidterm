using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    GameManager _gameManager;
    Rigidbody2D _rigidbody2D;

    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();    
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            _gameManager.nextLevel();
        }
    }
}
