using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class P2Controller : MonoBehaviour
{
    [Header("Public Variables")]
    public float speed;
    public GameObject respawnPoint2;
    public float playerTwoScore;
    public Text p2Text;

    [Header("Reference Variables")] 
    public bool p2Scored;
    private Rigidbody2D rb;
    private Vector2 moveVelocityP2;
        
   
    void Start()
    {
        playerTwoScore = 0f;
        rb = GetComponent<Rigidbody2D>();
        p2Scored = false;
    }

    
    void Update()
    {
        
        Vector2 MoveInputP2 = new Vector2(0,Input.GetAxisRaw("Vertical 2"));
        moveVelocityP2 = MoveInputP2.normalized * speed;

        if (p2Scored)
        {
            playerTwoScore = playerTwoScore + 1;
            p2Text.text = playerTwoScore.ToString();
            p2Scored = false;
        }

    }

    private void FixedUpdate()
    {

        rb.MovePosition(rb.position + moveVelocityP2 * Time.fixedDeltaTime);
     
  
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("This is P2. I have hit the Trigger");
        this.transform.position = respawnPoint2.transform.position;
        p2Scored = true;
    }
    
    
        
}
