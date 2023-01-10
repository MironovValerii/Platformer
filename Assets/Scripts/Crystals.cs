using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystals : MonoBehaviour
{

    public int damage = 10;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (GameManager.Instance.healthContrainer.ContainsKey(col.gameObject))
        {
            var health = GameManager.Instance.healthContrainer[col.gameObject];
            health.TakeHit(damage);
        }
    }
}
