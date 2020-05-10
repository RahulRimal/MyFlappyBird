using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ScoreIncrement : MonoBehaviour
{


    public GameObject coinSound;


    private void OnTriggerEnter2D(Collider2D col)
    {
        scoreManager.score++;
        Instantiate(coinSound, transform.position, Quaternion.identity);
    }

    void Update()
    {
        if(scoreManager.score > PlayerPrefs.GetInt("Highscore", 0))
            PlayerPrefs.SetInt("Highscore", scoreManager.score);
    }


}