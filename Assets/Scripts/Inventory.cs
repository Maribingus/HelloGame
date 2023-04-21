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

    public List<Item> items = new List<Item>();

    public void Add(Item item)
    {
        items.Add(item); 
    }   

    public void Remove(Item item)
    {
        items.Remove(item);
    }
}
