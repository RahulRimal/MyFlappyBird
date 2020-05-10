using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipesSpawner : MonoBehaviour
{
    float spawnRate = 1.5f;
    float timeLeftToSpawn;
    float timeDecrement = 0.001f;

    public GameObject[] pipe;   


    void Update()
    {
        
        int pipeChoice = Random.Range(0, pipe.Length);

        if(timeLeftToSpawn < 0)
        {
            Instantiate(pipe[pipeChoice], pipe[pipeChoice].transform.position, Quaternion.identity);
            timeLeftToSpawn = spawnRate;
            spawnRate -= timeDecrement;
        }

        else
        {
            timeLeftToSpawn -= Time.deltaTime;
        }
    }

}
