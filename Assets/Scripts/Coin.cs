using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Start()
    {
        GameManager.Instance.coinContrainer.Add(gameObject, this);
    }
    public void StartDestroy()
    {
        animator.SetTrigger("StartDestroy");
    }
    public void EndDestroy()
    {
        Destroy(gameObject);
    }
}
