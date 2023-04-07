using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void End(){
        publicvar.enemyPoints = 0;
        publicvar.chickensCollected = 0;
        publicvar.numberCoins = 0;
        publicvar.maxLevel = 0;
        SceneManager.LoadScene("StartGame");
    }
}
