using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MarketButton : MonoBehaviour
{
    public string level = "level 1";
    public void Accept(){
        SceneManager.LoadScene(level);
    }

    
}