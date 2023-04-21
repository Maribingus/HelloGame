using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();

        Pickup();
    }

    public void Pickup()
    {
        print("Picking up " + item.name);
        Inventory.instance.Add(item);
        Destroy(gameObject);
    }
}
