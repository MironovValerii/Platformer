using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpHealth : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Start()
    {
        GameManager.Instance.upHealthContrainer.Add(gameObject, this);
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
