using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemComponent : MonoBehaviour, IObjectDestroyer
{
    [SerializeField] private ItemType type;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Item item;
    public Item Item
    {
        get { return item; }
    }

    public void Destroy(GameObject gameObject)
    {
        MonoBehaviour.Destroy(gameObject);
    }
    void Start()
    {
        item = GameManager.Instance.itemDataBase.GetItemofID((int)type);
        spriteRenderer.sprite = item.Icon;
        GameManager.Instance.itemsContainer.Add(gameObject, this);
    }
}

public enum ItemType
{
    DamagePotion = 1, 
    ArmorPotion = 2, 
    ForcePotion = 3,
}