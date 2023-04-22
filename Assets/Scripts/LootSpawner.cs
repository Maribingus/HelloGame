using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    public GameObject dropItem;

    public string itemName = "Hodenschwert";
    public int damage = 12;
    public int armor = 13;
    public Sprite icon = null;

    void Start()
    {
        Item itemStats = (Item)ScriptableObject.CreateInstance("Item");
        itemStats.itemName = itemName;
        itemStats.damage = damage;
        itemStats.armor = armor;
        itemStats.icon = icon;
        GameObject droppedItem = Instantiate(dropItem, transform.position, Quaternion.identity);
        droppedItem.GetComponent<FloorItem>().itemStats = itemStats;
        Destroy(gameObject);
    }
}
