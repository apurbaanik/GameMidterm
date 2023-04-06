using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProvideCompanion : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI notificationText;
    public GameObject chickenCompanion;

    
    void Start()
    {
        StartCoroutine(waitFor3AndDisable());
    }

    IEnumerator waitFor3AndDisable(){
        if(publicvar.tradeAccepted == true){
            chickenCompanion.SetActive(true);
            notificationText.faceColor = Color.green;
            notificationText.text = "Trade Successful";
        }
        else{
            chickenCompanion.SetActive(false);
            notificationText.faceColor = Color.red;
            notificationText.text = "Trade Failed";
            
        }
        yield return new WaitForSeconds(2);
        notificationText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
