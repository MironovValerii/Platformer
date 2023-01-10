using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public GameObject gameObject1 = null;
    public int damage = 10;
    [SerializeField] private Animator animator;
    //private Health health;
    private float direction;
    public float Direction
    {
        get { return direction; }
    }


    private void OnCollisionStay2D(Collision2D col)
    {
        //health = col.gameObject.GetComponent<Health>();
        if (GameManager.Instance.healthContrainer.ContainsKey(col.gameObject))
        {
            var health = GameManager.Instance.healthContrainer[col.gameObject];
            if (health != null)
            {
                direction = (col.transform.position - transform.position).x;
                animator.SetFloat("Direction", Mathf.Abs(direction));
                gameObject1 = col.gameObject;
       
            }
        }
    }

    public void SetDamage()
    {
        if (GameManager.Instance.healthContrainer.ContainsKey(gameObject1))
        {

            var health = GameManager.Instance.healthContrainer[gameObject1];

            if (health != null)
                health.TakeHit(damage);
            health = null;
            direction = 0;
            animator.SetFloat("Direction", 0f);
        }
    }
}
