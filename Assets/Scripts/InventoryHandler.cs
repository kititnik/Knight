using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    private Inventory _inventory;
    [SerializeField] private int inventorySize;

    private void Awake()
    {
        _inventory = new Inventory(inventorySize);
    }
    
    public void AddItem(int itemId)
    {
        _inventory.AddItem(itemId);
    }
}