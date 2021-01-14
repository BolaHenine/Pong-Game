using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public static GameObject thePlayer;
    public static GameObject thePlayer2;
    public static GameObject redBall;
    public static float timeRemaining = 0;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        thePlayer2 = GameObject.FindGameObjectWithTag("Player2");
        redBall = GameObject.FindGameObjectWithTag("BallRed");
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else{
          thePlayer.SetActive(true);
       }
    
    }


    public void OnCollisionEnter2D(Collision2D col){
        if(col.collider.tag == "BallRed"){
            timeRemaining = 1.5f;
            redBall.SetActive(false);
           
        }
    }
}
