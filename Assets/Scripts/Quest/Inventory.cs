
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items;

    private void Start()
    {
        items = new List<Item>();
    }

    public void AddToInventory(Item item)
    {
        items.Add(item);
    }

    public bool Contains(int questRequiredObjectId)
    {
        return items.FirstOrDefault(item => item.id == questRequiredObjectId) != null;
    }
}