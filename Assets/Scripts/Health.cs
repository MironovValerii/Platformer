using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;
    public int CurrentHealth
    {
        get { return health; }
    }
    [SerializeField] private Animator animator;

    private void Start()
    {
        GameManager.Instance.healthContrainer.Add(gameObject, this);
    }
    public void TakeHit(int damage)
    {
        health -= damage;
        if (gameObject.CompareTag("Player"))
            animator.SetTrigger("Damage");
        Debug.Log(health);

        if (health <= 0)
            Destroy(gameObject);
    }

    public void SetHealth(int bonusHealth)
    {
        health += bonusHealth;

        Debug.Log(health);

        if (health > 100)
            health = 100;
    }
}
