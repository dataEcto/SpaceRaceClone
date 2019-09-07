using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [Header("Public Variables")]
    public float speed;
    public GameObject respawnPoint;
    public float playerOneScore;
    public Text p1Text;


    [Header("Variables for Reference")]
    public bool p1Scored;
    public bool shouldRespawn;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;

        
   
    void Start()
    {
        playerOneScore = 0f;
        p1Scored = false;
        shouldRespawn = false;
        rb = GetComponent<Rigidbody2D>();
        
    }

    
    void Update()
    {
        Vector2 MoveInput = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = MoveInput.normalized * speed;
        
        

        if (p1Scored)
        {
            playerOneScore = playerOneScore + 1;
            p1Text.text = playerOneScore.ToString();
            p1Scored = false;
        }
        
    }

    private void FixedUpdate()
    {
       
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("I have hit the Trigger");
        this.transform.position = respawnPoint.transform.position;
        p1Scored = true;
    }

}
