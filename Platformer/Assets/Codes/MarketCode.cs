using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MarketCode : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    
    GameManager _gameManager;

    public TextMeshProUGUI Line;
    public TextMeshProUGUI ButtonText;

    public AudioSource _audioSource;
    public AudioClip companion;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Line.text = Line.text = "Market Owner: 'I can't find my eggs anywhere!'";
    }

    
    IEnumerator Wait1sec(int time) {
        //Line.enabled = false;
        //Line.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(time); 
    }

    IEnumerator Wait3sec(int time) {
        Line.enabled = true;
        Line.gameObject.SetActive(true);
        print("working");
        yield return new WaitForSecondsRealtime(time); 
    }

    IEnumerator Wait3sec1(int time) {
        Line.text = "Market Owner: 'Woah, who are you? You remind me of someone'";
        Line.enabled = true;
        Line.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(time); 
    }

    IEnumerator Wait3sec2(int time) {
        Line.text = "Market Owner: 'Oh you're a farmer too? Wait...what's that sticking out of your back pocket?'";
        Line.enabled = true;
        Line.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(time); 
    }

    IEnumerator Wait3sec3(int time) {
        _audioSource.PlayOneShot(companion);
        Line.text = "Market Owner: 'MY 9 EGGS! I'll trade you this special companion for those!'";
        Line.enabled = true;
        Line.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(time); 
    }

    // void conversation(){
            
    // }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            Rigidbody2D playerRigidbody = other.attachedRigidbody;
            playerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            publicvar._animatorPlayer.enabled = false;
            
            
            // StartCoroutine(Wait3sec(3));
            // StartCoroutine(Wait1sec(1));

            

            // StartCoroutine(Wait3sec1(3));
            // StartCoroutine(Wait1sec(1));

            
            
            
            // StartCoroutine(Wait3sec2(3));
            // StartCoroutine(Wait1sec(1));

            
            
            StartCoroutine(Wait3sec3(3));
            StartCoroutine(Wait1sec(1));

            ButtonText.enabled = true;
            publicvar._animatorPlayer.enabled = true;
            
        }
    }
}
