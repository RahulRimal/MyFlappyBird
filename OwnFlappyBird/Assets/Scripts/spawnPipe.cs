using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPipe : MonoBehaviour
{
    public GameObject pipe;

    void Start()
    {
        Instantiate(pipe, transform.position, Quaternion.identity);
    }

}