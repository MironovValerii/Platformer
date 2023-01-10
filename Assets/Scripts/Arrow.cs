using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour, IObjectDestroyer
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private TriggerDamage triggerDamage;
    [SerializeField] private float force;
    [SerializeField] private float lifeTime;
    private Pleer pleer;


    public float Force
    {
        get { return force; }
        set { force = value; }
    }
    public void Destroy(GameObject gameObject)
    {
        pleer.ReturnArrowToPool(this);
    }
    public void SetImpulse(Vector2 direction, float force, int bonusDamage, Pleer pleer)
    {
        this.pleer = pleer;
        triggerDamage.Init(this);
        triggerDamage.Parent = pleer.gameObject;
        triggerDamage.Damage += bonusDamage;
        rigidbody.AddForce(direction * force, ForceMode2D.Impulse);
        if (force < 0)
            transform.rotation= Quaternion.Euler(0, 180, 0);
        else
            transform.rotation = Quaternion.Euler(0, 0, 0);
        StartCoroutine(StartLife());
    }
  
    private IEnumerator StartLife()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
        yield break;
    }
}
