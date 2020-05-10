using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreManager : MonoBehaviour
{
    public static int score = 0;
    public static int scoreOnStart = 0;

    void Start()
    {
        score = scoreOnStart;
        GetComponent<UnityEngine.UI.Text>().text = PlayerPrefs.GetInt("scoreToGive").ToString();
    }

    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = score.ToString();
        PlayerPrefs.SetInt("scoreToGive", score);

    }


    public static void RewardScore()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // GetComponent<UnityEngine.UI.Text>().text = PlayerPrefs.GetInt("scoreToGive").ToString();
        scoreOnStart =  PlayerPrefs.GetInt("scoreToGive",0);

    }

}