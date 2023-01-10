using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    [SerializeField] private int damage;
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    [SerializeField] private bool isDestroyingAfterCollision;
    private IObjectDestroyer destroyer;
    [SerializeField] private GameObject parent;
    public GameObject Parent
    {
        get { return parent; }
        set { parent = value; }
    }
    public void Init(IObjectDestroyer destroyer)
    {
        this.destroyer = destroyer;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject == parent)
        {
            return;
            
        }
        if (GameManager.Instance.healthContrainer.ContainsKey(col.gameObject))
        {
            var health = GameManager.Instance.healthContrainer[col.gameObject];
            health.TakeHit(damage);
        }
        if (isDestroyingAfterCollision)
        {
            if (destroyer == null)
                Destroy(gameObject);
            else destroyer.Destroy(gameObject);
        }
    }

}
public interface IObjectDestroyer
{
    void Destroy(GameObject gameObject);
}