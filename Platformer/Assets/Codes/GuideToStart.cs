using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuideToStart : MonoBehaviour
{
    public void Return(){
        SceneManager.LoadScene("StartGame");
    }

    public void Restart(){
        SceneManager.LoadScene("StartGame");
    }
}

