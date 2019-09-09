using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RLAsteroidController : MonoBehaviour
{

    public float asteroidSpeed;
    public Vector3 defaultTransform;
    private Rigidbody2D rlAsteroidRB;
    private Vector2 rlAsteroidVelocity;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        rlAsteroidRB = GetComponent<Rigidbody2D>();
        defaultTransform = transform.position;
        
    }


    void Update()
    {
        Vector2 asteroidMoveInput = Vector2.left;
        rlAsteroidVelocity = asteroidMoveInput * asteroidSpeed;
        Physics.IgnoreLayerCollision(8,9);
        Physics2D.IgnoreLayerCollision(9,10);

    }

    private void FixedUpdate()
    {
        rlAsteroidRB.MovePosition(rlAsteroidRB.position + rlAsteroidVelocity * Time.fixedDeltaTime);
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("RL Boundary"))
        {
            transform.position = defaultTransform;
        }
    }
}
