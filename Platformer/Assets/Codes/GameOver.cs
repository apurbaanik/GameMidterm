using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void End(){
        SceneManager.LoadScene("StartGame");
        publicvar.enemyPoints = 0;
        publicvar.chickensCollected = 0;
        publicvar.numberCoins = 0;
        publicvar.maxLevel = 0;
    }
}
