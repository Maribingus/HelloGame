using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    #region singleton

    public static Inventory instance;

    void Awake()
    {
        if(instance != null)
        {
            print("more than one Inventory");
        }

        instance = this;
    }

    #endregion

    public GameObject InventoryItem;
    public Transform inventoryPanel;
    //public List<Item> InventoryItems = new List<Item>();

/* private void onEnable()
{
    ItemPickup.OnItemCollected += PickupItem;
}

private void onDisable()
{
    ItemPickup.OnItemCollected -= PickupItem;
}

public void PickupItem()
{
    print("pickup");
} */


public void Add(Item itemStats)
{
    //InventoryItems.Add(item);
    GameObject pickedItem = Instantiate(InventoryItem, inventoryPanel);
    pickedItem.GetComponent<InventoryItem>().itemStats = itemStats;
    }   

public void Remove(Item item)
{
    //InventoryItems.Remove(item);
}

}
