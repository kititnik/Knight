using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    private Inventory _inventory;
    public List<IInventoryObserver> Observers;
    [SerializeField] private int inventorySize;

    private void Awake()
    {
        _inventory = new Inventory(inventorySize);
        Observers = new List<IInventoryObserver>();
    }
    
    public bool AddItem(int itemId)
    {
        bool success = _inventory.AddItem(itemId);
        if(success) NotifyObservers(itemId, InventoryEvent.AddItem);
        return success;
    }

    public bool RemoveItem(int itemId)
    {
        bool success = _inventory.RemoveItem(itemId);
        if(success) NotifyObservers(itemId, InventoryEvent.RemoveItem);
        return success;
    }

    public bool RemoveItem(int itemId, int count)
    {
        for(int i = 0; i < count; i++)
        {
            bool success = _inventory.RemoveItem(itemId);
            if(!success) return false;  
        }
        return true;
    }

    public int GetItemCount(int itemId)
    {
        return _inventory.GetItemCount(itemId);
    }

    private void NotifyObservers(int itemId, InventoryEvent kind)
    {
        foreach (var observer in Observers)
        {
            observer.OnInventoryUpdate(itemId, kind);
        }  
    }
}