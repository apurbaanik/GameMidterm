using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySnake : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    GameManager _gameManager;
    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bullet")){
            _gameManager.incrementEnemyScoreCounter(10);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
