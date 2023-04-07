using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginGame : MonoBehaviour
{
    public void Begin(){
        publicvar.numberCoins = 0;
        publicvar.chickensCollected = 0;
        publicvar.enemyPoints = 0;
        publicvar.maxLevel = 0;
        publicvar.tradeAccepted = false;
        SceneManager.LoadScene("level 1");
    }

    public void Restart(){
        publicvar.enemyPoints = 0;
        publicvar.chickensCollected = 0;
        publicvar.numberCoins = 0;
        publicvar.maxLevel = 0;
        publicvar.tradeAccepted = false;
        SceneManager.LoadScene("StartGame");
    }
}
