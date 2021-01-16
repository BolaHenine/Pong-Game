﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBallManager : MonoBehaviour
{
    public static GameObject greenBall;
    private Rigidbody2D rb2d;
    public static float timeRemainingToResize = 0;
    public static float timeToStart;
    void GoBall(){     
        greenBall.SetActive(true);   
        greenBall.GetComponent<Renderer>().enabled = true;           // puts the ball in a random spot
        float rand = Random.Range(5, 10);
        if(rand < 1){
            rb2d.AddForce(new Vector2(40,Random.Range(-15, 15))); // the first number is the speed and the second number is the direction.
        } else {
            rb2d.AddForce(new Vector2(-40, Random.Range(-15, 15)));
        }
    }
    void Reset()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        timeToStart = Random.Range(9, 12);
        Invoke("GoBall", timeToStart);
    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        timeToStart = Random.Range(3, 5);
        
        greenBall = GameObject.FindGameObjectWithTag("GreenBall");
        greenBall.GetComponent<Renderer>().enabled = false;
        Invoke("GoBall", timeToStart);
    }
    public void OnCollisionEnter2D (Collision2D col) {
        if(col.collider.tag == "Player2"){
            Reset();
        }
        else if(col.collider.tag == "Player"){
            Reset();
        }
    }
    void OnTriggerEnter2D (Collider2D hitInfo) {
        if (hitInfo.name == "RightWall"){
            Reset();
       }
       if (hitInfo.name == "LefttWall"){
            Reset();
       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}