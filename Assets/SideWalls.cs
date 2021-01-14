﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour
{
    public static GameObject redBall;
    void OnTriggerEnter2D (Collider2D hitInfo) {
        if (hitInfo.name == "Ball")
        {
            string wallName = transform.name;
            GameManager.Score(wallName);
            hitInfo.gameObject.SendMessage("RestartGame", 1.0f, SendMessageOptions.RequireReceiver);
        }
        if (hitInfo.name == "BallRed")
        {
            redBall.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        redBall = GameObject.FindGameObjectWithTag("BallRed");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}