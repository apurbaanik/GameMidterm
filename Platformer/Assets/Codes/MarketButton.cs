using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MarketButton : MonoBehaviour
{
    public string level = "level 3";
    public void Accept(){
        // coins = eggs
        if (publicvar.numberCoins >= 8){
            publicvar.tradeAccepted = true;
            publicvar.numberCoins -= 8;
        }
        
        SceneManager.LoadScene(level);
    }

    
}