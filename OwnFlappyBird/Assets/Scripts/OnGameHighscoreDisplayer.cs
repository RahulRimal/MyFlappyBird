using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnGameHighscoreDisplayer : MonoBehaviour
{

    public Text onGameHighScore;

    void Update()
    {
        onGameHighScore.text = "HighScore: "+PlayerPrefs.GetInt("Highscore",0).ToString();
    }
}
