using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]

public class Item : ScriptableObject
{
    public string itemName = "New Item";
    public int damage = 12;
    public int armor = 13;
    public Sprite icon = null;
    
}
