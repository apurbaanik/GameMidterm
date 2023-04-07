using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    int coins = 0;
    int chickens = 0;
        
    public int health = 10;
    public int totalItems = 1;
    public int level;

    public GameObject door;
    public GameObject chickenCompanion;

    public TextMeshProUGUI scoreInterface;
    public TextMeshProUGUI enemyInterface;

    public TextMeshProUGUI chickenScoreInterface;
    public TextMeshProUGUI healthInterface;

    public TextMeshProUGUI levelInterface;

    public AudioSource _audioSource;
    public AudioClip hurtPlayer;
    public AudioClip healPlayer;

    public Vector2 _respawnPoint;

    public GameObject redDisplay;

    private void Awake()
    {
         if(GameObject.FindObjectsOfType<GameManager>().Length > 1)
        {  
             Destroy(gameObject);
        }
    }
         
    void Start()
    {        
        if (SceneManager.GetActiveScene().name == "level 1") {
            coins = 0;
            chickens = 0;
            publicvar.enemyPoints = 0;
            publicvar.numberCoins = 0;
            publicvar.tradeAccepted = false;
        }

        _audioSource = GetComponent<AudioSource>();
        scoreInterface.text = "Eggs: " + publicvar.numberCoins;
        healthInterface.text = "Health: " + health;  
        enemyInterface.text = "Score: " + publicvar.enemyPoints;
        chickenScoreInterface.text = "Chickens: " + chickens + " / " + totalItems;

        door.SetActive(false);

        if (((SceneManager.GetActiveScene().name == "level 3") || (SceneManager.GetActiveScene().name == "level 4")) && (publicvar.tradeAccepted == true)) {
            chickenCompanion.SetActive(true);
        }
        else {
            chickenCompanion.SetActive(false);
        }
    }

    public void incrementCoinCounter(int value){
        coins += value;
        publicvar.numberCoins += 1;
        scoreInterface.text = "Eggs: " + publicvar.numberCoins;
    }

    public void incrementChickenCounter(int value){
        publicvar.chickensCollected += value;
        chickens += value;
        chickenScoreInterface.text = "Chickens: " + chickens + " / " + totalItems;
    
        if (chickens == totalItems) {
            door.SetActive(true);
        }
    }

    public void incrementEnemyScoreCounter(int value){
        publicvar.enemyPoints += value;
        enemyInterface.text = "Score: " + publicvar.enemyPoints;
    }

    public void decrementHealthCounter(int value){
        health -= value;
        // _audioSource.PlayOneShot(hurtPlayer);
        AudioSource.PlayClipAtPoint(hurtPlayer, gameObject.transform.position);
        healthInterface.text = "Health: " + health;

        var imageAttribute =  redDisplay.GetComponent<Image>().color;
        imageAttribute.a = 0.95f;
        redDisplay.GetComponent<Image>().color = imageAttribute;
    }

    public void incrementHealthCounter(int value){
        health += value;
        AudioSource.PlayClipAtPoint(healPlayer, gameObject.transform.position);
        healthInterface.text = "Health: " + health;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(redDisplay is not null){
            if(redDisplay.GetComponent<Image>().color.a > 0){
                var imageAttribute =  redDisplay.GetComponent<Image>().color;
                imageAttribute.a = imageAttribute.a - 0.01f;
                redDisplay.GetComponent<Image>().color = imageAttribute;
            }
        }
        #if !UNITY_WEBGL
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        #endif

        if (Input.GetKeyDown(KeyCode.Return)) {
            chickens = totalItems;
            nextLevel();
        }

        if ((SceneManager.GetActiveScene().name == "level 3") || (SceneManager.GetActiveScene().name == "level 4")) {
            if (publicvar.tradeAccepted == true) {
                chickenCompanion.SetActive(true);
            }
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
         if (health <= 0 && !publicvar.playerDead){
            publicvar.playerDead = true;
            publicvar._animatorPlayer.SetTrigger("Dead");
            StartCoroutine(Wait2sec(2f));
            publicvar._animatorPlayer.SetTrigger("FullDead");
            var imageAttribute =  redDisplay.GetComponent<Image>().color;
            imageAttribute.a = 1.6f;
            redDisplay.GetComponent<Image>().color = imageAttribute;
            StartCoroutine(Wait5sec2(2f));
        }
    }

    IEnumerator Wait2sec(float time) {
        yield return new WaitForSeconds(time);
    }

    public void nextLevel() {
        publicvar.maxLevel = level;

        if (chickens == totalItems) {
            if (level == 1) {
                SceneManager.LoadScene("level 2");
            }
            else if (level == 2) {
                publicvar.numberCoins = 8;
                SceneManager.LoadScene("SecretScene");
            }
            else if (level == 5) {
                SceneManager.LoadScene("level 3");
            }
            else if (level == 3) {
                SceneManager.LoadScene("level 4");
            }
            else {
                SceneManager.LoadScene("WinGame");
            }
        }
        
        Destroy(gameObject);
    }
}
