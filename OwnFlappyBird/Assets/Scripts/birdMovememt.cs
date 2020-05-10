
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class birdMovememt : MonoBehaviour
{

    public GameManager gameOver;

    Rigidbody2D rb;
    Transform transform;

    public float jumpforce = 0f;
    public float upTurningRate = 2000f;
    public float fallTurningRate = 250f;

    Quaternion UpAngle = Quaternion.Euler(0,0,45f);
    Quaternion DownAngle = Quaternion.Euler(0,0,-20f);

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(0, jumpforce * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, UpAngle, upTurningRate * Time.deltaTime);
        }
        else
        transform.rotation = Quaternion.RotateTowards(transform.rotation, DownAngle, fallTurningRate * Time.deltaTime);

    }

    void OnCollisionEnter2D(Collision2D colinfo)
    {
        
        rb.velocity = new Vector2(0, -jumpforce * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, DownAngle, fallTurningRate * Time.deltaTime);
        this.enabled = false;
        gameOver.GameOver();

    }

}
