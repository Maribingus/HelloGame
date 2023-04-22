using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FloorItem : Interactable
{
    public Item itemStats;

    //public static event Action OnItemCollected;

    public override void Interact()
    {
        base.Interact();

        Pickup();
    }

    public void Pickup()
    {
        //print("Picking up " + item.name);
        //print("Item damage " + item.damage);
        //OnItemCollected?.Invoke();
        Inventory.instance.Add(itemStats);
        Destroy(gameObject);
    }
}
