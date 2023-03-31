using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    int coins = 0;
    
    
    int health = 8;
    public int totalItems = 1;
    public int level;

    public GameObject door;

    public TextMeshProUGUI scoreInterface;
    public TextMeshProUGUI enemyInterface;

    public TextMeshProUGUI chickenScoreInterface;
    public TextMeshProUGUI healthInterface;

    public AudioSource _audioSource;
    public AudioClip hurtPlayer;


    private void Awake()
    {
         if(GameObject.FindObjectsOfType<GameManager>().Length > 1)
        {  
             Destroy(gameObject);
        }
    }
         
    void Start()
    {        
        _audioSource = GetComponent<AudioSource>();
        scoreInterface.text = "Eggs: " + coins + " / " + totalItems;
        healthInterface.text = "Health: " + health;  
        enemyInterface.text = "Score: " + publicvar.enemyPoints;
        chickenScoreInterface.text = "Chickens: " + publicvar.chickensCollected;

        door.SetActive(false);
    }

    public void incrementCoinCounter(int value){
        coins += value;
        publicvar.numberCoins += 1;
        scoreInterface.text = "Eggs: " + coins + " / " + totalItems;
        
        if (coins == totalItems) {
            print("done");
            door.SetActive(true);
        }
    }

    public void incrementChickenCounter(int value){
        publicvar.chickensCollected += value;
        chickenScoreInterface.text = "Chickens: " + publicvar.chickensCollected;
    }

    public void incrementEnemyScoreCounter(int value){
        publicvar.enemyPoints += value;
        enemyInterface.text = "Destruction Score: " + publicvar.enemyPoints;
    }

    public void decrementHealthCounter(int value){
        health -= value;
        _audioSource.PlayOneShot(hurtPlayer);
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

        if (Input.GetKeyDown(KeyCode.Return)) {
            coins = totalItems;
            nextLevel();
        }
    }

    IEnumerator Wait5sec(float time) {
        
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);    
        
    }

    IEnumerator Wait5sec2(float time) {
        
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("EndGame");  
        
    }

    void FixedUpdate() {
         if (health == 0 && !publicvar.playerDead){
            publicvar.playerDead = true;
            publicvar._animatorPlayer.SetTrigger("Dead");
            StartCoroutine(Wait2sec(2f));
            publicvar._animatorPlayer.SetTrigger("FullDead");
            StartCoroutine(Wait5sec2(2f));
            publicvar.enemyPoints = 0;
            publicvar.chickensCollected = 0;
            
        }
    }

    IEnumerator Wait2sec(float time) {
        yield return new WaitForSeconds(time);
    }

    public void nextLevel() {
        if (coins == totalItems) {
            if (level == 1) {
                SceneManager.LoadScene("level 2");
            }
            else if (level == 2) {
                SceneManager.LoadScene("SecretScene");
            }
            else if (level == 5) {
                SceneManager.LoadScene("level 3");
            }
            else if (level == 3) {
                SceneManager.LoadScene("level 4");
            }
            else {
                SceneManager.LoadScene("EndGame");
            }
        }
        
        Destroy(gameObject);
    }
}
