using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeMovement : MonoBehaviour
{
    public float movementSpeed = 4f;


    void Update()
    {
        transform.Translate (Vector2.left * movementSpeed * Time.deltaTime);

        Invoke("SelfDestroy", 5.5f);
    }


    void SelfDestroy()
    {
        Destroy(gameObject);
    }


}
