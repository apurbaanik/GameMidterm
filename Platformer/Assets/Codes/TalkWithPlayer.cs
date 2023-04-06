using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TalkWithPlayer : MonoBehaviour
{
    public AudioSource _audioSource;
    public AudioClip typeSound;
    
    public AudioClip chickenSound;
    public TextMeshProUGUI UIobject;
    int position = 0;
    
    public string[] dialouge = {"Market Owner: 'I can't find my eggs anywhere! HEY YOU COME HERE'", "Market Owner: 'Woah, who are you? You remind me of someone'", "Market Owner: 'Oh you're a farmer too? Wait...what's that sticking out of your pockets?'", "Market Owner: 'MY EGGS! I'll trade you this special companion for those!'"};
    
    // Start is called before the first frame update
    void Start()
    {
        UIobject.text = "";
        _audioSource = GetComponent<AudioSource>();
        runText();
        _audioSource.PlayOneShot(typeSound);
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Input.GetMouseButtonDown(0) && publicvar.walkedUp == true){
            
            if(UIobject.text == dialouge[position]){
                if (position != dialouge.Length-1){
                    _audioSource.PlayOneShot(typeSound);
                    
                }
                runThrough();
                
            }
            else{
                StopAllCoroutines();
                UIobject.text = dialouge[position];
            }
        }
    
    }

    void runThrough(){
        if(dialouge.Length-1 > position){
            position++;
            UIobject.text = "";
            StartCoroutine(showText());
        }
        else {
            _audioSource.PlayOneShot(chickenSound);
            publicvar.conversationCompleted = true;
        }
    }
    IEnumerator showText(){
        foreach(char letter in dialouge[position].ToCharArray()){
            UIobject.text += letter;
            yield return new WaitForSeconds(0.04f);
        }
    }

    void runText(){
        
        StartCoroutine(showText());
    }
}
