using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    public float CurrentTime;
    public float MaxTime;
    
    GameObject playerOne; 
    GameObject playerTwo; 
    
    private PlayerController p1Script;
    private P2Controller p2Script;
    
    private Transform p1Transform;
    private Transform p2Transform;
    private Transform respawn1;
    private Transform respawn2;
    

    public Slider timer;
    
    void Start()
    {
        MaxTime = 20;
        //On game load, set timer to Full
        CurrentTime = MaxTime;
        timer.value = CalculateTime();
        
        playerOne = GameObject.Find("Spaceship");
        playerTwo = GameObject.Find("Spaceship 2");
        
        p1Script = playerOne.GetComponent<PlayerController>();
        p2Script = playerTwo.GetComponent<P2Controller>();
        
        p1Transform = playerOne.GetComponent<Transform>();
        p2Transform = playerTwo.GetComponent<Transform>();

        respawn1 = p1Script.respawnPoint.transform;
        respawn2 = p2Script.respawnPoint2.transform;
    }

    
    void Update()
    {
        //This is where the timer should go down
        DecreaseTimer(1f);
        //If the timer runs out, everything should stop
       
    }

    void DecreaseTimer(float decreaseValue)
    {
        //Subtract time from the timer bar
        CurrentTime -= decreaseValue * Time.fixedDeltaTime;
        timer.value = CalculateTime();
        if (CurrentTime <= 0)
        {
            //Function that stops everything here.
            Debug.Log("GAME!");

            p1Script.transform.position = respawn1.transform.position;
            p2Script.transform.position = respawn2.transform.position;
            p1Script.enabled = false;
            p2Script.enabled = false;
        }
      
    }
    
    

    float CalculateTime()
    {
        return CurrentTime / MaxTime;
    }
}
