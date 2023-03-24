using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    int coins = 0;
    int chickensCollected = 0;
     int health = 3;
    public TextMeshProUGUI scoreInterface;

    public TextMeshProUGUI chickenScoreInterface;
    public TextMeshProUGUI healthInterface;

    private void Awake()
    {
        if(GameObject.FindObjectsOfType<GameManager>().Length > 1)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {        
        scoreInterface.text = "Coins: " + coins;
        healthInterface.text = "Health: " + health;  
        chickenScoreInterface.text = "Chickens Collected: " + chickensCollected;
    }

    public void incrementCoinCounter(int value){
        coins += value;
        scoreInterface.text = "Coins: " + coins;
    }

    public void incrementChickenCounter(int value){
        chickensCollected += value;
        chickenScoreInterface.text = "Coins: " + coins;
    }

    public void decrementHealthCounter(int value){
        health -= value;
        healthInterface.text = "Coins: " + coins;
    }

    // Update is called once per frame
    void Update()
    {
        #if !UNITY_WEBGL
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        #endif
    }
        
    
}
