using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject inventoryPanel;
    #region Singleton
    public static GameManager Instance { get; private set; }
    #endregion

    public Dictionary<GameObject, Health> healthContrainer;
    public Dictionary<GameObject, Coin> coinContrainer;
    public Dictionary<GameObject, BuffReciever> buffRecieverContrainer;
    public Dictionary<GameObject, UpHealth> upHealthContrainer;
    public Dictionary<GameObject, ItemComponent> itemsContainer;
    public PlayerInventory inventory;
    public ItemBase itemDataBase;

    private void Awake()
    {
        inventoryPanel.SetActive(false);
        Instance = this;
        healthContrainer = new Dictionary<GameObject, Health>();
        coinContrainer = new Dictionary<GameObject, Coin>();
        buffRecieverContrainer = new Dictionary<GameObject, BuffReciever>();
        upHealthContrainer = new Dictionary<GameObject, UpHealth>();
        itemsContainer = new Dictionary<GameObject, ItemComponent>();
    }

    public void OnClickPause()
    {
        if (Time.timeScale > 0)
            Time.timeScale = 0;
        menu.SetActive(true);
    }

    public void OnClichInventoryButton()
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0;
            inventoryPanel.SetActive(true);
        }
        else
        {
            inventoryPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
