using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class PlayerInventory : MonoBehaviour
{
    public int coinsCount;
    public int bonusHealth = 1;
    [SerializeField] private Text coinsText;
    public BuffReciever buffReciever;
    private List<Item> items;
    public List<Item> Items 
    { 
        get { return items; } 
    }
   


    private void Start()
    {
        GameManager.Instance.inventory = this;
        coinsText.text = coinsCount.ToString();
        items = new List<Item>();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
         if (GameManager.Instance.coinContrainer.ContainsKey(col.gameObject))
         {
             coinsCount++;
             coinsText.text = coinsCount.ToString();
             Debug.Log("количество монет = " + coinsCount);
             var coin = GameManager.Instance.coinContrainer[col.gameObject];
             coin.StartDestroy();    
         }

        /*if (col.gameObject.CompareTag("UpHealth"))
        {
            Health health = gameObject.GetComponent<Health>();
            health.SetHealth(bonusHealth);
            Destroy(col.gameObject);
            
        }*/
        if (GameManager.Instance.upHealthContrainer.ContainsKey(col.gameObject) && GameManager.Instance.healthContrainer.ContainsKey(gameObject))
        {
            var upHealth = GameManager.Instance.upHealthContrainer[col.gameObject];
            var health = GameManager.Instance.healthContrainer[gameObject];
            health.SetHealth(bonusHealth);
            upHealth.StartDestroy();
        }

        if (GameManager.Instance.itemsContainer.ContainsKey(col.gameObject))
        {
            var itemComponent = GameManager.Instance.itemsContainer[col.gameObject];
            items.Add(itemComponent.Item);
            itemComponent.Destroy(col.gameObject);  

        }
    }
}