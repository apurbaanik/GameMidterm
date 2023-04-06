using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHeart : MonoBehaviour
{
    GameManager _gameManager;

    void Start(){
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            _gameManager.incrementHealthCounter(1);
            Destroy(gameObject);
        }
    }
}
