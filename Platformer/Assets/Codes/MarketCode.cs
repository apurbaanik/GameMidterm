using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MarketCode : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    
    GameManager _gameManager;


    public TextMeshProUGUI Line;
    public TextMeshProUGUI ButtonText;
    public TextMeshProUGUI ButtonContinue;
    //public AudioSource disableSource;
    public AudioSource _audioSource;
    public AudioClip companion;
    public AudioClip talking;

    public GameObject TradeB;
    public GameObject ContinueB;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        TradeB.SetActive(false);
        ContinueB.SetActive(false);
    }

    void Update(){
        if (publicvar.conversationCompleted == true){
            ContinueB.SetActive(false);
            TradeB.SetActive(true);
            ButtonText.enabled = true;
            publicvar._animatorPlayer.enabled = true;
            if(Input.GetButtonDown("Jump")){
                if (publicvar.numberCoins >= 8){
                    publicvar.tradeAccepted = true;
                    publicvar.numberCoins = 0;
                }
                SceneManager.LoadScene("level 3");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            Rigidbody2D playerRigidbody = other.attachedRigidbody;
            playerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            publicvar._animatorPlayer.enabled = false;
            ContinueB.SetActive(true);
            ButtonContinue.enabled = true;
            _audioSource.PlayOneShot(talking);
            publicvar.walkedUp = true;
        }
    }
}
