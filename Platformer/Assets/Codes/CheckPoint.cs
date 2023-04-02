using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    GameManager _gameManager;

    void Start() {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void onTriggerEnter2D(Collider2D other) {
        Vector2 pointupdate;

        if (other.tag == "Player") {
            pointupdate = new Vector2(transform.position.x, transform.position.y);
            _gameManager._respawnPoint = pointupdate;
        }
    }
}
