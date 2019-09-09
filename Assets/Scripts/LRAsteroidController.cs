using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRAsteroidController : MonoBehaviour
{

    public float asteroidSpeed;
    public Vector3 defaultTransform;
    private Rigidbody2D lrAsteroidRB;
    private Vector2 lrAsteroidVelocity;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        lrAsteroidRB = GetComponent<Rigidbody2D>();
        defaultTransform = transform.position;
        
    }


    void Update()
    {
        Vector2 asteroidMoveInput = Vector2.right;
        lrAsteroidVelocity = asteroidMoveInput * asteroidSpeed;
        Physics2D.IgnoreLayerCollision(8,9);
        Physics2D.IgnoreLayerCollision(8,10);
        
    }

    private void FixedUpdate()
    {
        lrAsteroidRB.MovePosition(lrAsteroidRB.position + lrAsteroidVelocity * Time.fixedDeltaTime);
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("LR Boundary"))
        {
            transform.position = defaultTransform;
        }
    }
}
