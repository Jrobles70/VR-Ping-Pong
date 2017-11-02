using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballCollision : MonoBehaviour {
    private Rigidbody rb;
    // To check if this is the serve
    private bool serve = true;
    // Check if round is still going
    private bool gameOn = true;
    // Is the last surface the ball touched(ie. p1 side, p2 side)
    // On serve it will be the same side as server
    private string ballPosition = "P1 side";
    // Every time the ball is hit by a player the other player is made the receiver
    private string receivingPlayer= "P2";
    // array to hold the score
    private int[] scores = new int[2];

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);
        string colOb = col.gameObject.name;

        if(colOb == "Table"){
            // If table add extra force
            rb.AddForce(0, 4, 0);
        } else if(colOb == "P1"){
            // If P1 hit make P2 receiver
            receivingPlayer = "P2";
        } else{
            // If P2 hit make P1 receiver
            receivingPlayer = "P1";
        }
        Debug.Log("receivingPlayer: " + receivingPlayer);
    } // end OnCollision

    void OnTriggerEnter(Collider trig)
    { 
        if(gameOn){ 
            // Check if game is running so points arent scored after round is over
            if(trig.gameObject.name == "Out of bounds"){ 
                // give point to 
                Debug.Log("Out of Bounds point goes to" + receivingPlayer);
                pointScored(receivingPlayer);
            } 
            if(serve){ 
                            // Check ball is being served
            
                if(trig.gameObject.name != ballPosition){ 
                            // If ball is served and doesnt bounce on your side first
                    Debug.Log("ball hit same side twice point goes to " + receivingPlayer);
                    pointScored(receivingPlayer);
                }
                else{ 
                            // Ball made was served correctly so continue
                    Debug.Log("Ball was served right");
                    serve = false;
                    }
            
            }// end serve
            else if(ballPosition == trig.gameObject.name){
                // Ball has already been served
                // If ball hits same side of table twice then give point to other person
                Debug.Log("Ball hit the same side of the table twice. Point goes to " + receivingPlayer);
                pointScored(receivingPlayer);
            }
            else{
                setPosition();
            }
                  
     }// end gameOn 

     } // end OnTrigger


    void placeBall() {
        // TODO: will be called when a point is scored to reset 
        // where the ball is and serve/gameOn/ballPosition/Receving

        gameOn = true;
    }

    void setPosition() {
        if (ballPosition == "P1 side"){
            ballPosition = "P2 side";
        } else {
            ballPosition = "P1 side";
        }

    }

    void pointScored(string player) {
        gameOn = false;
        // TODO: add whos point is being scored. Maybe use Dict instead of array?
        placeBall();

    }
        // Use this for initialization
    void Start () {
        
    }
    
    // Update is called once per frame
    void Update () {
        rb = GetComponent<Rigidbody>();
    }
    } // end ballCollision



 
