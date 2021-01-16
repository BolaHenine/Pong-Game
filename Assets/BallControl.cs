using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    
    private Rigidbody2D rb2d;
    public static GameObject theBall;
    public static GameObject redBall;

    void GoBall(){              // puts the ball in a random spot
        float rand = Random.Range(0, 2);
        if(rand < 1){
            rb2d.AddForce(new Vector2(30,Random.Range(-15, 15))); // the first number is the speed and the second number is the direction.
        } else {
            rb2d.AddForce(new Vector2(-30, Random.Range(-15, 15)));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 3); // 3 seconds before the start
        theBall = GameObject.FindGameObjectWithTag("Ball");
        redBall = GameObject.FindGameObjectWithTag("BallRed");
    }
    void ResetBall(){
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
    void RestartGame(){
        ResetBall();
        PlayerControls.ResetPlayer();
        Invoke("GoBall", 2);
    }
    
    void OnCollisionEnter2D (Collision2D coll) {
        if(coll.collider.CompareTag("Player") || coll.collider.CompareTag("Player2")){
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
            rb2d.velocity = vel;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
