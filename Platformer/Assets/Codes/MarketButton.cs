using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MarketButton : MonoBehaviour
{
    public string level = "level 1";
    public void Accept(){
        publicvar.numberCoins = -1;
        SceneManager.LoadScene(level);
    }

    
}