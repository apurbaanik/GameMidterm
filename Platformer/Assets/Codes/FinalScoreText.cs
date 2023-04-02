using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScoreText : MonoBehaviour
{
    public TextMeshProUGUI scoreInterface;
    public TextMeshProUGUI eggInterface;
    public TextMeshProUGUI levelInterface;

    void Start() {
        scoreInterface.text = "Final Score: " + publicvar.enemyPoints;
        eggInterface.text = "Eggs Collected: " + publicvar.numberCoins;
        levelInterface.text = "Max Level: " + publicvar.maxLevel;
    }
}
