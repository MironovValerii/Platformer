using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuffReciever : MonoBehaviour
{
    private List<Buff> buffs;
    public List<Buff> Buffs
    { 
        get { return buffs; } 
    
    }
    public Action OnBaffsChanged;

    private void Start()
    {
        GameManager.Instance.buffRecieverContrainer.Add(gameObject, this);
        buffs = new List<Buff>();
    }
    public void AddBuff(Buff buff)
    {
        if (!buffs.Contains(buff))
            buffs.Add(buff);

        if (OnBaffsChanged != null)
            OnBaffsChanged();
    }
    public void RemoveBuff(Buff buff)
    {
        if (buffs.Contains(buff))
            buffs.Remove(buff);

        if (OnBaffsChanged != null)
            OnBaffsChanged();
    }
}
