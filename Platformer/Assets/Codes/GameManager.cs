using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    int coins = 0;
    int chickensCollected = 0;
    int enemyPoints = 0;
     int health = 3;
    public TextMeshProUGUI scoreInterface;
    public TextMeshProUGUI enemyInterface;

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
        enemyInterface.text = "Destruction Score: " + enemyPoints;
        chickenScoreInterface.text = "Chickens Collected: " + chickensCollected;
    }

    public void incrementCoinCounter(int value){
        coins += value;
        publicvar.numberCoins += 1;
        scoreInterface.text = "Coins: " + coins;
    }

    public void incrementChickenCounter(int value){
        chickensCollected += value;
        chickenScoreInterface.text = "Chickens: " + chickensCollected;
    }

    public void incrementEnemyScoreCounter(int value){
        enemyPoints += value;
        enemyInterface.text = "Destruction Score: " + enemyPoints;
    }

    public void decrementHealthCounter(int value){
        health -= value;
        healthInterface.text = "Health: " + health;
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

    IEnumerator Wait5sec(float time) {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void FixedUpdate() {
         if (health == 0 && !publicvar.playerDead){
            publicvar.playerDead = true;
            publicvar._animatorPlayer.SetTrigger("Dead");
            StartCoroutine(Wait2sec(2f));
            publicvar._animatorPlayer.SetTrigger("FullDead");
            StartCoroutine(Wait5sec(3f));
        }
    }

    IEnumerator Wait2sec(float time) {
        yield return new WaitForSeconds(time);
    }
}
