using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MarketButton : MonoBehaviour
{
    public string level = "level 3";
    public void Accept(){
        publicvar.numberCoins = 0;
        SceneManager.LoadScene(level);
    }

    
}