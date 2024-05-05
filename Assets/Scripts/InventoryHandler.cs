using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    private Inventory _inventory;

    private void Awake()
    {
        _inventory = new Inventory();
    }

    public void AddItem(int itemId)
    {
        _inventory.AddItem(itemId);
    } 

    public int GetItem(int itemId)
    {
        return _inventory.GetItem(itemId);
    }
}