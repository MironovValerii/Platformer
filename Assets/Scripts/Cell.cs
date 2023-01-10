using System;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Action OnUpdateCell;

    [SerializeField] private Image icon;
    private Item item;

    private void Awake()
    {
        icon.sprite = null;
    }
    public void Init(Item item)
    {
        this.item = item;
        if (item == null)
            icon.sprite = null;
        else
            icon.sprite = item.Icon;

    }

    public void OnClickCell()
    {
        if (item == null)
            return; 
        GameManager.Instance.inventory.Items.Remove(item);
        Buff buff = new Buff
        {
            type = item.Tupe,
            additiveBonus = item.Value

        };
        GameManager.Instance.inventory.buffReciever.AddBuff(buff);
        if (OnUpdateCell != null)
            OnUpdateCell();

    }
}
