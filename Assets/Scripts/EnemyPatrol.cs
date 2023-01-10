using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public GameObject LeftBorder;
    public GameObject RightBorder;
    public Rigidbody2D rigidboby;
    public GroundDetection groundDetection;
    public SpriteRenderer spriteRenderer;
    [SerializeField] private CollisionDamage collisionDamage;


    public bool isRightDirection;

    public float speed;

    

    private void FixedUpdate()
    {
        if (groundDetection.isGrounded)
        {
            if (transform.position.x > RightBorder.transform.position.x || collisionDamage.Direction < 0)
                isRightDirection = false;
            else if (transform.position.x < LeftBorder.transform.position.x || collisionDamage.Direction > 0)
                isRightDirection = true;
            rigidboby.velocity = isRightDirection ? Vector2.right : Vector2.left;
            rigidboby.velocity *= speed;
        }


        
        if (rigidboby.velocity.x > 0)
            spriteRenderer.flipX = true;
        if (rigidboby.velocity.x < 0)
            spriteRenderer.flipX = false;     
    }
}
